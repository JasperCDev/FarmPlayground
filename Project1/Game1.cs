using FarmProject.src;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static RenderTarget2D renderTarget;

        public static Texture2D testSprite;
        public static Texture2D grassSprite;
        public static Texture2D soilSprite;

        public static readonly int WINDOW_WIDTH = 2560;
        public static readonly int WINDOW_HEIGHT = 1440;
        public static readonly int TARGET_WIDTH = 640;
        public static readonly int TARGET_HEIGHT = 360;
        public static readonly int RENDER_SCALE = Game1.WINDOW_HEIGHT / Game1.TARGET_HEIGHT;
        
        private Grid grid = new();
        public static InputManager inputManager = new InputManager();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this._graphics.PreferredBackBufferWidth = Game1.WINDOW_WIDTH;
            this._graphics.PreferredBackBufferHeight = Game1.WINDOW_HEIGHT;
            this._graphics.ApplyChanges();
            renderTarget = new RenderTarget2D(GraphicsDevice, Game1.TARGET_WIDTH, Game1.TARGET_HEIGHT);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            testSprite = Content.Load<Texture2D>("checkered_sprite");
            grassSprite = Content.Load<Texture2D>("grass");
            soilSprite = Content.Load<Texture2D>("soil");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Game1.inputManager.Update(gameTime);
            this.grid.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            this.grid.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);

            // Render Target stuff
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(
                texture: renderTarget,
                position: Vector2.Zero,
                sourceRectangle: null,
                color: Color.White,
                rotation: 0f,
                origin: Vector2.Zero,
                scale: Game1.RENDER_SCALE,
                effects: SpriteEffects.None,
                layerDepth: 0f
            );
            _spriteBatch.End();
        }
    }
}

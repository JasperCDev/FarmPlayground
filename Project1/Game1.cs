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

        private Texture2D testSprite;
        private Texture2D grassSprite;

        static int windowWidth = 2560;
        static int windowHeight = 1440;
        static int targetWidth = 640;
        static int targetHeight = 360;
        static int gridWidth = 40;
        static int gridHeight = 22;
        static int tileSize = 16;
        static int renderScale = Game1.windowHeight / Game1.targetHeight;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this._graphics.PreferredBackBufferWidth = Game1.windowWidth;
            this._graphics.PreferredBackBufferHeight = Game1.windowHeight;
            this._graphics.ApplyChanges();
            renderTarget = new RenderTarget2D(GraphicsDevice, Game1.targetWidth, Game1.targetHeight);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            testSprite = Content.Load<Texture2D>("checkered_sprite");
            grassSprite = Content.Load<Texture2D>("grass");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            for (int row = 0; row < Game1.gridHeight; row++)
            {
                for (int col = 0; col < Game1.gridWidth; col++)
                {
                    _spriteBatch.Draw(this.grassSprite, new Vector2(Game1.tileSize * col, Game1.tileSize * row + 4), Color.White);
                }
            }
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
                scale: Game1.renderScale,
                effects: SpriteEffects.None,
                layerDepth: 0f
            );
            _spriteBatch.End();
        }
    }
}

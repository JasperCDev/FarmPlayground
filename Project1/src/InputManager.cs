using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1;

namespace FarmProject.src
{
    public class InputManager : Component
    {

        public static MouseState OldMouseState { get; private set; }
        public static MouseState MouseState { get; private set; } = Mouse.GetState();
        public static Rectangle MouseRect { get; private set; }
        public static bool clickedThisFrame = false;
        public static bool hoveringObj = false;
        private static Rectangle GetMouseRect()
        {
            float x = MouseState.X / Game1.RENDER_SCALE;
            float y = MouseState.Y / Game1.RENDER_SCALE;

            return new((int)x, (int)y, 1, 1);
        }


        public override void Update(GameTime gameTime)
        {
            if (clickedThisFrame)
            {
                clickedThisFrame = false;
            };
            OldMouseState = MouseState;
            MouseState = Mouse.GetState();
            MouseRect = GetMouseRect();
        }

        public static bool IsClick(Rectangle rect)
        {
            if (clickedThisFrame)
            {
                return false;
            }
            bool isIntersecting = MouseRect.Intersects(rect);
            bool wasPressed = OldMouseState.LeftButton == ButtonState.Pressed;
            bool wasReleased = MouseState.LeftButton == ButtonState.Released;
            bool isClick = isIntersecting && wasPressed && wasReleased;
            if (isClick)
            {
                clickedThisFrame = true;
            }
            return isClick;
        }
        public static bool IsClick()
        {
            if (clickedThisFrame)
            {
                return false;
            }
            bool wasPressed = OldMouseState.LeftButton == ButtonState.Pressed;
            bool wasReleased = MouseState.LeftButton == ButtonState.Released;
            bool isClick = wasPressed && wasReleased;
            if (isClick)
            {
                clickedThisFrame = true;
            }
            return isClick;
        }

        public static bool IsHover(Rectangle rect)
        {
            if (hoveringObj)
            {
                return false;
            }
            bool isHover = MouseRect.Intersects(rect);
            if (isHover)
            {
                hoveringObj = true;
            }
            return isHover;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            return;
        }
    }
}

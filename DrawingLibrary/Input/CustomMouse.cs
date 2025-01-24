using DrawingLibrary.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Input
{
    public class CustomMouse : ICustomMouse
    {
        private MouseState MouseStateCurrent;
        private MouseState MouseStatePrevious;

        private static CustomMouse instance = null;

        private CustomMouse() {
            MouseStateCurrent = Mouse.GetState();
            MouseStatePrevious = MouseStateCurrent;
        }

        public static CustomMouse Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomMouse();
                }
                return instance;
            }
        }

        public Point WindowPosition => MouseStateCurrent.Position;

        public Vector2? GetScreenPosition(IScreen screen)
        {
            Rectangle scaledGame = screen.CalculateDestinationRectangle();

            float multiplierX = (float)screen.Width / scaledGame.Width;
            float multiplierY = (float)screen.Height / scaledGame.Height;

            float adjustedx = WindowPosition.X - scaledGame.X;
            float adjustedy = WindowPosition.Y - scaledGame.Y;
               
            float x = adjustedx * multiplierX;
            float y = adjustedy * multiplierY;

            if (adjustedx < 0 || adjustedy < 0 || adjustedx > scaledGame.Width || adjustedy > scaledGame.Height)
            {
                return null;
            }

            return new Vector2(x, y);
        }

        public bool IsLeftButtonClicked()
        {
            if (MouseStatePrevious.LeftButton == ButtonState.Pressed && MouseStateCurrent.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool IsLeftButtonDown()
        {
            if (MouseStateCurrent.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsLeftButtonUp()
        {
            if (MouseStateCurrent.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsMiddleButtonClicked()
        {
            if (MouseStatePrevious.MiddleButton == ButtonState.Pressed && MouseStateCurrent.MiddleButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsMiddleButtonDown()
        {
            if (MouseStateCurrent.MiddleButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsRightButtonClicked()
        {
            if (MouseStatePrevious.RightButton == ButtonState.Pressed && MouseStateCurrent.RightButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsRightButtonDown()
        {
            if (MouseStateCurrent.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update()
        {
            MouseStatePrevious = MouseStateCurrent;
            MouseStateCurrent = Mouse.GetState();
        }
    }
}

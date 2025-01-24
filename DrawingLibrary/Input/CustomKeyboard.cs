using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Input
{
    public class CustomKeyboard : ICustomKeyboard
    {
        private KeyboardState KBStateCurrent;

        private KeyboardState KBStatePrevious;

        private static CustomKeyboard instance = null;

        private CustomKeyboard() {
            KBStateCurrent = Keyboard.GetState();
            KBStatePrevious = KBStateCurrent;
        }

        public static CustomKeyboard Instance
        {
            get {
                if (instance == null)
                {
                    instance = new CustomKeyboard();
                }
                return instance;
            }
        }
        public bool IsKeyClicked(Keys key)
        {
            if (KBStateCurrent.IsKeyUp(key) && KBStatePrevious.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsKeyDown(Keys key)
        {
            if (KBStateCurrent.IsKeyDown(key))
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
            KBStatePrevious = KBStateCurrent;
            KBStateCurrent = Keyboard.GetState();
        }
    }
}

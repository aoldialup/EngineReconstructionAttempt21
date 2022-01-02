using SFML.Window;

using static SFML.Window.Keyboard;

namespace EngineReconstructionAttempt20
{
    class Input
    {
        private bool[] thisFrameKeysPressed;
        private bool[] lastFrameKeysPressed;

        public const int KEY_COUNT = (int)Key.KeyCount;

        public Input()
        {
            thisFrameKeysPressed = new bool[KEY_COUNT];
            lastFrameKeysPressed = new bool[KEY_COUNT];
        }

        public void Update()
        {
            lastFrameKeysPressed = (bool[])thisFrameKeysPressed.Clone();

            for (int i = 0; i < KEY_COUNT - 1; i++)
            {
                thisFrameKeysPressed[i] = Keyboard.IsKeyPressed((Key)i);
            }
        }

        public bool IsKeyPressed(Key key)
        {
            return thisFrameKeysPressed[(int)key] && !lastFrameKeysPressed[(int)key];
        }

        public bool IsKeyDown(Key key)
        {
            return thisFrameKeysPressed[(int)key];
        }

        public bool IsKeyUp(Key key)
        {
            return !thisFrameKeysPressed[(int)key] && lastFrameKeysPressed[(int)key];
        }
    }
}

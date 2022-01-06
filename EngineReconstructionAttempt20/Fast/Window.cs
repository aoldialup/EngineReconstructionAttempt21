using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace EngineReconstructionAttempt20
{
    class Window
    {
        private RenderWindow window;

        public Window(string name)
        {
            window = new RenderWindow(new VideoMode(800, 600), name, Styles.Titlebar | Styles.Close);
            window.SetVerticalSyncEnabled(true);

            window.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            RenderWindow window = sender as RenderWindow;
            window.Close();
        }

        public void Update()
        {
            window.DispatchEvents();
        }     

        public void BeginDraw()
        {
            window.Clear(Color.Black);
        }

        public void Draw(Drawable drawable)
        {
            window.Draw(drawable);
        }

        public void EndDraw()
        {
            window.Display();
        }

        public Vector2u center
        {
            get
            {
                return new Vector2u(window.Size.X / 2, window.Size.Y / 2);
            }
        }

        public bool IsOpen()
        {
            return window.IsOpen;
        }
    }
}
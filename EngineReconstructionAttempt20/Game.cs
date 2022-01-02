using SFML.Graphics;
using SFML.System;

namespace EngineReconstructionAttempt20
{
    class Game
    {
        private Window window;
        private Sprite sprite;

        private Input input;

        private Clock clock;
        private float deltaTime;

        private SceneManager sceneManager;

        private GameObject player;

        public Game()
        {
            sceneManager = new SceneManager();

            player = new GameObject();





            SplashScreenScene splashScreen = new SplashScreenScene();
            int id = sceneManager.Add(splashScreen);

            sceneManager.SwitchTo(id);

            clock = new Clock();
            input = new Input();

            window = new Window("Game");

            deltaTime = clock.Restart().AsSeconds();
        }

        public void Run()
        {
            while (IsRunning())
            {
                CaptureInput(); // we wanna capture input at the start of the frame
                Update();
                LateUpdate();
                Draw();
                CalculateDeltaTime();
            }
        }

        private void CaptureInput()
        {
            sceneManager.ProcessInput();
            //input.Update();
        }

        private void Update()
        {
            window.Update();
            /*
            if (input.IsKeyDown(Key.A))
            {
                Console.WriteLine("A");
            }
            }
            }
            */


            sceneManager.Update(deltaTime);
        }

        private void LateUpdate()
        {
            sceneManager.LateUpdate(deltaTime);
        }

        private void Draw()
        {
            window.BeginDraw();

            //window.Draw(sprite);
            sceneManager.Draw(window);

            window.EndDraw();
        }

        private void CalculateDeltaTime()
        {
            deltaTime = clock.Restart().AsSeconds();
        }

        private bool IsRunning()
        {
            return window.IsOpen();
        }
    }
}

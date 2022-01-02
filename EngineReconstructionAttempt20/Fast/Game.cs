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
        private SpriteAllocator spriteAllocator;

        public Game()
        {
            Init();

            sceneManager = new SceneManager();
            spriteAllocator = new SpriteAllocator();

            SplashScreenScene screen = new SplashScreenScene(sceneManager, window, spriteAllocator);
            screen.nextScene = Scene.NO_SCENE;

            sceneManager.Add(screen);

            int id = sceneManager.Add(screen);

            sceneManager.SwitchTo(id);
            
        }

        private void Init()
        {
            window = new Window("Game");
            
            clock = new Clock();
            input = new Input();
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
        }

        private void Update()
        {
            window.Update();
            sceneManager.Update(deltaTime);
        }

        private void LateUpdate()
        {
            sceneManager.LateUpdate(deltaTime);
        }

        private void Draw()
        {
            window.BeginDraw();
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

using SFML.Graphics;
using SFML.System;

namespace EngineReconstructionAttempt20
{
    class Game
    {
        private Window window;
        private Input input;
        private Clock clock;

        private float deltaTime;

        private SceneManager sceneManager;
        private SpriteAllocator spriteAllocator;
        private TextureAllocator textureAllocator;
        private GameObjectCollection gameObjectCollection;

        public Game()
        {
            Init();

            GameScene screen = new GameScene(
                input,
                sceneManager,
                window,
                textureAllocator, 
                gameObjectCollection  
                );

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

            sceneManager = new SceneManager();
            gameObjectCollection = new GameObjectCollection();

            spriteAllocator = new SpriteAllocator();
            textureAllocator = new TextureAllocator();
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

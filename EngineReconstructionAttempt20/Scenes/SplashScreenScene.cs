using System;

namespace EngineReconstructionAttempt20
{
    class SplashScreenScene : Scene
    {
        private SceneManager sceneManager;
        private Window window;
        private SpriteAllocator spriteAllocator;

        public SplashScreenScene(
                                SceneManager sceneManager,
                                Window window, 
                                SpriteAllocator spriteAllocator)
        {
            this.sceneManager = sceneManager;
            this.window = window;
            this.spriteAllocator = spriteAllocator;
        }

        private int spriteID = -1;

        public override void OnCreate()
        {
            spriteID = spriteAllocator.Add("sample_img.png");

            
        }

        public override void OnActivate()
        {
            Console.WriteLine("Activated");
        }

        public override void OnDeactivate() { }

        public override void OnDestroy() { }

        public override void Draw(Window window)
        {
            window.Draw(spriteAllocator.Get(spriteID));
        }
    }
}

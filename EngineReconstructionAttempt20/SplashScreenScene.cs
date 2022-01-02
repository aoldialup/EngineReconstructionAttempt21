using System;

namespace EngineReconstructionAttempt20
{
    class SplashScreenScene : Scene
    {
        GameObject player;

        public override void OnCreate()
        {
            player = new GameObject();
            player.AddComponent(new SpriteComponent());

            // Load the sprite for the player. player.GetComponent...
            // Use the SpriteComponent's Load method. Pass in "sample_img.png"



        }

        public override void OnActivate()
        {
            Console.WriteLine("Activated");
        }

        public override void OnDeactivate() { }

        public override void OnDestroy() { }

        public override void Draw(Window window)
        {
            player.Draw(window);
        }
    }
}

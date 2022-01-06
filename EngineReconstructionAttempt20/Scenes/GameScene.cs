using SFML.Graphics;
using SFML.System;
using System;

namespace EngineReconstructionAttempt20
{
    class GameScene : Scene
    {
        private Texture splashTexture;
        private Sprite splashSprite;
        
        private SceneManager sceneManager;
        private Window window;
        private TextureAllocator textureAllocator;

        private GameObjectCollection gameObjectCollection;

        private int nextScene = -1;

        private Input input;

        public GameScene(
                                Input input,
                                SceneManager sceneManager,
                                Window window, 
                                TextureAllocator textureAllocator,
                                GameObjectCollection gameObjectCollection)
        {
            this.sceneManager = sceneManager;
            this.window = window;
            this.textureAllocator = textureAllocator;
            this.gameObjectCollection = gameObjectCollection;
            this.input = input;
        }

        private int spriteID = -1;

        public override void OnCreate()
        {
            Vector2f position = new Vector2f(0f, 0f);
            int counter = 0;

            for(int i = 0; i < 20000; i++)
            {

                GameObject player = new GameObject();
                player.AddComponent(new MovementComponent());
                player.AddComponent(new SpriteComponent());

                SpriteComponent spriteComponent = player.GetComponent<SpriteComponent>() as SpriteComponent;

                spriteComponent.textureAllocator = textureAllocator;
                spriteComponent.Load($"{WorkingDirectory.CURRENT}down_bad.png");

                spriteComponent.scale /= 120f;

                MovementComponent movementComponent = player.GetComponent<MovementComponent>() as MovementComponent;
                movementComponent.input = input;

                player.transform.position = position;

                if(counter == 10)
                {
                    position = new Vector2f(0f, position.Y + 30f);
                    counter = 0;
                }
                else
                {
                    position += new Vector2f(80f, 0f);
                    counter++;
                }


                gameObjectCollection.Add(player);
            }
        }

        public override void Update(float deltaTime)
        {
            gameObjectCollection.ProcessRemovals();
            gameObjectCollection.ProcessNewObjects();
            gameObjectCollection.Update(deltaTime);
        }

        public override void LateUpdate(float deltaTime)
        {
            gameObjectCollection.LateUpdate(deltaTime);
        }

        public override void OnActivate()
        {
            Console.WriteLine("Activated");
        }

        public override void OnDeactivate() { }

        public override void OnDestroy() { }

        public override void Draw(Window window)
        {
            gameObjectCollection.Draw(window);
        }
    }
}

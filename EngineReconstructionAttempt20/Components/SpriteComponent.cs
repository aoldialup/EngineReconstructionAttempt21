using SFML.Graphics;

namespace EngineReconstructionAttempt20
{
    class SpriteComponent : Component
    {
        private int spriteID = -1;
        private SpriteAllocator spriteAllocator { get; set; }
        private Sprite sprite = null;

        public void Load(string filepath)
        {
            spriteID = spriteAllocator.Add(WorkingDirectory.CURRENT + filepath);
        }

        public override void LateUpdate(float deltaTime)
        {
            sprite.Position = gameObject.transform.position;
        }

        public override void Draw(Window window)
        {
            if (spriteID != -1)
            {
                window.Draw(spriteAllocator.Get(spriteID));
            }
        }
    }
}

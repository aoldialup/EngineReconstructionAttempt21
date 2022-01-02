using SFML.Graphics;

namespace EngineReconstructionAttempt20
{
    class SpriteComponent : Component
    {
        private Sprite sprite;

        public SpriteComponent()
        {
            sprite = new Sprite();
        }

        public void Load(string filepath)
        {
            sprite.Texture = new Texture(WorkingDirectory.DIRECTORY + filepath);
        }

        public override void Draw(Window window)
        {
            window.Draw(sprite);
        }
    }
}

using SFML.Graphics;
using SFML.System;
using System.Diagnostics;

namespace EngineReconstructionAttempt20
{
    class SpriteComponent : Component
    {
        private int currentTextureID = -1;
        private Sprite sprite = null;
        public TextureAllocator textureAllocator { get; set; }
        public void Load(int id)
        {
            if (id >= 0 && id != currentTextureID)
            {
                currentTextureID = id;

                Texture texture = textureAllocator.Get(id);
                sprite.Texture = texture;
            }
        }
        public void Load(string filepath)
        {
            Debug.Assert(textureAllocator != null, "Texture allocator is null");

            sprite = new Sprite();

            textureAllocator.Add(filepath);
            
            int textureID = textureAllocator.Get(filepath);

            if (textureID >= 0 && textureID != currentTextureID)
            {
                currentTextureID = textureID;

                Texture texture = textureAllocator.Get(textureID);
                sprite.Texture = texture;
            }
        }

        public override void LateUpdate(float deltaTime)
        {
            sprite.Position = gameObject.transform.position;
        }

        public IntRect GetTextureRect()
        {
            return sprite.TextureRect;
        }

        public void SetTextureRect(int x, int y, int width, int height)
        {
            sprite.TextureRect = new IntRect(x, y, width, height);
        }

        public void SetDimensions(float x, float y)
        {
            sprite.Scale = new SFML.System.Vector2f(x, y);
        }

        public Vector2f scale
        {
            get
            {
                return sprite.Scale;
            }
            set
            {
                sprite.Scale = value;
            }
        }

        public void SetTextureRect(IntRect rect)
        {
            sprite.TextureRect = rect;
        }

        public override void Draw(Window window)
        {
            window.Draw(sprite);
        }
    }
}

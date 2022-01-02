using SFML.Graphics;
using System.Collections.Generic;

namespace EngineReconstructionAttempt20
{
    abstract class ResourceAllocator<T>
    {
        protected Dictionary<int, T> resources;
        protected int currentID = 0;

        public abstract int Add(string filepath);

        public ResourceAllocator()
        {
            resources = new Dictionary<int, T>();
        }

        public T Get(int id)
        {
            return resources[id];
        }

        public void Remove(int id)
        {
            resources.Remove(id);
        }
    }

    class TextureAllocator : ResourceAllocator<Texture>
    {
        public override int Add(string filepath)
        {
            Texture texture = new Texture(filepath);
            resources.Add(currentID, texture);

            return currentID++;
        }
    }
}

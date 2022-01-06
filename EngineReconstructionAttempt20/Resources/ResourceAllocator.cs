using System.Collections.Generic;

namespace EngineReconstructionAttempt20
{
    abstract class ResourceAllocator<T>
    {
        public int NO_ID = -1;

        protected Dictionary<string, ResourceData<T>> resources;
        protected int currentID = 0;

        public ResourceAllocator()
        {
            resources = new Dictionary<string, ResourceData<T>>();
        }

        public abstract void Add(string filepath);

        protected int GetEquivalentResourceID(string filepath)
        {
            if (resources.ContainsKey(filepath))
            {
                return resources[filepath].id;
            }

            return NO_ID;
        }

        public T Get(int id)
        {
            foreach (var resource in resources)
            {
                if (resource.Value.id == id)
                {
                    return resource.Value.data;
                }
            }

            return default(T);
        }

        public int Get(string filepath)
        {
            return resources[filepath].id;
        }

        public void Remove(int id)
        {
            foreach (var resource in resources)
            {
                if (resource.Value.id == id)
                {
                    resources.Remove(resource.Key);
                }
            }
        }
    }
}

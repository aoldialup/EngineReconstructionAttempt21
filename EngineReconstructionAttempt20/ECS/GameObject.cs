using System.Diagnostics;
using System.Collections.Generic;

namespace EngineReconstructionAttempt20
{
    class GameObject
    {
        private List<Component> components = new List<Component>();

        public TransformComponent transform { get; set; }
        public bool isQueuedForRemoval { get; set; } = false;

        public GameObject()
        {
            AddComponent(new TransformComponent());
            transform = GetComponent<TransformComponent>() as TransformComponent;
        }

        public void Awake()
        {
            for (int i = components.Count - 1; i >= 0; i--)
            {
                components[i].Awake();
            }
        }

        public void Start()
        {
            for (int i = components.Count - 1; i >= 0; i--)
            {
                components[i].Start();
            }
        }

        public void Update(float deltaTime)
        {
            for (int i = components.Count - 1; i >= 0; i--)
            {
                components[i].Update(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            for (int i = components.Count - 1; i >= 0; i--)
            {
                components[i].LateUpdate(deltaTime);
            }
        }

        public void Draw(Window window)
        {
            for (int i = components.Count - 1; i >= 0; i--)
            {
                components[i].Draw(window);
            }
        }

        public Component GetComponent<T>()
        {
            foreach (Component c in components)
            {
                if (typeof(T) == c.GetType())
                {
                    return c;
                }
            }

            return null;
        }

        public void AddComponent(Component componentType)
        {
            Debug.Assert(!HasComponent(componentType));

            componentType.gameObject = this;
            components.Add(componentType);
        }

        public bool HasComponent(Component componentType)
        {
            foreach (Component c in components)
            {
                if (c.GetType() == componentType.GetType())
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveComponent<T>()
        {
            for(int i = 0; i < components.Count; i++)
            {
                if(typeof(T) == components[i].GetType())
                {
                    components[i].gameObject = null;
                    components.RemoveAt(i);

                    break;
                }
            }
        }
    }
}

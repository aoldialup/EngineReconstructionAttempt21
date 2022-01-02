using System.Collections.Generic;

namespace EngineReconstructionAttempt20
{
    class GameObject
    {
        // Awake is called when object created. Use to ensure 
        // required components are present.
        // 

        public void Awake()
        {
            for (int i = components.Count - 1; i >= 0; i--)
            {
                components[i].Awake();
            }
        }

        // Start is called after Awake method. Use to initialise variables.
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

        private List<Component> components = new List<Component>();

        public Component GetComponent(Component component)
        {
            foreach (Component c in components)
            {
                if (component.GetType().IsSubclassOf(c.GetType()))
                {
                    return c;
                }
            }

            return default(Component);
        }

        public void AddComponent(Component componentType)
        {
            foreach (Component c in components)
            {
                if (c.GetType() == componentType.GetType())
                {
                    return;
                }
            }

            componentType.gameObject = this;
            components.Add(componentType);
        }
    }
}

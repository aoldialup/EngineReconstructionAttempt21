using System.Collections.Generic;

namespace EngineReconstructionAttempt20
{
    class GameObjectCollection
    {
        private List<GameObject> gameObjects;
        private List<GameObject> newObjects;

        public void Add(GameObject gameObject)
        {
            newObjects.Add(gameObject);
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].LateUpdate(deltaTime);
            }
        }

        public void Draw(Window window)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(window);
            }
        }

        public void ProcessNewObjects()
        {
            if (newObjects.Count > 0)
            {
                foreach (GameObject g in newObjects)
                {
                    g.Awake();
                }

                foreach (GameObject g in newObjects)
                {
                    g.Start();
                }

                for (int i = 0; i < newObjects.Count; i++)
                {
                    gameObjects.Add(newObjects[i]);
                }

                gameObjects.Clear();
            }
        }

        public void ProcessRemovals()
        {

        }
    }
}

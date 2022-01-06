using System.Collections.Generic;

namespace EngineReconstructionAttempt20
{
    class GameObjectCollection
    {
        private List<GameObject> gameObjects;
        private List<GameObject> newObjects;

        public GameObjectCollection()
        {
            gameObjects = new List<GameObject>();
            newObjects = new List<GameObject>();
        }

        public void Add(GameObject gameObject)
        {
            newObjects.Add(gameObject);
        }

        public void Update(float deltaTime)
        {
            foreach(GameObject g in gameObjects)
            {
                g.Update(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            foreach(GameObject g in gameObjects)
            {
                g.LateUpdate(deltaTime);
            }
        }

        public void Draw(Window window)
        {
            foreach(GameObject g in gameObjects)
            {
                g.Draw(window);
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

                newObjects.Clear();
            }
        }

        public void ProcessRemovals()
        {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].isQueuedForRemoval)
                {
                    gameObjects.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
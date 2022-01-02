using System.Collections.Generic;

namespace EngineReconstructionAttempt20
{
    class SceneManager
    {
        public void ProcessInput()
        {
            if (curScene != null)
            {
                curScene.ProcessInput();
            }
        }

        public void Update(float deltaTime)
        {
            if (curScene != null)
            {
                curScene.Update(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            if (curScene != null)
            {
                curScene.LateUpdate(deltaTime);
            }
        }

        public void Draw(Window window)
        {
            if (curScene != null)
            {
                curScene.Draw(window);
            }
        }

        // Adds a scene to the state machine and returns the id of that scene.
        public int Add(Scene scene)
        {
            scenes.Add(sceneID, scene);
            scenes[sceneID].OnCreate();

            return sceneID++;
        }

        // Transitions to scene with specified id.

        public void SwitchTo(int id)
        {
            bool sceneExists = scenes.TryGetValue(id, out Scene scene);

            if (curScene != null)
            {
                curScene.OnDeactivate();
            }

            curScene = scenes[id];
            curScene.OnActivate();
        }

        // Removes scene from state machine.
        public void Remove(int id)
        {
            Scene scene = scenes[id];
            curScene = null;
        }

        // Stores all of the scenes associated with this state machine.
        private Dictionary<int, Scene> scenes = new Dictionary<int, Scene>();

        // Stores a reference to the current scene. Used when drawing/updating.
        Scene curScene;
        // Stores our current scene id. This is incremented whenever 
        // a scene is added.
        int sceneID;
    }
}

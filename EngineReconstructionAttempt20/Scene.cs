using System;
using System.Collections.Generic;
using System.Text;

namespace EngineReconstructionAttempt20
{
    abstract class Scene
    {
        public abstract void OnCreate();
        public abstract void OnDestroy();

        public virtual void OnActivate() { }
        public virtual void OnDeactivate() { }

        public virtual void ProcessInput() { }
        public virtual void Update(float deltaTime) { }
        public virtual void LateUpdate(float deltaTime) { }
        public virtual void Draw(Window window) { }
    }
}

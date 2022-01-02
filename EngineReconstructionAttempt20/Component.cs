namespace EngineReconstructionAttempt20
{
    class Component
    {
        public GameObject gameObject { get; set; }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update(float deltaTime) { }
        public virtual void LateUpdate(float deltaTime) { }
        public virtual void Draw(Window window) { }
    }
}

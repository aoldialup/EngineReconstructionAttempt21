using SFML.System;

namespace EngineReconstructionAttempt20
{
    class MovementComponent : Component
    {
        public Vector2f velocity { get; set; }

        public Input input { get; set; }

        public override void Start()
        {
            velocity = new Vector2f(2f, 2f);
        }

        public override void Update(float deltaTime)
        {
            gameObject.transform.position += new Vector2f(Helper.GetRandomFloat(0.1f, 0.78f), Helper.GetRandomFloat(0.5f, 0.7f));
        }
    }
}

namespace EngineReconstructionAttempt20
{
    class AnimationData
    {
        public Animation animation { get; set; }
        public AnimationState state { get; set; }

        public AnimationData(AnimationState state, Animation animation)
        {
            this.state = state;
            this.animation = animation;
        }
    }
}
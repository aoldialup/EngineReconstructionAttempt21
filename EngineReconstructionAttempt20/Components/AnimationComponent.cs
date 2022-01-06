using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EngineReconstructionAttempt20
{
    // Requires that an object has a sprite component
    class AnimationComponent : Component
    {
        private SpriteComponent spriteComponent;
        private Dictionary<AnimationState, Animation> animations;
        private Tuple<AnimationState, Animation> currentAnimation;

        public override void Awake()
        {
            // Get a reference to the object's sprite component, as it is needed for animation
            spriteComponent = gameObject.GetComponent<SpriteComponent>() as SpriteComponent;
        }

        public override void Update(float deltaTime)
        {
            if (currentAnimation.Item1 != AnimationState.NONE)
            {
                currentAnimation.Item2.UpdateFrame(deltaTime);

                if (currentAnimation.Item2.hasFrameChanged)
                {
                    // If the current animation has been incrimented, we need to retrieve the new frame data
                    // and update the sprite with our new texture rect
                    FrameData frameData = currentAnimation.Item2.GetCurrentFrame();

                    spriteComponent.Load(frameData.textureID);
                    spriteComponent.SetTextureRect(new IntRect(frameData.position, frameData.dimensions));
                }
            }
        }

        public void AddAnimation(AnimationState state, Animation animation)
        {
            animations.Add(state, animation);

            if (currentAnimation.Item1 == AnimationState.NONE)
            {
                SetAnimationState(state);    
            }

        }

        public void SetAnimationState(AnimationState state)
        {
            if(currentAnimation.Item1 != state)
            {
                var kvpAnimation = animations.SingleOrDefault(kvp => kvp.Key == state);
                currentAnimation = new Tuple<AnimationState, Animation>(kvpAnimation.Key, kvpAnimation.Value);
            }
        }

        public AnimationState GetAnimationState()
        {
            return currentAnimation.Item1;
        }
    }
}
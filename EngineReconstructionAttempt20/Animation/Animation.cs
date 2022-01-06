using SFML.System;
using System.Collections.Generic;

namespace EngineReconstructionAttempt20
{
    // This class acts as a collection of frames
    class Animation
    {
        // All the frames for our animation
        private List<FrameData> frames;

        // The current frame
        private int currentFrameIndex;

        // The time left until the current frame is over
        private float currentFrameTimeLeft;

        public bool hasFrameChanged { get; private set; }

        public Animation()
        {
            frames = new List<FrameData>();
        }

        // Add a frame to the animation. Frames are played in the order in which they are added
        public void AddFrame(int textureID, Vector2i position, Vector2i dimensions, float frameTime)
        {
            FrameData frameData = new FrameData(textureID, position, dimensions, frameTime);
            frames.Add(frameData);
        }

        // Returns the data for the current frame
        public FrameData GetCurrentFrame()
        {
            if (frames.Count > 0)
            {
                return frames[currentFrameIndex];
            }

            return null;
        }

        /*
         *         *UpdateFrame checks if it is time t
         *          *         o transition to the next frame. It returns true if the frame has changed. 
         *          *          When a frames time is up it calls IncrementFrame, which increments the frame index by 1. 
         *          *          If we’ve reached the end of the animation the frame index is looped to the beginning. 
         *          *          In future, we will want to be able to define if an animation should play in a loop or play 
         *          *          once and then stop or revert back to a previous animation.
         */

        public bool hasFrames
        {
            get
            {
                return frames.Count > 0;
            }
        }

        private bool IsCurrentFrameOver()
        {
            return currentFrameTimeLeft <= 0f;
        }

        public void UpdateFrame(float deltaTime)
        {
            if (hasFrames)
            {
                currentFrameTimeLeft -= deltaTime;

                if (IsCurrentFrameOver())
                {
                    currentFrameTimeLeft = 0f;
                    IncrimentFrame();

                    hasFrameChanged = true;
                }
            }

            hasFrameChanged = false;
        }

        public void Reset()
        {
            currentFrameIndex = 0;
        }

        private void IncrimentFrame()
        {
            if (LastFrameReached())
            {
                currentFrameIndex = 0;
            }
            else
            {
                currentFrameIndex++;
            }
        }

        private bool LastFrameReached()
        {
            return currentFrameIndex == frames.Count - 1;
        }
    }
}


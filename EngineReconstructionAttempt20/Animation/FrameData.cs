using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace EngineReconstructionAttempt20
{
    class FrameData
    {
        public int textureID { get; set; } // texture id (from the allocator)
        public Vector2i position { get; set; } // position of the part of the animation in the texture
        public Vector2i dimensions { get; set; } // the width and height of the sprite 
        public float displayTimeSeconds { get; set; } // How long to display the frame

        public FrameData(int textureID, Vector2i position, Vector2i dimensions, float displayTimeSeconds)
        {
            this.textureID = textureID;
            this.position = position;
            this.dimensions = dimensions;
            this.displayTimeSeconds = displayTimeSeconds;
        }
    }
}

using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineReconstructionAttempt20
{
    class TextureAllocator : ResourceAllocator<Texture>
    {
        public override void Add(string filepath) 
        {
            int createdID = GetEquivalentResourceID(filepath);

            if(createdID == NO_ID)
            {
                createdID = currentID;

                Texture texture = new Texture(filepath);
                resources.Add(filepath, new ResourceData<Texture>(createdID, texture));
                currentID++;
            }                      
        }
    }
}

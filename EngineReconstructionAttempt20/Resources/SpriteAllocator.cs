using SFML.Graphics;

namespace EngineReconstructionAttempt20
{
    class SpriteAllocator : ResourceAllocator<Sprite>
    {
        public override void Add(string filepath)
        {
            int createdID = GetEquivalentResourceID(filepath);

            if(createdID == NO_ID)
            {
                createdID = currentID;

                Sprite s = new Sprite(new Texture(filepath));
                resources.Add(filepath, new ResourceData<Sprite>(createdID, s));

                currentID++;
            }
        }
    }
}
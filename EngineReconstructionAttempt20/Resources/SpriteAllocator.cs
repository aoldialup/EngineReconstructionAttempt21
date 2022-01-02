using SFML.Graphics;

namespace EngineReconstructionAttempt20
{
    class SpriteAllocator : ResourceAllocator<Sprite>
    {
        public override int Add(string filepath)
        {
            Sprite s = new Sprite(new Texture(WorkingDirectory.CURRENT + filepath));
            resources.Add(currentID, s);

            return currentID++;
        }
    }
}
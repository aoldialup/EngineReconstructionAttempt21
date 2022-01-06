using System;
using System.Collections.Generic;
using System.Text;

namespace EngineReconstructionAttempt20
{
    class ResourceData<T>
    {
        public int id { get; set; }
        public T data { get; set; }

        public ResourceData(int id, T data)
        {
            this.id = id;
            this.data = data;
        }
    }
}

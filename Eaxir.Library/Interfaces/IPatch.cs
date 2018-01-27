using System.Collections.Generic;

namespace Eaxir.Library.Interfaces
{
    public interface IPatch
    {
        void Patch(Dictionary<int, byte[]> patchBytes);
    }
}

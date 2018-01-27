using Echoic.Binary;
using Echoic.Checksum;

namespace Eaxir.Library.Interfaces
{
    /// <summary>
    /// Interface for exposing methods that handle installation of packages.
    /// </summary>
    public interface IInstall
    {
        /// <summary>
        /// Blam.sav patching class.
        /// </summary>
        IPatch Patch { get; }

        /// <summary>
        /// Blam.sav forging class.
        /// </summary>
        IHash Forge { get; }

        /// <summary>
        /// Directory path value.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Install the package.
        /// </summary>
        void Install();

        /// <summary>
        /// Uninstall the package.
        /// </summary>
        void Uninstall();
    }
}

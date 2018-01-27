using Echoic.Binary;

namespace Eaxir.Library.Interfaces
{
    /// <summary>
    /// Interface for exposing methods that handle uninstallation of packages.
    /// </summary>
    public interface IUninstall
    {
        /// <summary>
        /// Uninstall the package from a custom location.
        /// </summary>
        /// <param name="manipulate"></param>
        void Uninstall(IManipulate manipulate);
    }
}

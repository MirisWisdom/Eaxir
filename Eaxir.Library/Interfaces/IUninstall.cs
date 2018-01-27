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
        /// <param name="path"></param>
        void Uninstall(string path);
    }
}

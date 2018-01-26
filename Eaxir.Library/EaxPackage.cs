using Eaxir.Library.Interfaces;

namespace Eaxir.Library
{
    /// <summary>
    /// Handles the (un)installation of the EAX library.
    /// </summary>
    public class EaxPackage : IInstall, IUninstall
    {
        /// <summary>
        /// Automatically install the EAX to the HCE directory.
        /// </summary>
        public void Install()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Install the EAX to a specified HCE directory.
        /// </summary>
        /// <param name="path"></param>
        public void Install(string path)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Automatically uninstall the EAX from the HCE directory.
        /// </summary>
        public void Uninstall()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Uninstall teh EAX from a specified HCE directory.
        /// </summary>
        /// <param name="path"></param>
        public void Uninstall(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}

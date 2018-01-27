using Eaxir.Library.Interfaces;
using Echoic.Binary;
using System.Collections.Generic;
using System.IO;

namespace Eaxir.Library
{
    /// <summary>
    /// Handles the (un)installation of the EAX library.
    /// </summary>
    public class EaxInstallation : IInstall, IUninstall
    {
        private readonly string _installationPath;

        private string ConfigurationPath => $"{_installationPath}/{EaxResources.ConfigurationName}";

        private string LibraryPath => $"{_installationPath}/{EaxResources.LibraryName}";

        public EaxInstallation(string installationPath)
        {
            _installationPath = installationPath;
        }

        /// <summary>
        /// Install the EAX to a specified HCE directory.
        /// </summary>
        /// <param name="eaxManipulate"></param>
        public void Install(IManipulate eaxManipulate)
        {
            DeleteFiles();

            File.WriteAllBytes(LibraryPath, EaxResources.Library);
            File.WriteAllText(ConfigurationPath, EaxResources.Configuration);

            eaxManipulate.Patch(GetEnablingBytes());
        }

        /// <summary>
        /// Uninstall the EAX from a specified HCE directory.
        /// </summary>
        /// <param name="eaxManipulate"></param>
        public void Uninstall(IManipulate eaxManipulate)
        {
            DeleteFiles();

            eaxManipulate.Patch(GetDisablingBytes());
        }

        private Dictionary<int, byte[]> GetDisablingBytes()
        {
            return new Dictionary<int, byte[]>
            {
                { 0xB7C, new byte[] { 0x01 } },
                { 0xB7B, new byte[] { 0x01 } },
                { 0xB7F, new byte[] { 0x01 } },
                { 0xB7D, new byte[] { 0x01 } },
            };
        }

        private Dictionary<int, byte[]> GetEnablingBytes()
        {
            return new Dictionary<int, byte[]>
            {
                { 0xB7C, new byte[] { 0x01 } },
                { 0xB7B, new byte[] { 0x01 } },
                { 0xB7F, new byte[] { 0x02 } },
                { 0xB7D, new byte[] { 0x02 } },
            };
        }

        private void DeleteFiles()
        {
            if (File.Exists(LibraryPath))
            {
                File.Delete(LibraryPath);
            }

            if (File.Exists(ConfigurationPath))
            {
                File.Exists(ConfigurationPath);
            }
        }
    }
}

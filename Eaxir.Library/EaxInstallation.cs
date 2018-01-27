using Eaxir.Library.Interfaces;
using Echoic.Binary;
using Echoic.Checksum;
using System.Collections.Generic;
using System.IO;

namespace Eaxir.Library
{
    /// <summary>
    /// Handles the (un)installation of the EAX library.
    /// </summary>
    public class EaxInstallation : IInstall
    {
        private string ConfigurationPath => $"{Path}/{EaxResources.ConfigurationName}";

        private string LibraryPath => $"{Path}/{EaxResources.LibraryName}";

        public IPatch Patch { get; }
        public IHash Forge { get; }
        public string Path { get; }

        /// <summary>
        /// Constructor for EaxInstallation
        /// </summary>
        /// <param name="patch"></param>
        /// <param name="forge"></param>
        /// <param name="path"></param>
        public EaxInstallation(IPatch patch, IHash forge, string path)
        {
            Patch = patch;
            Forge = forge;
            Path = path;
        }

        /// <summary>
        /// Uninstall the EAX from a specified HCE directory.
        /// </summary>
        public void Install()
        {
            DeleteFiles();

            File.WriteAllBytes(LibraryPath, EaxResources.Library);
            File.WriteAllText(ConfigurationPath, EaxResources.Configuration);

            Patch.Patch(GetEnablingBytes());
        }


        /// <summary>
        /// Install the EAX to a specified HCE directory.
        /// </summary>
        public void Uninstall()
        {
            DeleteFiles();

            Patch.Patch(GetDisablingBytes());
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

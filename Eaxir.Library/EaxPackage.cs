using Eaxir.Library.Interfaces;
using Echoic.Binary;
using System.Collections.Generic;
using System.IO;

namespace Eaxir.Library
{
    /// <summary>
    /// Handles the (un)installation of the EAX library.
    /// </summary>
    public class EaxPackage : IInstall, IUninstall
    {
        private readonly IManipulate _eaxManipulate;

        public EaxPackage(IManipulate eaxManipulate)
        {
            _eaxManipulate = eaxManipulate;
        }

        /// <summary>
        /// Install the EAX to a specified HCE directory.
        /// </summary>
        /// <param name="path"></param>
        public void Install(string path)
        {
            File.WriteAllBytes(GetLibraryPath(path), EaxResources.Library);
            File.WriteAllText(GetConfigurationPath(path), EaxResources.Configuration);

            _eaxManipulate.Patch(GetEnablingBytes());
        }

        /// <summary>
        /// Uninstall the EAX from a specified HCE directory.
        /// </summary>
        /// <param name="path"></param>
        public void Uninstall(string path)
        {
            File.Delete(GetLibraryPath(path));
            File.Delete(GetConfigurationPath(path));

            _eaxManipulate.Patch(GetDisablingBytes());
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

        private string GetConfigurationPath(string path)
        {
            return $"{path}/{EaxResources.ConfigurationName}";
        }

        private string GetLibraryPath(string path)
        {
            return $"{path}/{EaxResources.LibraryName}";
        }
    }
}

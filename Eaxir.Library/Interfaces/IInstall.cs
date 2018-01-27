using Echoic.Binary;

namespace Eaxir.Library.Interfaces
{
    /// <summary>
    /// Interface for exposing methods that handle installation of packages.
    /// </summary>
    public interface IInstall
    {
        /// <summary>
        /// Install the package to a custom location.
        /// </summary>
        /// <param name="manipulate"></param>
        void Install(IManipulate manipulate);
    }
}

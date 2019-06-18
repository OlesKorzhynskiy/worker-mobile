using System.IO;
using System.Threading.Tasks;

namespace Worker.Interfaces
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
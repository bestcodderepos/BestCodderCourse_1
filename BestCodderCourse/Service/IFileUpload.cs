using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace BestCodderCourse.Service
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
    }
}

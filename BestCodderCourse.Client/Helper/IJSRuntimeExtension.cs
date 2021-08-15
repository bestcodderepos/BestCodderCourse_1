using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BestCodderCourse.Client.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime,string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("DisplayToastr", "error", message);
        }
    }
}

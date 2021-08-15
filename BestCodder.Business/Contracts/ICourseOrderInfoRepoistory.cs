using BestCodder.Common;
using BestCodder.Models;
using System.Threading.Tasks;

namespace BestCodder.Business.Contracts
{
    public interface ICourseOrderInfoRepoistory
    {
        public Task<Result<CourseOrderInfoDto>> Create(CourseOrderInfoDto details);
        public Task<Result<CourseOrderInfoDto>> PaymentSuccessful(CourseOrderInfoDto details);
        public Task<Result<CourseOrderInfoDto>> GetCourseOrderInfo(int courseId);
        public Task<Result<bool>> UpdateCourseOrderStatus(int courseOrderId,string status);
    }
}

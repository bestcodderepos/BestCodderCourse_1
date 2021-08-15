using BestCodder.Common;
using BestCodder.Models;
using System.Threading.Tasks;

namespace BestCodderCourse.Client.Service.Contracts
{
    public interface ICourseOrderInfoService
    {
        public Task<Result<CourseOrderInfoDto>> SaveCourseOrderInfo(CourseOrderInfoDto model);
        public Task<Result<CourseOrderInfoDto>> PaymentSuccessful(int courseId);
    }
}

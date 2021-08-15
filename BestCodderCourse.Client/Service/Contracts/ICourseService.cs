using BestCodder.Common;
using BestCodder.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestCodderCourse.Client.Service.Contracts
{
    public interface ICourseService
    {
        public Task<Result<IEnumerable<CourseDto>>> GetAllCourse();

        public Task<Result<CourseDto>> GetCourse(int courseId);
    }
}

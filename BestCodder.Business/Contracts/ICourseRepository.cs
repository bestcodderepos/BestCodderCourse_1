using BestCodder.Common;
using BestCodder.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestCodder.Business.Contracts
{
    public interface ICourseRepository
    {
        public Task<Result<CourseDto>> CreateCourse(CourseDto courseDto);
        public Task<Result<CourseDto>> UpdateCourse(int courseId, CourseDto courseDto);
        public Task<Result<CourseDto>> GetCourse(int courseId);
        public Task<Result<int>> DeleteCourse(int courseId);

        public Task<Result<IEnumerable<CourseDto>>> GetAllCourse();
    }
}

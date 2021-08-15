using AutoMapper;
using BestCodder.Business.Contracts;
using BestCodder.Common;
using BestCodder.DataAccess.Data;
using BestCodder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BestCodder.Business.Implementaion
{
    public class CourseOrderInfoRepository : ICourseOrderInfoRepoistory
    {
        private readonly BestCodderCourseContext _ctx;
        private readonly IMapper _mapper;

        public CourseOrderInfoRepository(BestCodderCourseContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<Result<CourseOrderInfoDto>> Create(CourseOrderInfoDto details)
        {
            try
            {
                var courseOrder = _mapper.Map<CourseOrderInfoDto, CourseOrderInfo>(details);
                courseOrder.Status = ResultConstant.Status_Pending;
                var result = await _ctx.CourseOrderInfos.AddAsync(courseOrder);
                await _ctx.SaveChangesAsync();
                var returnData = _mapper.Map<CourseOrderInfo, CourseOrderInfoDto>(result.Entity);
                return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordCreateSuccessfully, returnData);
            }
            catch (Exception ex)
            {
                return new Result<CourseOrderInfoDto>(false, ex.Message.ToString());
            }
        }

        public async Task<Result<CourseOrderInfoDto>> GetCourseOrderInfo(int courseId)
        {
            try
            {
                var data = await _ctx.CourseOrderInfos.Include(c => c.Course).FirstOrDefaultAsync(c => c.Id == courseId);
                var info = _mapper.Map<CourseOrderInfo, CourseOrderInfoDto>(data);
                info.TotalCount = _ctx.Courses.Where(x => x.Id == courseId).ToList().Count;
                return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordFound, info);
            }
            catch (Exception ex)
            {
                return new Result<CourseOrderInfoDto>(false, ex.Message.ToString());
            }
        }

        public Task<Result<CourseOrderInfoDto>> PaymentSuccessful(CourseOrderInfoDto details)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UpdateCourseOrderStatus(int courseOrderId, string status)
        {
            throw new NotImplementedException();
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BestCodder.Models
{
    public class CourseOrderInfoDto
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int TotalCount { get; set; }
        public string UserId { get; set; }
        public string StripeSessionId { get; set; }
        public decimal CoursePrice { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public bool IsPaymentSuccessfull { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public CourseDto CourseDto { get; set; }
    }
}

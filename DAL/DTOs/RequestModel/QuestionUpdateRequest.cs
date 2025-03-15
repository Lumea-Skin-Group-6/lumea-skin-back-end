using BusinessObject;
using System.ComponentModel.DataAnnotations;
using SkincareBookingApp.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DTOs.RequestModel
{
    public class QuestionUpdateRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(100, ErrorMessage = "Content cannot exceed 100 characters.")]
        public string QuestionContent { get; set; }
        public bool IsMultipleChoice { get; set; }
        public bool Active { get; set; }
        public List<int>? AnswerIds { get; set; }
    }
}
﻿using BusinessObject;
using System.ComponentModel.DataAnnotations;
using SkincareBookingApp.Helpers;

namespace DAL.DTOs.RequestModel
{
    public class QuestionCreateRequest
    {
        [Required(ErrorMessage = "Content is required.")]
        [StringLength(100, ErrorMessage = "Content cannot exceed 100 characters.")]
        public string QuestionContent { get; set; }
        public bool IsMultipleChoice { get; set; }
        public List<int>? AnswerIds { get; set; }
    }
}
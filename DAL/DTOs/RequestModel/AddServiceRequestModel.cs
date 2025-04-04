﻿using BusinessObject;
using SkincareBookingApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class AddServiceRequestModel
    {
        [Required(ErrorMessage = "Service Name is required.")]
        [StringLength(100, ErrorMessage = "Service Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = "";

        [Url(ErrorMessage = "Invalid Image URL format.")]
        public string ImageUrl { get; set; } = "";

        [Url(ErrorMessage = "Invalid Image URL format.")]
        public string ImageUrl2 { get; set; } = "";

        [Url(ErrorMessage = "Invalid Image URL format.")]
        public string ImageUrl3 { get; set; } = "";

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Recommended Period Start Time is required.")]
        public string RecommendedPeriodStartTime { get; set; }

        [Required(ErrorMessage = "Recommended Period End Time is required.")]
        public string RecommendedPeriodEndTime { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        public TimeSpan Duration { get; set; }

        [StringLength(200, ErrorMessage = "Experience Required cannot be longer than 200 characters.")]
        public string ExperienceRequired { get; set; } = "";

        [StringLength(200, ErrorMessage = "Recommended Age cannot be longer than 30 characters.")]
        public string RecommendedAge { get; set; } = "";

        [Required(ErrorMessage = "Type is required.")]
        [EnumValidation(typeof(ServiceType), ErrorMessage = "Invalid ServiceType value.")]
        public ServiceType Type { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number of Treatment must be at least 1.")]
        public int NumberOfTreatment { get; set; }

        public List<int> ServiceExpertisesID { get; set; }

        public List<int> SkinTypeID { get; set; }
    }
}

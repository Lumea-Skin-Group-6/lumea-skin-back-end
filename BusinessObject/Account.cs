﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    [Table("accounts")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")] public string FullName { get; set; }

        [Column("email")] public string Email { get; set; }

        [Column("password_hash")] public string Password { get; set; }

        [Column("date_of_birth")] public DateTime DateOfBirth { get; set; }

        [Column("image_url")] public string? ImageUrl { get; set; }

        [Column("gender")] public bool Gender { get; set; }

        [Column("phone_number")] public string Phone { get; set; }

        [Column("role_id")] public int RoleId { get; set; }

        [Column("account_status")] public string Status { get; set; }

        [Column("is_logged_in")] public bool IsLoggedIn { get; set; }

        [Column("is_deleted")] public bool IsDeleted { get; set; }

        [Column("refresh_token")] public string? RefreshToken { get; set; }

        [Column("refresh_token_expiry")] public DateTime? RefreshTokenExpiry { get; set; }

        [Column("activation_code")] public string? ActivationCode { get; set; }

        public Role Role { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public Employee? Employee { get; set; }
    }
}
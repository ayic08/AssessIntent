using Exam.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.DTO
{
    public class UserDTO
    {
        public UserDTO() { }
        public UserDTO(User product)
        {
            Id = product.Id;
            UserName = product.UserName;
            FirstName = product.FirstName;
            LastName = product.LastName;
            Password = product.Password;
            CreatedDate = product.CreatedDate;
            CreatedBy = product.CreatedBy;
            UpdatedDate = product.UpdatedDate;
            UpdatedBy = product.UpdatedBy;
            IsEnabled = product.IsEnabled;
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsEnabled { get; set; }
    }
}

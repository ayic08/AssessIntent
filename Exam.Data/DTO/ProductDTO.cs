using Exam.Data.EntityModels;
using Microsoft.AspNetCore.Http;

namespace Exam.Data.DTO
{
    public class ProductDTO
    {
        public ProductDTO() { }
        public ProductDTO(Product product) 
        { 
            Id = product.Id;
            ProductName = product.ProductName;
            ProductDescription = product.ProductDescription;
            ImagePath = product.ImagePath;
            CreatedDate = product.CreatedDate;
            CreatedBy = product.CreatedBy;
            UpdatedDate = product.UpdatedDate;
            UpdatedBy = product.UpdatedBy;
            IsEnabled = product.IsEnabled;
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsEnabled { get; set; }
        public IFormFile? File { get; set; }
    }
}

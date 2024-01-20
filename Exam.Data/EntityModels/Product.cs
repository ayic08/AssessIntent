using System;
using System.Collections.Generic;

namespace Exam.Data.EntityModels;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public string? ImagePath { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public bool IsEnabled { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Exam.Data.EntityModels;

public partial class User
{
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

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
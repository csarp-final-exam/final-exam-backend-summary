using System;
using System.Collections.Generic;

namespace SCMProject.Models;

public partial class Student
{
    public int? Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public bool IsActive { get; set; }

    public int? Age { get; set; }

    public decimal? Gpa { get; set; }

    public double? TuitionFee { get; set; }

    public string Email { get; set; }
}

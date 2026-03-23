using System;

namespace StudentsAvalonia.Data;

public class User
{
    public int IdUser { get; set; }

    public string? Fname { get; set; }
    public string? Name { get; set; }
    public string? Patronumic { get; set; }

    public DateOnly? DateBirth { get; set; }

    public int? IdGroup { get; set; }
    public Group? Group { get; set; }

    public int? IdLogPass { get; set; }
}
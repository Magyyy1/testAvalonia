using System.Collections.Generic;

namespace StudentsAvalonia.Data;

public class Group
{
    public int IdGroup { get; set; }
    public string? Number { get; set; }
    public string? Description { get; set; }

    public int? IdSpeciality { get; set; }
    public Speciality? Speciality { get; set; }

    public List<User> Users { get; set; } = new();

    public override string ToString()
    {
        return Number ?? "";
    }
}
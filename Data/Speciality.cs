using System.Collections.Generic;

namespace StudentsAvalonia.Data;

public class Speciality
{
    public int IdSpeciality { get; set; }
    public string? NameSpeciality { get; set; }
    public string? Description { get; set; }

    public List<Group> Groups { get; set; } = new();

    public override string ToString()
    {
        return NameSpeciality ?? "";
    }
}
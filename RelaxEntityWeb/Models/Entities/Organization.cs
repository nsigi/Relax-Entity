using System;
using System.Collections.Generic;

namespace RelaxEntityWeb.Models.Entities;

public partial class Organization
{
    public Organization()
    {

    }
    public Organization(string name, string email, string address)
    {
        Name = name;
        Address = address;
    }
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Location> Locations { get; } = new List<Location>();

    public virtual ICollection<ProjectManager> ProjectManagers { get; } = new List<ProjectManager>();

    public virtual ICollection<Programm> Programms { get; } = new List<Programm>();
    public override string ToString()
    {
        return string.Format("{0} {1}", Name, Address);
    }
}

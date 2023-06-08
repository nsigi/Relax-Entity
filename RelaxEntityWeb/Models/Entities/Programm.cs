using System;
using System.Collections.Generic;

namespace RelaxEntityWeb.Models.Entities;

public partial class Programm
{
    public Programm()
    {

    }

    public Programm(string name, string description, TimeSpan duration, int age, string organization)
    {
        Name = name;
        Description = description;
        Duration = duration;
        Age = age;
        Organization = organization;
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public TimeSpan Duration { get; set; }

    public int Age { get; set; }

    public string Organization { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();

	public virtual Organization OrganizationNavigation { get; set; } = null!;
	public override string ToString()
    {
        return string.Format("{0} {1} {2} {3}", Id, Name, Description, Duration);
    }
}

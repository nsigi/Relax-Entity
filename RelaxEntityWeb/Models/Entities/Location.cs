using System;
using System.Collections.Generic;

namespace RelaxEntityWeb.Models.Entities;

public partial class Location
{
    public Location()
    {

    }
    public Location(string name, int capaciousness, string equipment, string organization)
    {
        Name = name;
        Capaciousness = capaciousness;
        Equipment = equipment;
        Organization = organization;
    }
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Capaciousness { get; set; }

    public string Equipment { get; set; } = null!;

    public string Organization { get; set; } = null!;

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual Organization OrganizationNavigation { get; set; } = null!;

    public override string ToString()
    {
        return string.Format("{0} {1} {2}", Name, Capaciousness, Equipment);
    }
}

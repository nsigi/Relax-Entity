using System;
using System.Collections.Generic;

namespace RelaxEntityWeb.Models.Entities;

public partial class ProjectManager
{
    public ProjectManager()
    {

    }
    public ProjectManager(string organization, string client)
    {
        Organization = organization;
        Client = client;
    }

    public int Id { get; set; }

    public string Organization { get; set; } = null!;

    public string Client { get; set; } = null!;

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual Organization OrganizationNavigation { get; set; } = null!;
    public override string ToString()
    {
        return string.Format("{0} {1} {2}", Id, Organization, Client);
    }
}

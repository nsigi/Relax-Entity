using System;
using System.Collections.Generic;

namespace RelaxEntityWeb.Models.Entities;

public partial class Client
{
    public Client()
    {

    }
    public Client(string name, string phone, string email, string password)
    {
        Name = name;
        Phone = phone;
        Email = email;
        Password = password;
    }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<ProjectManager> ProjectManagers { get; } = new List<ProjectManager>();

    public override string ToString()
    {
        return string.Format("{0} {1} {2} {3}", Name, Phone, Email, Password);
    }
}

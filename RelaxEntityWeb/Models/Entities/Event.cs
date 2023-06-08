using System;
using System.Collections.Generic;

namespace RelaxEntityWeb.Models.Entities;

public partial class Event
{
    public Event()
    {

    }
    public Event(string name, DateTime date, TimeSpan startTime, int countMax, int countCurrent, string note, decimal price, int pmId, int status,
        int locationId, int programId)
    {
        Name = name;
        Date = date;
        StartTime = startTime;
        CountMax = countMax;
        CountCurrent = countCurrent;
        Note = note;
        Price = price;
        PmId = pmId;
        Status = status;
        LocationId = locationId;
        ProgramId = programId;
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public TimeSpan StartTime { get; set; }

    public int CountMax { get; set; }

    public int CountCurrent { get; set; }

    public string? Note { get; set; }

    public decimal Price { get; set; }

    public int PmId { get; set; }

    public int Status { get; set; }

    public int LocationId { get; set; }

    public int ProgramId { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ProjectManager Pm { get; set; } = null!;

    public virtual Programm Program { get; set; } = null!;

    public override string ToString()
    {
        return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}",
            Id, Name, Date, StartTime, CountMax, CountCurrent, Note, Price, PmId, Status, LocationId, ProgramId);
    }
}

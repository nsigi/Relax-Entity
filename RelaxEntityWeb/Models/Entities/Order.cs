using System;
using System.Collections.Generic;

namespace RelaxEntityWeb.Models.Entities;

public partial class Order
{
    public Order()
    {

    }
    public Order(int count, string clientId, int eventId, string status, DateTime date)
    {
        Count = count;
        ClientId = clientId;
        EventId = eventId;
        Status = status;
        Date = date;
    }
    public int Id { get; set; }

    public int Count { get; set; }

    public int? EventId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? Date { get; set; }

    public string ClientId { get; set; } = null!;

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual Event? Event { get; set; }

    public override string ToString()
    {
        return string.Format("{0} {1} {2} {3} {4} {5}", Id, Count, ClientId, EventId, Status, Date);
    }
}

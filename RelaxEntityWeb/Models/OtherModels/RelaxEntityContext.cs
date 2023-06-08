using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RelaxEntityWeb.Models.Entities;

namespace RelaxEntityWeb.Models.OtherModels;

public partial class RelaxEntityContext : DbContext
{
    public RelaxEntityContext()
    {
    }

    public RelaxEntityContext(DbContextOptions<RelaxEntityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Programm> Programms { get; set; }

    public virtual DbSet<ProjectManager> ProjectManagers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Encrypt=True; Database=Relax Entity; Integrated Security=True; TrustServerCertificate=True; Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Client__A9D10535554EFD1E");

            entity.ToTable("Client");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3213E83FA3DCA6C1");

            entity.ToTable("Event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountCurrent).HasColumnName("count_current");
            entity.Property(e => e.CountMax).HasColumnName("count_max");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.PmId).HasColumnName("PM_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Location).WithMany(p => p.Events)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_FK2");

            entity.HasOne(d => d.Pm).WithMany(p => p.Events)
                .HasForeignKey(d => d.PmId)
                .HasConstraintName("event_FK1");

            entity.HasOne(d => d.Program).WithMany(p => p.Events)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("ebent_FK3");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3213E83FD92314E5");

            entity.ToTable("Location");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capaciousness).HasColumnName("capaciousness");
            entity.Property(e => e.Equipment)
                .HasColumnType("text")
                .HasColumnName("equipment");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Organization)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("organization");

            entity.HasOne(d => d.OrganizationNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.Organization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F2C99B1E5");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("client");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("order_FK1");

            entity.HasOne(d => d.Event).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("order_FK2");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__Organiza__72E12F1A957C69EA");

            entity.ToTable("Organization");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
        });

        modelBuilder.Entity<Programm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Program__3213E83F1B7A0BF8");

            entity.ToTable("Programm");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Organization).HasColumnName("organization");

            entity.HasOne(d => d.OrganizationNavigation)
                .WithMany(p => p.Programms)
                .HasForeignKey(d => d.Organization)
                .HasConstraintName("FK1_Program");
        });

        modelBuilder.Entity<ProjectManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectM__3213E83FD429F81A");

            entity.ToTable("ProjectManager");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Client)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("client");
            entity.Property(e => e.Organization)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("organization");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.ProjectManagers)
                .HasForeignKey(d => d.Client)
                .HasConstraintName("PM_FK1");

            entity.HasOne(d => d.OrganizationNavigation).WithMany(p => p.ProjectManagers)
                .HasForeignKey(d => d.Organization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

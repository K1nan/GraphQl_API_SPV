using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GPL.DBModels;

public partial class PersonDataContext : DbContext
{
    public PersonDataContext()
    {
    }

    public PersonDataContext(DbContextOptions<PersonDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonInfo> PersonInfos { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-P6DCIL3L;Initial Catalog=ProductData;uid=sa;password=sql;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Tbl_Person");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Pn).HasMaxLength(50);

        });

        modelBuilder.Entity<PersonInfo>(entity =>
        {
            entity.ToTable("Tbl_PersonInfo");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FirstName);
            entity.Property(e => e.LastName);
            entity.Property(e => e.Fom);
            entity.Property(e => e.Tom);
            entity.Property(e => e.TotalDays);
            entity.Property(e => e.Salary);

            entity.HasOne(d => d.PersonId)
                .WithMany(p => p.PersonInfos)
                .HasForeignKey(d => d.Id)
                 .HasConstraintName("FK_Tbl_Person_Tbl_PersonInfo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

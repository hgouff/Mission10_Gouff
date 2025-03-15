using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission10_Gouff.Models;

// Bowling league context inherits from Db Context
public partial class BowlingLeagueContext : DbContext
{
    public BowlingLeagueContext()
    {
    }

    // Constructor that initializes the BowlingLeagueContext with the provided options.
    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options)
    {
    }

    //Use the bowlers table
    public virtual DbSet<Bowler> Bowlers { get; set; }

    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>(entity =>
        {
            entity.HasIndex(e => e.BowlerLastName, "BowlerLastName");

            entity.HasIndex(e => e.TeamID, "BowlersTeamID");

            entity.Property(e => e.BowlerID)
                .HasColumnType("INT")
                .HasColumnName("BowlerID");
            entity.Property(e => e.BowlerAddress).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerCity).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerFirstName).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerLastName).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerMiddleInit).HasColumnType("nvarchar (1)");
            entity.Property(e => e.BowlerPhoneNumber).HasColumnType("nvarchar (14)");
            entity.Property(e => e.BowlerState).HasColumnType("nvarchar (2)");
            entity.Property(e => e.BowlerZip).HasColumnType("nvarchar (10)");
            entity.Property(e => e.TeamID)
                .HasColumnType("INT")
                .HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Bowlers).HasForeignKey(d => d.TeamID);
        });

        //use the teams table
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasIndex(e => e.TeamID, "TeamID").IsUnique();

            entity.Property(e => e.TeamID)
                .HasColumnType("INT")
                .HasColumnName("TeamID");
            entity.Property(e => e.CaptainID)
                .HasColumnType("INT")
                .HasColumnName("CaptainID");
            entity.Property(e => e.TeamName).HasColumnType("nvarchar (50)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

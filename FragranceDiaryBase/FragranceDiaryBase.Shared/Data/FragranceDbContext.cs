using FragranceDiaryBase.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace FragranceDiaryBase.Shared.Data;

public class FragranceDbContext : DbContext
{
    public FragranceDbContext(DbContextOptions<FragranceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Perfume> Perfumes => Set<Perfume>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Note> Notes => Set<Note>();
    public DbSet<PerfumeNote> PerfumeNotes => Set<PerfumeNote>();
    public DbSet<VibeTag> VibeTags => Set<VibeTag>();
    public DbSet<WearEntry> WearEntries => Set<WearEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Example relationship configs (conventions would mostly handle this,
        // but it's nice to be explicit).

        modelBuilder.Entity<PerfumeNote>()
            .HasOne(pn => pn.Perfume)
            .WithMany(p => p.Notes)
            .HasForeignKey(pn => pn.PerfumeId);

        modelBuilder.Entity<PerfumeNote>()
            .HasOne(pn => pn.Note)
            .WithMany()
            .HasForeignKey(pn => pn.NoteId);

        modelBuilder.Entity<VibeTag>()
            .HasOne(v => v.Perfume)
            .WithMany(p => p.Vibes)
            .HasForeignKey(v => v.PerfumeId);

        modelBuilder.Entity<WearEntry>()
            .HasOne(w => w.Perfume)
            .WithMany()
            .HasForeignKey(w => w.PerfumeId);
    }
}

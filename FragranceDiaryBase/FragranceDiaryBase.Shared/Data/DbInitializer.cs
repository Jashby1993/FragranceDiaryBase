using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FragranceDiaryBase.Shared.Models;

namespace FragranceDiaryBase.Shared.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FragranceDbContext context)
        {
            // If there are already perfumes, assume we've seeded before
            if (context.Perfumes.Any())
            {
                return;
            }

            // Create a sample brand
            var brand = new Brand
            {
                Name = "Sample Brand"
            };
            context.Brands.Add(brand);
            context.SaveChanges();

            // Create a sample perfume
            var perfume = new Perfume
            {
                Name = "Sample Vanilla Oud",
                BrandId = brand.Id,
                VolumeMl = 50, // will be SizeTag = Small
                PhotoPath = null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.Perfumes.Add(perfume);
            context.SaveChanges();

            // Add a couple of notes
            var vanilla = new Note { Name = "Vanilla" };
            var oud = new Note { Name = "Oud" };
            context.Notes.AddRange(vanilla, oud);
            context.SaveChanges();

            context.PerfumeNotes.AddRange(
                new PerfumeNote
                {
                    PerfumeId = perfume.Id,
                    NoteId = vanilla.Id,
                    NoteType = NoteType.Heart
                },
                new PerfumeNote
                {
                    PerfumeId = perfume.Id,
                    NoteId = oud.Id,
                    NoteType = NoteType.Base
                });

            // Add a vibe
            context.VibeTags.Add(new VibeTag
            {
                PerfumeId = perfume.Id,
                Text = "Great date night"
            });

            context.SaveChanges();
        }
    }
}

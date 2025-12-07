using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FragranceDiaryBase.Shared.Models;

public class Perfume
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;

    /// <summary>
    /// Bottle volume in milliliters (ml).
    /// </summary>
    public int VolumeMl { get; set; }

    /// <summary>
    /// Computed size tag based on VolumeMl.
    /// </summary>
    public BottleSizeTag SizeTag =>
        VolumeMl < 3 ? BottleSizeTag.Sample :
        VolumeMl <= 12 ? BottleSizeTag.Travel :
        VolumeMl <= 35 ? BottleSizeTag.Mini :
        VolumeMl <= 50 ? BottleSizeTag.Small :
                         BottleSizeTag.Full;

    public List<PerfumeNote> Notes { get; set; } = new();

    public List<VibeTag> Vibes { get; set; } = new();

    [Required]
    public GenderProfile GenderProfile { get; set; } = GenderProfile.PerfectUnisex;

    /// <summary>
    /// Path or URL to the perfume photo.
    /// </summary>
    public string? PhotoPath { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
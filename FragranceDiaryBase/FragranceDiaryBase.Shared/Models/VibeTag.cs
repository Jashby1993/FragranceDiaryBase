using FragranceDiaryBase.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

public class VibeTag
{
    public int Id { get; set; }

    public int PerfumeId { get; set; }
    public Perfume Perfume { get; set; } = null!;

    public string Text { get; set; } = string.Empty; // "Great date night", etc.
}

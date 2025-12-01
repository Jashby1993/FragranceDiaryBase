using System;
using System.Collections.Generic;
using System.Text;

namespace FragranceDiaryBase.Shared.Models;

public class WearEntry
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int PerfumeId { get; set; }
    public Perfume Perfume { get; set; } = null!;

    /// <summary>
    /// Why she wore it that day (free text).
    /// </summary>
    public string? Why { get; set; }

    /// <summary>
    /// Optional extra context (weather, mood, occasion details, etc.).
    /// </summary>
    public string? Context { get; set; }
}

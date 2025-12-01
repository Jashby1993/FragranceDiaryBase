using System;
using System.Collections.Generic;
using System.Text;

namespace FragranceDiaryBase.Shared.Models;

public class PerfumeNote
{
    public int Id { get; set; }

    public int PerfumeId { get; set; }
    public Perfume Perfume { get; set; } = null!;

    public int NoteId { get; set; }
    public Note Note { get; set; } = null!;

    public NoteType NoteType { get; set; } // Top, Heart, Base
}
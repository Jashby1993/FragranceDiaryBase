using System.Text.Json.Serialization;

namespace FragranceDiaryBase.Shared.Models;

public class PerfumeNote
{
    public int Id { get; set; }

    public int PerfumeId { get; set; }

    [JsonIgnore]
    public Perfume Perfume { get; set; } = null!;  // <-- ignore this in JSON

    public int NoteId { get; set; }
    public Note Note { get; set; } = null!;

    public NoteType NoteType { get; set; }  // Top / Heart / Base
}

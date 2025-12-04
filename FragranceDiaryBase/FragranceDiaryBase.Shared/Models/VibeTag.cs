using System.Text.Json.Serialization;

namespace FragranceDiaryBase.Shared.Models;

public class VibeTag
{
    public int Id { get; set; }

    public int PerfumeId { get; set; }

    [JsonIgnore]
    public Perfume Perfume { get; set; } = null!;  // <-- ignore this too

    public string Text { get; set; } = string.Empty; // "Great date night", etc.
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FragranceDiaryBase.Shared.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Perfume> Perfumes { get; set; } = new();
}
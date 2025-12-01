using System;
using System.Collections.Generic;
using System.Text;

namespace FragranceDiaryBase.Shared.Models;
public class Note
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // e.g. "Vanilla", "Oud"
}
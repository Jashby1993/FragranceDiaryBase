using System;
using System.Collections.Generic;
using System.Text;

namespace FragranceDiaryBase.Shared.Models;

public enum BottleSizeTag
{
    Sample, // < 3 ml
    Travel, // <= 12 ml
    Mini,   // <= 35 ml
    Small,  // <= 50 ml
    Full    // > 50 ml
}

public enum NoteType
{
    Top,
    Heart,
    Base
}

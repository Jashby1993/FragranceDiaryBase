using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FragranceDiaryBase.Shared.Models
{
    public enum GenderProfile
    {
        [Display(Name = "Feminine Leaning")]
        FeminineLeaning,

        [Display(Name = "Masculine Leaning")]
        MasculineLeaning,

        [Display(Name = "Perfect Unisex")]
        PerfectUnisex

    }
}

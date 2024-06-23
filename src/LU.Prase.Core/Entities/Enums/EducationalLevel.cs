using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Entities.Enums
{
    public enum EducationalLevel
    {
        M2R,
        [Display(Name = "PHD Cotutelle")]
        PHDCotutelle,
        [Display(Name = "PHD Codirection")]
        PHDCodirection
    }
}

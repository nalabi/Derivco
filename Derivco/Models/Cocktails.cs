using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derivco.Models
{
    public class Cocktails {


        [Required]
        public string[] drinks { get; set; }

        [Required]

        public string strDrink { get; set; }

        public string strDrinkAlternative { get; set; }

        [Required]
        public string strTags { get; set; }

        public string strVideo { get; set; }

        [Required]
        public string strCategory { get; set; }

        [Required]
        public string strIBA { get; set; }

        [Required]

        public string strAlcoholic { get; set; }

        [Required]
        public string strGlass { get; set; }

        public string strInstructions { get; set; }

        public string atrDrinkThumb { get; set; }


        public string strDrinkThumb { get; set; }

        public string strIngredient1to15 {get; set;}


   

public string strImageSource { get; set; }

public string strImageAttribution { get; set; }

public string strCreativeCommonsConfirmed { get; set; }


public string dateModified { get; set; }

    }
}

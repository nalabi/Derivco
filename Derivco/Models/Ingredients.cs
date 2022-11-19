using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derivco.Models
{
    public class Ingredients
    {


        [Required]
        public string idIngredient { get; set; }
        public string strIngredient { get; set; }

        public string strDescription { get; set; }

        public string strType { get; set; }

        [Required]
        public string strAlcohol { get; set; }

        [Required]

        public string strABV { get; set; }

    }
}

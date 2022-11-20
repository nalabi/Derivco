using Newtonsoft.Json;
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
        [JsonProperty("idIngredient")]
        public string idIngredient { get; set; }

        [JsonProperty("strIngredient")]
        public string strIngredient { get; set; }

        [JsonProperty("strDescription")]

        public string strDescription { get; set; }

        [JsonProperty("strType")]
        public string strType { get; set; }

        [Required]
        [JsonProperty("strAlcohol")]
        public string strAlcohol { get; set; }

        [Required]
        [JsonProperty("strABV")]
        public string strABV { get; set; }

    }
}

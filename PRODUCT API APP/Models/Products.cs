using System.ComponentModel.DataAnnotations;

namespace PRODUCT_API_APP.Models
{
    public class Products
    {
        [Key]
        public int id {  get; set; }

        public string p_name { get; set; }
       
        public string p_description { get; set;}

        public int p_price { get; set;}
    
    }
}

using System.ComponentModel.DataAnnotations;
namespace POS2.Model
{
    public class menuitem
    {
        [Key]
        public int ItemCode { get; set; }

        public string ItemName { get; set; }

        public float UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
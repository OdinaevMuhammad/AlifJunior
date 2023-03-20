using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string PhoneNumber { get; set; }
        public InstallmentRange InstallmentRange { get; set; }
        public double Percent { get; set; }
        public DateTime StartDate { get; set; }
        public double ProductAmount { get; set; }

    }
    public enum ProductCategory
    {
        Smartphone,
        Computer,
        TV
    };
    public enum InstallmentRange
    {
        Three = 3,
        Six = 6,
        Nine = 9,
        Twelve = 12,
        Eighteen = 18,
        TwentyFour = 24
    };
}
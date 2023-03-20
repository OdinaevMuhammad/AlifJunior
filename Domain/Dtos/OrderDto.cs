using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Dtos
{
    public class OrderDto
    {

        public ProductCategory ProductCategory { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public InstallmentRange InstallmentRange { get; set; }


    }
}
using Management.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }
        public string? Genre { get; set; }
        public int? Age { get; set; }
        public string?  Identification { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }


}

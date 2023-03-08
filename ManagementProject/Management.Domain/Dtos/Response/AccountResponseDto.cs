using Management.Domain.Dtos.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Dtos.Response
{
    public class AccountResponseDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ClientShortDto Client { get; set; }
    }
}

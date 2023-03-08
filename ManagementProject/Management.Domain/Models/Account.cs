using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class Account : EntityBase
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public bool Status { get; set; }
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }
    }
}

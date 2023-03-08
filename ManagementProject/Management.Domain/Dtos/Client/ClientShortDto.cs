using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Dtos.Client
{
    public class ClientShortDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public bool Status { get; set; }
    }
}

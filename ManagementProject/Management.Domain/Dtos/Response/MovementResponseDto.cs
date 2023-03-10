using Management.Domain.Dtos.Account;
using Management.Domain.Dtos.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Dtos.Response
{
    public class MovementResponseDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public int InitialBalance { get; set; }
        public bool State { get; set; }
        public string Movement { get; set; }
        public int FinalBalance { get; set; }
        public string Description { get; set; }


    }
}

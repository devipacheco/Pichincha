using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Others.Result
{
    public class ResultadoAccion
    {
        public bool Correcto { get; }
        public string Mensaje { get; }
        public int Id { get; set; }

        public ResultadoAccion(bool pCorrecto, string pMensaje, int pId = 0)
        {
            Correcto = pCorrecto;
            Mensaje = pMensaje;
            Id = pId;
        }
    }
}

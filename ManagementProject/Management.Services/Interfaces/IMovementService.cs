using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Services.Interfaces
{
    public interface IMovementService : IGenericService<Movement>
    {
        Task<Movement> GetByIdClient(int Id);
        Task<Movement> GetByDates(DateTime startDate, DateTime EndDate);
        Task<Movement> GetByClientAndDates(int Id, DateTime startDate, DateTime EndDate);

    }
}

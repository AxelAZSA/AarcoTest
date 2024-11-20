using AarcoExamen.Domain.DTOs;
using AarcoExamen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AarcoExamen.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Dashboard>> GetDashboardData(int filterType, string filterValue);
    }


}

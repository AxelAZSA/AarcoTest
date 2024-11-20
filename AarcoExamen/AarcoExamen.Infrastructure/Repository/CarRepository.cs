using AarcoExamen.Domain.DTOs;
using AarcoExamen.Domain.Entities;
using AarcoExamen.Domain.Interfaces;
using AarcoExamen.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AarcoExamen.Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDatabaseContext _context;

        public CarRepository(CarDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dashboard>> GetDashboardData(int filterType, string filterValue)
        {
            var query = _context.Marcas
                .Include(m => m.Submarcas)
                    .ThenInclude(s => s.Modelos)
                .AsQueryable();

            switch (filterType)
            {
                case 1: // Filtro por Marca
                    query = query.Where(m => m.Nombre.Contains(filterValue));
                    break;
                case 2: // Filtro por Submarca
                    query = query.Where(m => m.Submarcas.Any(s => s.Nombre.Contains(filterValue)));
                    break;
                case 3: // Filtro por Modelo
                    if (int.TryParse(filterValue, out int anio))
                    {
                        query = query.Where(m => m.Submarcas.Any(s => s.Modelos.Any(mo => mo.Anio == anio)));
                    }
                    break;
                case 4: // Filtro por Descripción
                    query = query.Where(m => m.Submarcas.Any(s => s.Modelos.Any(mo => mo.Descripcion.Detalle.Contains(filterValue))));
                    break;
                default:
                    throw new ArgumentException("filterType no válido");
            }

            // Proyección del resultado
            var result = await query.SelectMany(m => m.Submarcas.SelectMany(s => s.Modelos.Select(mo => new Dashboard
            {
                Marca = m.Nombre,
                Submarca = s.Nombre,
                Modelo = mo.Anio.ToString(),
                Descripcion = mo.Descripcion.Detalle
            }))).ToListAsync();

            return result;
        }

    }

}

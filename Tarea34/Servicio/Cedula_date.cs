using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea34.Data;
using Tarea34.Models;

namespace Tarea34.Servicio
{
    public class Cedula_date : ICedulaServicies
    {
        private readonly ApplicationDbContext _context;
        public Cedula_date(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<cedula[]> GetIncompleteItemsAsync()
        {

            var items = await _context.Ced
                .Where(x => x.Ok == true)
                .ToArrayAsync();
            return items;
        }

        public async Task<bool> AddItemAsync(cedula newItem, String correo, String telefono)
        {

            newItem.correo = correo;
            newItem.telefono = telefono;
            _context.Ced.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}

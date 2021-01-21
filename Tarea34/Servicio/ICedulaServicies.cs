using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea34.Models;

namespace Tarea34.Servicio
{
    public interface ICedulaServicies
    {
        Task<cedula[]> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(cedula newItem, String correo, String telefono);
    }
}

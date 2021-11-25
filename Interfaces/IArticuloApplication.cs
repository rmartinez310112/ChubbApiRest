using ReneMartinez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReneMartinez.Interfaces
{
    public interface IArticuloApplication
    {
        public Task<List<Articulo>> ObtenerArticulosAsync();
        public Task<Articulo> ObtenerArticuloAsync(int artiucloId);
        public Task<int> AgregarArticuloAsync(ArticuloDTO articulo);
        public Task<Articulo> ActualizarArticuloAsync(Articulo articulo, int articuloId);
        public Task<bool> EliminarArticuloAsync(int articuloId);
       
    }
}

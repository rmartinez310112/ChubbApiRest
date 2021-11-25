using ReneMartinez.Interfaces;
using ReneMartinez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReneMartinez.Application
{
    public class ArticuloApplication : IArticuloApplication
    {
        private IListaArticulos _lstArticulos;

        public ArticuloApplication(IListaArticulos lstArticulos)
        {
            _lstArticulos = lstArticulos;
        }

        public async Task<List<Articulo>> ObtenerArticulosAsync()
        {
            try
            {
                return Task.Run(() => _lstArticulos.Articulos).Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error obtener lista: {ex.Message}");
            }
        }

        public async Task<Articulo> ObtenerArticuloAsync(int articuloId)
        {
            try
            {
                var response = Task.Run(() => _lstArticulos.Articulos.FirstOrDefault(p =>
                                                                        p.ArticuloId == articuloId)).Result;

                return response != null ? response :
                    throw new ApplicationException($"No se encontró el articulo: {articuloId}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error obtener: {ex.Message}");
            }
        }

        public async Task<int> AgregarArticuloAsync(ArticuloDTO articulo)
        {
            try
            {
                var siguienteId = _lstArticulos.Articulos.Count() > 0 ? _lstArticulos.Articulos.Max(p => p.ArticuloId) : 0;

                _lstArticulos.Articulos.Add(new Articulo
                {
                    ArticuloId = siguienteId + 1,
                    Cantidad = articulo.Cantidad,
                    Categoria = articulo.Categoria,
                    Descripcion = articulo.Descripcion,
                    Nombre = articulo.Nombre,
                    Precio = articulo.Precio
                });

                return _lstArticulos.Articulos.LastOrDefault(p => p != null).ArticuloId;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error Agregar: {ex.Message}");
            }
        }

        public async Task<Articulo> ActualizarArticuloAsync(Articulo articulo, int articuloId)
        {
            try
            {
                var nuevaLista = Task.Run(() => _lstArticulos.Articulos.Where(p => p.ArticuloId != articuloId));
                _lstArticulos.Articulos = nuevaLista.Result.ToList();
                _lstArticulos.Articulos.Add(articulo);
                return _lstArticulos.Articulos.FirstOrDefault(p => p.ArticuloId == articulo.ArticuloId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error actualizar: {ex.Message}");
            }
        }

        public async Task<bool> EliminarArticuloAsync(int articuloId)
        {
            try
            {
                var listaNueva = Task.Run(() => _lstArticulos.Articulos.Where(p => p.ArticuloId != articuloId));
                _lstArticulos.Articulos = listaNueva.Result.ToList();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error eliminar: {ex.Message}");
            }
        }


    }
}

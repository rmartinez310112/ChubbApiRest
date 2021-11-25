using ReneMartinez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReneMartinez.Interfaces
{
    public interface IListaArticulos
    {
        public List<Articulo> Articulos { get; set; }
    }
}

using ReneMartinez.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReneMartinez.Models
{
    public class Persistencia : IListaArticulos
    {
        private List<Articulo> articulos;
        public List<Articulo> Articulos
        {
            get
            {
                if (articulos == null)
                    articulos = new List<Articulo>();
                return articulos;
            }

            set { articulos = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peli.Domain.entities;

namespace Peli.Infraestructure.Repositories
{
    public class PeliRepository
    {
        public static List<Pelicula> _pelis = new List<Pelicula>();

        public IEnumerable<Pelicula> GetTodasPeliculas()
        {
            return _pelis;
        }
        public Pelicula ObtenerId(int id)
        {
            var pelis = _pelis.Where(peli => peli.IdPeli == id);
            return pelis.FirstOrDefault();
        }
        /*public IEnumerable<Pelicula> ObtenerDirector(string director)
        {
            //var peli = _pelis.Where(peli => peli.IddirectorPeli == director);
            return peli;
        }*/
        public void CrearPelicula (Pelicula nuevaPeli)
        {
            _pelis.Add(nuevaPeli);
        } 
        /*public void ActualizarPelicula (int id, Pelicula actualizarPelicula)
        {
            if (id <= 0 || actualizarPelicula == null)
            {
                throw new ArgumentException("Llena todos los campos");
            }
            var entity = ObtenerId(id);
            entity.tituloPeli = actualizarPelicula.tituloPeli;
            entity.directorPeli = actualizarPelicula.directorPeli;
            entity.generoPeli = actualizarPelicula.generoPeli;
            entity.puntuacionPeli = actualizarPelicula.puntuacionPeli;
            entity.ratingPeli = actualizarPelicula.ratingPeli;
            entity.añopPeli = actualizarPelicula.añopPeli;
            _pelis.Remove(entity);
            _pelis.Add(entity);
        }*/
        public void BorrarPelicula (int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("No hay existe ninguna película con el id que ingresaste");
            }
            var final = ObtenerId(id);
            _pelis.Remove(final);
        }
    }
}
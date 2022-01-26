using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peli.Domain.entities;
using Peli.Infraestructure.Data;

namespace Peli.Infraestructure.Repositories
{
    public class PeliSqlRepository
    {
        private readonly PeliculasContext _context;

        public PeliSqlRepository()
        {
            _context = new PeliculasContext();
        }

        public IEnumerable<Pelicula> GetTodasPeliculas()
        {
            return _context.Peliculas;
        }

        public Pelicula ObtenerId(int id)
        {
            var pelis = _context.Peliculas.Where(peli => peli.IdPeli == id);
            return pelis.FirstOrDefault();
        }

        public IEnumerable<Pelicula> ObtenerDirector(string director)
        {
            var peli = _context.Peliculas.Where(peli => peli.DirectorPeli == director);
            return peli;
        }

        public void CrearPelicula (Pelicula nuevaPeli)
        {
            var entity = nuevaPeli;
            _context.Peliculas.Add(entity);
            var rows = _context.SaveChanges();
            if(rows <= 0)
            throw new Exception("No se pudo registrar la película");
            return;
        } 

        public void ActualizarPelicula (int id, Pelicula actualizarPelicula)
        {
            if (id <= 0 || actualizarPelicula == null)
            {
                throw new ArgumentException("Llena todos los campos");
            }
            var entity = ObtenerId(id);
            entity.TituloPeli = actualizarPelicula.TituloPeli;
            entity.DirectorPeli = actualizarPelicula.DirectorPeli;
            entity.GeneroPeli = actualizarPelicula.GeneroPeli;
            entity.PuntuacionPeli = actualizarPelicula.PuntuacionPeli;
            entity.RatingPeli = actualizarPelicula.RatingPeli;
            entity.AñopPeli = actualizarPelicula.AñopPeli;
            _context.Update(entity);
            var rows = _context.SaveChanges();
            return;
        }

        public void BorrarPelicula (int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("No hay existe ninguna película con el id que ingresaste");
            }
            var entity = ObtenerId(id);
            _context.Remove(entity);
            var rows = _context.SaveChanges();
            return;
        }
    }
}
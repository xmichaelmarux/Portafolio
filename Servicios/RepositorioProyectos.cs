using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }
    public class RepositorioProyectos: IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {

                Titulo = "Amazon",
                Descripcion = "ejemplo1",
                Link = "https://amazon.com",
                ImagenURL = "/img/lobo the witcher.jpg"
                },
                new Proyecto
                {

                Titulo = "Amazon",
                Descripcion = "ejemplo2",
                Link = "https://amazon.com",
                ImagenURL = "/img/lobo the witcher.jpg"
                },
                new Proyecto
                {

                Titulo = "Amazon",
                Descripcion = "ejemplo3",
                Link = "https://amazon.com",
                ImagenURL = "/img/lobo the witcher.jpg"
                },
                new Proyecto
                {

                Titulo = "Amazon",
                Descripcion = "ejemplo4",
                Link = "https://amazon.com",
                ImagenURL = "/img/lobo the witcher.jpg"
                }
            };
        }
    }
}

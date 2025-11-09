using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityBack.Domain.Entities
{
    public class Empresa
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }

        //relacion
        public ICollection<Oferta> Ofertas { get; set; }
    }
}

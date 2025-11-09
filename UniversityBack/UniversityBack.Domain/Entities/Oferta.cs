using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityBack.Domain.Entities
{
    public class Oferta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Requisitos { get; set; }
        public string Estado { get; set; }

        //relacion
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        public ICollection<Postulacion> Postulaciones { get; set; }
    }
}

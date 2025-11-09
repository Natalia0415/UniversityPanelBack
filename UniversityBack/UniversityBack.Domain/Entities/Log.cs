using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityBack.Domain.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string IP { get; set; }

        public int PostulacionId { get; set; }
        public Postulacion Postulacion { get; set; }
    }
}

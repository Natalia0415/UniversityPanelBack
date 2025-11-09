using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityBack.Domain.Entities
{
    public class Postulacion
    {
        public int Id { get; set; }
        public int OfertaId { get; set; }
        public Oferta Oferta { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime Fecha_Postulacion { get; set; }
        public string Estado { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}

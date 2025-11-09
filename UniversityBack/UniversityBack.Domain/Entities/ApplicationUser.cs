using Microsoft.AspNetCore.Identity;

namespace UniversityBack.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Postulacion> Postulaciones { get; set; }
    }
}

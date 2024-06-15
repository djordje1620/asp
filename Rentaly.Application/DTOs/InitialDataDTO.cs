using Rentaly.Domain.Entities;

namespace Rentaly.Application.DTOs
{
    public class InitialDataDTO
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<CarType> CarTypes { get; set; }
        public IEnumerable<Specification> Specifications { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<CarAccessory> Accessories { get; set; }
    }
}

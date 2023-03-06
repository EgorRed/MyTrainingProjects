using System;

namespace EntityFrameworkTest
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Yers { get; set; }
        public int CityId { get; set; }
        public virtual City Cities { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EntityFrameworkTest
{
    class Program
    {
        //test function
        public static List<City> GetListCities()
        {
            List<City> cities = new List<City>
                {
                    new City() { Name = "New York",},
                    new City() { Name = "Los Angeles"},
                    new City() { Name = "Chicago"},
                    new City() { Name = "Houston"}
                };
            return cities;
        }


        //test function
        public static List<User> GetListUsers(in List<City> cities)
        {
            Random rand = new Random();
            int citiesCount = cities.Count;
            List<User> users = new List<User>
                {
                    new User() { Name = "Henry",    Yers = 18,  CityId = cities[0].Id},
                    new User() { Name = "Dale",     Yers = 17,  CityId = cities[1].Id},
                    new User() { Name = "Randall",  Yers = 19,  CityId = cities[2].Id},
                    new User() { Name = "Brian",    Yers = 18,  CityId = cities[3].Id},
                    new User() { Name = "Thomas",   Yers = 20,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Roger",    Yers = 21,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Charles",  Yers = 18,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Jack",     Yers = 27,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Jose",     Yers = 31,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Kenneth",  Yers = 23,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Randy",    Yers = 18,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Don",      Yers = 22,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "John",     Yers = 16,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Michael",  Yers = 14,  CityId = cities[rand.Next(citiesCount)].Id},
                    new User() { Name = "Bobby",    Yers = 24,  CityId = cities[rand.Next(citiesCount)].Id},

                };
            return users;
        }

        static void Main(string[] args)
        {           

            using (var context = new MyDbContext())
            {

                var cities = GetListCities();
                context.Cities.AddRange(cities);
                context.SaveChanges(); //saving to the database

                var users = GetListUsers(cities);
                context.Users.AddRange(users);
                context.SaveChanges(); //saving to the database

                foreach (var user in users)
                {
                    Console.WriteLine($"id: {user.Id} \t name: {user.Name} \t city: {user.Cities?.Name}");
                }
                //Console.WriteLine($"id: {city.Id}, name: {city.Name}");
                Console.ReadLine();
            }
        }
    }
}

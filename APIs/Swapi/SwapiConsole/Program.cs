using System;
using System.Net.Http;
using Models;

namespace SwapiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.GetAsync("https://swapi.dev/api/people/1").Result;

            if(response.IsSuccessStatusCode)
            {
                System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Person person = response.Content.ReadAsAsync<Person>().Result;

                System.Console.WriteLine(person.Name);
                Console.WriteLine(person.HairColor);

                foreach(string vehicleUrl in person.Vehicles)
                {
                    Vehicle vehicle = httpClient.GetAsync(vehicleUrl).Result.Content.ReadAsAsync<Vehicle>().Result;
                    Console.WriteLine(vehicle.Name);
                }
            }


            Console.ReadKey();
        }
    }
}

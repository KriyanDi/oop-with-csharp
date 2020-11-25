using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob2
{
    class Program
    {
        #region Fields
        //Sample data
        private static City[] cities =
        {
            new City(){ContinentName ="Europe", CountryName="Germany", CityName="Berlin" },
            new City(){ContinentName ="Europe", CountryName="Germany", CityName="Frankfurt" },
            new City(){ContinentName ="Europe", CountryName="France", CityName="Paris" },
            new City(){ContinentName ="Europe", CountryName="France", CityName="Marseille" },
            new City(){ContinentName ="Asia", CountryName="Japan", CityName="Tokyo" },
            new City(){ContinentName ="Asia", CountryName="Korea", CityName="Seul" }
        };
        #endregion

        static void Main(string[] args)
        {
            GroupByContinentThenGroupByCitiesPerCountryThenDisplay(cities);
        }

        #region Methods
        static private void GroupByContinentThenGroupByCitiesPerCountryThenDisplay(City[] arrayOfCities)
        {
            //result
            var result = arrayOfCities
                .GroupBy(city => city.ContinentName)
                .Select(continent => new
                {
                    ContinentName = continent.Key,
                    Countries = continent
                    .GroupBy(city => city.CountryName)
                    .Select(country => new
                    {
                        CountryName = country.Key,
                        Cities = country
                        .Select(city => city.CityName)
                    })
                });

            //display
            foreach (var continent in result)
            {
                Console.WriteLine($"{continent.ContinentName}");
                foreach (var countries in continent.Countries)
                {
                    Console.WriteLine($"\t {countries.CountryName}");
                    foreach (var city in countries.Cities)
                    {
                        Console.WriteLine($"\t\t {city}");
                    }
                }
            }
        } 
        #endregion
    }
}

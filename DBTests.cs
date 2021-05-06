using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using CsvHelper.Configuration;
using lab6;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization.Internal;
using Npgsql;
using Xunit;
namespace Tests
{


    public class DBTests
    {
        public String ConnectionString;

        public DBTests()
        {

            ConnectionString = "Host=localhost;Database=lab6;Username=postgres;Password=1111";
        }

        [Fact]
        public void DbTest1()
        {
            string sqlExpression = "SELECT * FROM Cities ORDER BY Location DESC";

            using (var db = new lab6Context())
            {
                var cities = db.Cities.ToList();
                var logs = new List<City>();
                
                CsvHandler<City>.CsvEx(cities,"/Users/vladimir/Desktop/test.csv");
                var records = CsvHandler<City>.ReadCsv("/Users/vladimir/Desktop/expected result.csv");
                for (int i = 0; i < cities.Count; i++)
                {
                    if (cities[i].Location !=records[i].Location || cities[i].Name !=records[i].Name)
                    {
                        logs.Add(cities[i]);
                    }
                }
                CsvHandler<City>.CsvEx(logs,"/Users/vladimir/Desktop/log.csv");
                Assert.Empty(logs);
            }
        }
        [Fact]
        public void DbTest2()
        {
            string sqlExpression = "SELECT * FROM Weather GROUP BY temp_lo";

            using (var db = new lab6Context())
            {
                var cities = db.Cities.ToList();
                var logs = new List<City>();
                
                CsvHandler<City>.CsvEx(cities,"/Users/vladimir/Desktop/test.csv");
                var records = CsvHandler<City>.ReadCsv("/Users/vladimir/Desktop/expected result 2.csv");
                for (int i = 0; i < cities.Count; i++)
                {
                    if (cities[i].Location !=records[i].Location || cities[i].Name !=records[i].Name)
                    {
                        logs.Add(cities[i]);
                    }
                }
                CsvHandler<City>.CsvEx(logs,"/Users/vladimir/Desktop/log 2.csv");
                Assert.Empty(logs);
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using lab6;

namespace Tests
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Map(m => m.Location).Name("Location");
            Map(m => m.Name).Name("Name");
        }
    }
    
    public class CsvHandler<T>
    {
        public static void CsvEx(IList records,string path)
        {

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CityMap>();
                csv.WriteRecords(records);
            }
        }

        public static List<T> ReadCsv(string path)
        {
            var records = new List<T>();
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CityMap>();
                records = csv.GetRecords<T>().ToList();
            }
            return records;
        }
    }
}
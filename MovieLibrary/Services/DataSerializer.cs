using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieLibrary.Models;

namespace MovieLibrary.Services
{
    public class DataSerializer
    {
        static string path = @"C:\Users\DELL\Desktop\Sufyan\AproSCM\MovieLayeredApp\MovieLibrary\Assets\MyMovie.json";
        public static void Serialize(List<Movie> movies)
        {
            string toJson = JsonSerializer.Serialize(movies);
            File.WriteAllText(path, Environment.NewLine + toJson);
        }

        public static List<Movie> Deserialize()
        {
            if (!File.Exists(path))
            {
                return new List<Movie>();
            }
            else
            {
                return JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText(path))!;
            }
        }
    }
}

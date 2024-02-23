using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Roadmap
    {
        private readonly List<string> stops = new()
        {
            "intro",
            "preparation",
            "travelling",
            "preparation",
            "travelling",
        };

        private int stop = 0;

        public void AddStop(string stop) => stops.Add(stop);

        public string NextStop() => stops[stop++];

        public string LastStop() => stops.Last();
    }
}
using System.Collections.Generic;

namespace Models
{
    public class Roadmap
    {
        private List<string> stops = new()
        {
            "intro",
            "preparation",
            "travelling",
            "preparation",
            "travelling",
        };

        private int stop = 0;

        public string NextStop()
        {
            return stops[stop++];
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Roadmap
    {
        private const string Intro = "intro";
        private const string Preparation = "preparation";
        private const string Travelling = "travelling";
        private const string Request = "request";
        private const string Delivery = "delivery";
        private const string End = "end";

        private readonly List<string> stops = new()
        {
            Intro,
            Preparation,
            Travelling,
            Preparation,
            Travelling,

            Request, // A
            Preparation,
            Travelling,
            Delivery, // A

            Preparation,
            Travelling,
            Request, // B
            Preparation,
            Travelling,
            Preparation,
            Travelling,
            Delivery, // B

            Request, // C
            Preparation,
            Travelling,
            Preparation,
            Travelling,

            End
        };

        private int stop = 0;

        public void AddStop(string stop) => stops.Add(stop);

        public string NextStop() => stops[stop++];

        public string LastStop() => stops.Last();
    }
}
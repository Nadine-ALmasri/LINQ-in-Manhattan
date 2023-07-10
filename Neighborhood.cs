using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace LINQ_in_Manhattan
{
    public class Neighborhood
    {
        public class Feature
        {
            public string type { get; set; }
            public Geometry geometry { get; set; }
            public Properties Properties { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }

        public class Properties
        {
            public string zip { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string address { get; set; }
            public string borough { get; set; }
            public string neighborhood { get; set; }
            public string county { get; set; }
        }

        public class FeatureCollection
        {
          
            public List<Feature> Features { get; set; }
        }


        public static void ReadInfo(string jsonFile)
        {
            string json = File.ReadAllText(jsonFile);//
            FeatureCollection featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(json);

            List<Feature> features = featureCollection.Features;

            /// printing all the neighborhood names
            var allNeighborhoods = features.Select(f => f.Properties.neighborhood);
            Console.WriteLine("All Neighborhoods:");
            foreach (var neighborhood in allNeighborhoods)
            {
                Console.WriteLine(neighborhood);
            }
            Console.WriteLine("Final Total: {0} neighborhoods", allNeighborhoods.Count());
            Console.WriteLine("______________________________________________________________________________________________");
            ///filtring and  printing all the named neighborhood 
            var FelterNeighborhoods = features.Where(f => !string.IsNullOrEmpty(f.Properties.neighborhood)).Select(f => f.Properties.neighborhood);
            Console.WriteLine("All The Named Neighborhoods:");


            foreach (var neighborhood in FelterNeighborhoods)
            {
                Console.WriteLine(neighborhood);
            }
            Console.WriteLine("Final Total: {0} Named neighborhoods", FelterNeighborhoods.Count());
            Console.WriteLine("________________________________________________________________________________________________");
            // non duplicating names

            var NonDuplicatedNeighborhoods = FelterNeighborhoods.Distinct();

            Console.WriteLine("Non Duplicated Neighborhoods :");


            foreach (var neighborhood in NonDuplicatedNeighborhoods)
            {
                Console.WriteLine(neighborhood);
            }
            Console.WriteLine("Final Total: {0} Non duplicated neighborhoods", NonDuplicatedNeighborhoods.Count());
            Console.WriteLine("________________________________________________________________________________________________");
            ///Rewrite the queries from above and consolidate all into one single query.
            Console.WriteLine("Rewrite the queries from above and consolidate all into one single query");
            var FinalNeighborhoods = features.Where(f => !string.IsNullOrEmpty(f.Properties.neighborhood)).Select(f => f.Properties.neighborhood).Distinct();
            foreach (var neighborhood in FinalNeighborhoods)
            {
                Console.WriteLine(neighborhood);
            }
            Console.WriteLine("Final Total: {0} Non duplicated neighborhoods", FinalNeighborhoods.Count());
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Rewrite  one of these questions  using the LINQ Query  syntax 1");
            //Rewrite  one of these questions  using the LINQ Query  syntax 1
            var allNeighborhoodsQuerySyntax = from F in features select F.Properties.neighborhood;
            foreach ( var neighborhood in allNeighborhoodsQuerySyntax ) { Console.WriteLine(neighborhood); }
            Console.WriteLine("Final Total: {0} neighborhoods", allNeighborhoodsQuerySyntax.Count());
            Console.WriteLine("________________________________________________________________________________________________");

            Console.WriteLine("________________________________________________________________________________________________");
            Console.WriteLine("Rewrite  one of these questions  using the LINQ Query  syntax 2");
            //Rewrite  one of these questions  using the LINQ Query  syntax 2
            var NonDuplicatedNeighborhoodsQuerySyntax = (from F  in features where !string.IsNullOrEmpty(F.Properties.neighborhood)  
                                                     select F.Properties.neighborhood).Distinct();
            Console.WriteLine("Non Duplicated Neighborhoods :");


            foreach (var neighborhood in NonDuplicatedNeighborhoodsQuerySyntax)
            {
                Console.WriteLine(neighborhood);
            }
            Console.WriteLine("Final Total: {0} Non duplicated neighborhoods", NonDuplicatedNeighborhoodsQuerySyntax.Count());

        }
    }
}

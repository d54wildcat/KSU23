using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Storage_Object_Diagrams_2
{

    class Program
    {
        // example that shows two objects that share a static field
        static void Main()
        {
            Clock c = new Clock(80);
            Clock d = new Clock(90);
            c.tick(2);
            Clock e = d;
            d.tick(3);
            Console.WriteLine(e.getTime());

            // Uncomment this to see de/serialization of c, d, and e
            // serializes values of c, d, and e as mString
            /*
            Dictionary<string, Object> m = new Dictionary<string, Object>();
            m["c"] = c;
            m["d"] = d;
            m["e"] = e;
            JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        ContractResolver = new CustomJsonContractResolver(),
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    };
            string mString = JsonConvert.SerializeObject(
                    m,
                    Formatting.Indented,
                    settings);
            Console.WriteLine(mString);

            // deserialize mString to m2 and then serialize m2 to m2String
            // mString should be equal to m2String
            Dictionary<string, Object> m2 = JsonConvert.DeserializeObject<Dictionary<string, Object>>(mString, settings);
            string m2String = JsonConvert.SerializeObject(
                    m,
                    Formatting.Indented,
                    settings);
            Console.WriteLine(m2String);
            Console.WriteLine(mString == m2String);
            */

            Console.ReadLine();   //*** insert break point at beginning of this line   
        }
    }

    class Clock
    {
        static int count = 0;
        private int t = 0;

        public Clock(int start)
        {
            t = start;
            count = count + 1;
        }

        public void tick(int n)
        {
            //*** insert break point at beginning of next line:
            t = t + n;
        }

        public int getTime()
        {
            return t;
        }
    }
}

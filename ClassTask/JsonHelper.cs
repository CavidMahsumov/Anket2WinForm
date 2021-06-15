using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    public  class JsonFileHelper
    {
        public static void JSONSerialization(Human database,string filename)
        {
            var serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    serializer.Serialize(jsonTextWriter, database);
                }
            }
        }
        public static void JSONDeSerialization(ref Human database,string filename)
        {
            var serializer = new JsonSerializer();

            using (StreamReader streamReader = new StreamReader(filename))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    database = serializer.Deserialize<Human>(jsonTextReader);
                }
            }
        }

    }
}

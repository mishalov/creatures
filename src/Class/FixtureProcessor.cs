using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace CreatureWars.Class
{
    class FixtureProcessor
    {
        private string CreateFixturePath(string fixtureName)
        {
            return AppDomain.CurrentDomain.BaseDirectory + "../../../../src/Fixtures/" + fixtureName + ".json";
        }
        public void Serialize(object toSerialize, string fixtureName)
        {
            JsonSerializer.Serialize(new FileStream(CreateFixturePath(fixtureName), FileMode.OpenOrCreate), toSerialize, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
        }
        public List<T> Deserialize<T>(string fixtureName)
        {
            return JsonSerializer.Deserialize<T[]>(File.ReadAllText(CreateFixturePath(fixtureName))).ToList<T>();
        }
    }
}

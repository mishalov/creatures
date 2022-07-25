using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace CreatureWars.Class
{
    class FixtureProcessor
    {
        private string CreateFixturePath(string fixtureName)
        {
            return AppDomain.CurrentDomain.BaseDirectory + "../../../../src/Fixtures/" + fixtureName + ".json";
        }
        public CreaturePrototype[] CreaturePrototypeDeserialize()
        {
            return JsonSerializer.Deserialize<CreaturePrototype[]>(File.ReadAllText(CreateFixturePath("Creature")));
        }
        public void Serialize(object toSerialize, string fixtureName)
        {
            JsonSerializer.Serialize(new FileStream(CreateFixturePath(fixtureName), FileMode.OpenOrCreate), toSerialize, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
        }
        public AbilityPrototype[] AbilityPrototypeDeserialize()
        {
            return JsonSerializer.Deserialize<AbilityPrototype[]>(File.ReadAllText(CreateFixturePath("Ability")));
        }
    }
}

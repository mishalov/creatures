using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace CreatureWars.Class
{
    class FixturesDeserializer
    {
        public CreaturePrototype[] Deserialize()
        {
            return JsonSerializer.Deserialize<CreaturePrototype[]>(File.ReadAllText("./src/Fixtures/Creature.json"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Declarations
{
    interface INameble
    {
        string Name { get; set; }
        string ProgramName { get; set; }
        string Description { get; set; }
    }
}

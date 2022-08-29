using CreatureWars.Class;
using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatureWars.Class
{
    public class Game
    {
        public readonly IActionAnnouncer Announcer = null;

        private static Game instance;

        private Game(IActionAnnouncer actionAnnouncer)
        {
            Announcer = actionAnnouncer;
        }

        public static Game Init(IActionAnnouncer actionAnnouncer)
        {
            if (instance != null) throw new Exception("Already initialized!");
            instance = new Game(actionAnnouncer);
            return instance;

        }

        public static Game getInstance()
        {
            if (instance == null)
            {
                throw new Exception("Not initialized! Please, use .init before!");
            }

            return instance;
        }
    }
}

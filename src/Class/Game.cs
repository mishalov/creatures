using CreatureWars.Class;
using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class 
{
    class Game
    {
        public readonly IActionAnnouncer Announcer = null;
        private static Game instance;
        private GameContext context;

        private Game(IActionAnnouncer actionAnnouncer, GameContext context)
        {
            Announcer = actionAnnouncer;
            this.context = context;
        }

        public static Game Init(IActionAnnouncer actionAnnouncer, GameContext context)
        {
            if (instance != null) throw new Exception("Already initialized!");
            instance = new Game(actionAnnouncer, context);
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

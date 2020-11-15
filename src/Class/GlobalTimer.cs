using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CreatureWars.Class
{

    /**
     * CallStopFunction to abort this timer from execution
     * Remained - remained time to end in seconds
     * tickSecond
     */
    delegate void GlobalTimerAction(Action StopFunction, double Remained, double Passed);

    /**
     * 
     * 
     * 
     */
    class GlobalTimerItem {
        public double Duration { get; set; }
        public double Remained { get; set; }
        public GlobalTimerAction Action {get;set;}
        public int TickSecond { get; set; } = 0;
        public Action RemoveFromList;

        public GlobalTimerItem(double Duration, double Remained, GlobalTimerAction Action, int TickSecond = 0)
        {
            this.Duration = Duration;
            this.Remained = Remained;
            this.TickSecond = TickSecond;
            this.Action = Action;
        }
    }


    /**
     * <summary>This class is managing all periodics in game: movement, spellticks, etc...</summary>
     * 
     * 
     */
    class GlobalTimer
    {
        // Game refreshing every 50 ms;
        public static readonly int TICK_RATE = 20;
        public static readonly List<GlobalTimerItem> Tasks = new List<GlobalTimerItem>();
        public static double TimeElapsed = 0;
        public static Timer timer;

        /**
         * Duration in MILISECONDS
         */
        public static void Add(GlobalTimerAction Action, double Duration, int TickSecond = 0)
        {
            GlobalTimerItem globalTimerItem = new GlobalTimerItem(Duration, Duration, Action, TickSecond);
            globalTimerItem.RemoveFromList = () => { Tasks.Remove(globalTimerItem); };
            Tasks.Add(globalTimerItem);
        }

        public static void Tick(object state)
        {
            TimeElapsed += TICK_RATE;
            double FullSeconds = TimeElapsed / 1000;

            for (int i = 0; i < Tasks.Count; i++)
            {
                GlobalTimerItem current = Tasks[i];
                var TickSecond = current.TickSecond;
                var Remained = current.Remained;
                var Duration = current.Duration;
                Action RemoveThis = () => Tasks.Remove(current);
                Task TaskToRun = new Task(() => { current.Action(RemoveThis, Remained, Duration - Remained); });

                current.Remained -= TICK_RATE;

                if (TickSecond == 0)
                {
                    TaskToRun.Start();
                }
                else
                {
                    if (FullSeconds % TickSecond == 0)
                    {
                        TaskToRun.Start();
                    }
                }

                if (Remained <= 0)
                {
                    RemoveThis();
                }
            }
        }

        public static void Go()
        {
            TimerCallback timerCallback = new TimerCallback(Tick);
            timer = new Timer(timerCallback, null, 0, TICK_RATE);
        }

        ///**
        // * Tick modifiers etc... on creatures
        // * 
        // */
        //public static void TickCreatures(List<Creature> creatures)
        //{
            
        //}

        ///**
        // * Tick modifiers on Items
        // */
        //public static void TickItems(List<Item> items)
        //{
        //    foreach(Item item in items)
        //    {
        //        item.Modifiers
        //    }
        //}

        ///**
        // * Tick modifiers raw
        // */
        // public static void TickModifiers(List<Modifier> modifiers)
        //{
        //    foreach(Modifier modifier in modifiers)
        //    {
        //        modifiers
        //    }
            
        //}
    }
}

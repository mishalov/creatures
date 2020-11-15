using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    class PositionInfo
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
        double Speed { get; set; }


        /**
         *  coords represents target point 
         * 
         */

        double targetX { get; set; }
        double targetY { get; set; }
        double targetZ { get; set; }

        /**
         * <summary>Move current object to point</summary>
         * <returns>Count of time needed</returns>
         */
        double Move(double X, double Y, double Z)
        {
            throw new NotImplementedException();
        }


        /**
         * <summary>>Move current object to another object</summary>
         * <returns>Count of time needed</returns>
         */
        double MoveTo(ILocationable objectTo)
        {
            throw new NotImplementedException();
        }
    }
}

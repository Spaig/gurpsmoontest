using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gurpsmoontest
{
    public class World
    {
        int type;
        int temp;
        double atmomass;
        int hydrocoeff;//as multiple of 10% of surface
        int surfacetemp;//in  kelvins
        double blackbody;//in kelvins
        double density1;//Earths
        double density2;//g per cc
        double diameter;//in meters
        double surfacegravity;//in G
        double mass;//in Earths
        double pressure;//in atm

        public double icyCoreDensity(int threedee)
        {
            double density = 0.3;
            if (threedee > 17) { density = 0.7; }
            else if (threedee > 15) { density = 0.6; }
            else if (threedee > 11) { density = 0.5; }
            else if (threedee > 7) { density = 0.4; }
            return density;

        }
        public double smIronCoreDensity(int threedee)
        {
            double density = 0.6;
            if (threedee > 17) { density = 1.0; }
            else if (threedee > 15) { density = 0.9; }
            else if (threedee > 11) { density = 0.8; }
            else if (threedee > 7) { density = 0.7; }
            return density;
        }
        public double lgIronCoreDensity(int threedee)
        {
            double density = 0.8;
            if (threedee > 17) { density = 1.2; }
            else if (threedee > 15) { density = 1.1; }
            else if (threedee > 11) { density = 1.0; }
            else if (threedee > 7) { density = 0.9; }
            return density;
        }

        public double densityConversion(double density1)
        {

            double density2 = density1 * 5.52;
            return density2;
        }

        public double genAtmo(int threedee)
        {
            double atmo = threedee / 10;
            return atmo;
        }
        public int genHydro(int type, Random rand)
        {
            //cases 0,1,2.3,5,6,8,9,14,15 have no hydrography
            switch (type)
            {
                case 4:
                    return (rand.Next(5) + 1 )+ 2;//roll a d6 plus 2
                case 7:
                    return (rand.Next(5) + 1) + (rand.Next(5) + 1);//roll 2d
                case 13:
                    return (rand.Next(5) + 1) + (rand.Next(5) + 1);//roll 2d
                case 12:
                    temp = (rand.Next(5) + 1) + (rand.Next(5) + 1) - 10;
                    return iceHydro(temp);
                case 18:
                    temp = (rand.Next(5) + 1) + (rand.Next(5) + 1) - 10;
                    return iceHydro(temp);
                case 10:
                    return (rand.Next(5) + 1) + 4;//1d plus 4
                case 11:
                    return (rand.Next(5) + 1) + 4;//1d plus 4
                case 16:
                    return (rand.Next(5) + 1) + 6;//1d plus 6
                case 17:
                    return (rand.Next(5) + 1) + 6;//1d plus 6
                default:
                    return 0;
            }
        }

        public int iceHydro(int die){//special case because ice hydrography is bananas - roll 2d-10 and multiply by 10 % (minimum 0 %)
            switch (die) {//therefore, on a roll of 2-10, you get a zero, with an 11, its 1, with a 12, its 2
                case 12:
                    return 2;
                case 11:
                    return 1;
                default:
                    return 0;
            }
        }

        public int genSurfaceTemp(int type)
        {
            //TODO
            switch (type) { }
        }

        public double genBlackbody(int type) {
            //TODO
            switch (type) { }
        }

        public double calcDiameter(double blackbody, double density) { }

        public double calcSurfGrav(double diameter, double density) { }

        public double calcMass(double density, double diameter) { }

        public double calcPressure(double atmomass, double gravity) { }

    }
}
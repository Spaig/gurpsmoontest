﻿using System;
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
        double diameter;//in multiples of the diameter of earth
        double diameter2;//in miles
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

        public int genSurfaceTemp(int type, int threedee)//takes world type and a pregenned 3d value
        {
            temp = threedee - 3;
            //roll 3d-3, multiply the result by the Step value, and then add the minimum value from the Range
            switch (type) {
                case 0:
                    return (temp * 4) + 80;
                case 1:
                    return (temp * 4) + 80;
                case 4:
                    return (temp * 4) + 80;
                case 7:
                    return (temp * 5) + 140;
                case 13:
                    return (temp * 5) + 140;
                case 2:
                    return (temp * 24) + 140;
                case 5:
                    return (temp * 24) + 140;
                case 3:
                    return (temp * 2) + 50;
                case 6:
                    return (temp * 2) + 50;
                case 12:
                    return (temp * 10) + 80;
                case 18:
                    return (temp * 10) + 80;
                case 8:
                    return (temp * 30) + 500;
                case 9:
                    return (temp * 30) + 500;
                case 14:
                    return (temp * 30) + 500;
                case 15:
                    return (temp * 30) + 500;
                default://de facto case 10,11,16,17
                    return (temp * 6) + 250;
            }
        }

        public double genBlackbody(int type, double atmomass, int surfacetemp, int hydro)
        {//To determine the blackbody correction for a world, use the following formula: correction = absorption (from book) * [1 + (atmomass * greenhouse (also from book))
         //To determine the blackbody temperature,divide the average surface temperature by the blackbody correction.
            double correction;
            switch (type) {
                case 0:
                    correction = .86;
                    return surfacetemp / correction;
                case 1:
                    correction = .77;
                    return surfacetemp / correction;
                case 2://2, 9, and 15 have identical algorithms
                    correction = .97;
                    return surfacetemp / correction;
                case 9:
                    correction = .97;
                    return surfacetemp / correction;
                case 15:
                    correction = .97;
                    return surfacetemp / correction;
                case 3:
                    correction = .67;
                    return surfacetemp / correction;
                case 6://3 and 6 have identical algorithms
                    correction = .67;
                    return surfacetemp / correction;
                case 5:
                    correction = .96;
                    return surfacetemp / correction;
                case 7:
                    correction = (.84 * (1 + (atmomass * 0.2)));
                    return surfacetemp / correction;
                case 13://7 and 13 have identical algorithms
                    correction = (.84 * (1 + (atmomass * 0.2)));
                    return surfacetemp / correction;
                case 8:
                    correction = (.77 * (1 + (atmomass * 2)));
                    return surfacetemp / correction;
                case 14://8 and 14 have identical algorithms
                    correction = (.77 * (1 + (atmomass * 2)));
                    return surfacetemp / correction;
                case 4:
                    correction = (.93 * (1 + (atmomass * 0.1)));
                    return surfacetemp / correction;
                case 12:
                    correction = (.86 * (1 + (atmomass * 0.2)));
                    return surfacetemp / correction;
                case 18://12 and 18 have identical algorithms\
                    correction = (.86 * (1 + (atmomass * 0.2)));
                    return surfacetemp / correction;
                case 10://10,11,16, and 17 are affected by hydrographic coverage, so they get a helper method
                    return specialOceanGardenBlack(hydro, atmomass, surfacetemp);
                case 11:
                    return specialOceanGardenBlack(hydro, atmomass, surfacetemp);
                case 16:
                    return specialOceanGardenBlack(hydro, atmomass, surfacetemp);
                case 17:
                    return specialOceanGardenBlack(hydro, atmomass, surfacetemp);
                default:
                    return 0;

            }
        }

        public double specialOceanGardenBlack(int hydro, double atmomass, int surfacetemp)
        {
            double correction;
            if (hydro >= 2) {
                correction = (.95 * (1 + (atmomass * 0.16)));
            }
            else if (hydro >= 5) {
                correction = (.92 * (1 + (atmomass * 0.16)));
            }
            else if (hydro >= 9) {
                correction = (.88 * (1 + (atmomass * 0.16)));
            }
            else {
                correction = (.84 * (1 + (atmomass * 0.16)));
            }
            return surfacetemp / correction;
        }

        public double diameterMaxFactor(int type, double blackbody, double density) {//more values from the book, ugh - have to hardcode
            double factor = Math.Sqrt(blackbody/density);
            switch (type){ 
        //tiny
                 case 0:
                    return factor * 0.004;
                 case 1:
                    return factor * 0.004;
                  case 2:
                    return factor * 0.004;
        //small
                 case 3:
                    return factor * 0.024;
                case 4:
                     return factor * 0.024;
                 case 5:
                    return factor * 0.024;
        //standard
                 case 6:
                    return factor * 0.03;
                case 7:
                    return factor * 0.03;
                case 8:
                    return factor * 0.03;
                case 9:
                    return factor * 0.03;
                case 10:
                    return factor * 0.03;
                case 11:
                    return factor * 0.03;
                case 12:
                    return factor * 0.03;
                //large
                case 13:
                    return factor * 0.065;
                case 14:
                    return factor * 0.065;
                case 15:
                    return factor * 0.065;
                case 16:
                    return factor * 0.065;
                case 17:
                    return factor * 0.065;
                case 18:
                    return factor * 0.065;
                default:
            return 1; }
        }

        public double diameterMinFactor(int type, double blackbody, double density) {//more values from the book, ugh - have to hardcode
            double factor = Math.Sqrt(blackbody / density);
            switch (type) { 
        //tiny
                case 0:
                    return factor * 0.024;
                case 1:
                    return factor * 0.024;
                case 2:
                    return factor * 0.024;
                //small
                case 3:
                    return factor * 0.03;
                case 4:
                    return factor * 0.03;
                case 5:
                    return factor * 0.03;
                //standard
                case 6:
                    return factor * 0.065;
                case 7:
                    return factor * 0.065;
                case 8:
                    return factor * 0.065;
                case 9:
                    return factor * 0.065;
                case 10:
                    return factor * 0.065;
                case 11:
                    return factor * 0.065;
                case 12:
                    return factor * 0.065;
                //large
                case 13:
                    return factor * 0.091;
                case 14:
                    return factor * 0.091;
                case 15:
                    return factor * 0.091;
                case 16:
                    return factor * 0.091;
                case 17:
                    return factor * 0.091;
                case 18:
                    return factor * 0.091;
                default:
                    return 1;
            }
        }

        public double calcDiameter(int type, Random rand, double dMin, double dMax) {
            
            int twodee = (rand.Next(5) + 1) + (rand.Next(5) + 1) + 2;//roll 2 d6 plus 2
            double factor = twodee + ((dMax - dMin) / 10);//multiply by onetenth of the difference between the maximum and minimum diameter values

            switch (type)
            {//add the result to the minimum value.
                //tiny
                case 0:
                    return factor + 0.004;
                case 1:
                    return factor + 0.004;
                case 2:
                    return factor + 0.004;
                //small
                case 3:
                    return factor + 0.024;
                case 4:
                    return factor + 0.024;
                case 5:
                    return factor + 0.024;
                //standard
                case 6:
                    return factor + 0.03;
                case 7:
                    return factor + 0.03;
                case 8:
                    return factor + 0.03;
                case 9:
                    return factor + 0.03;
                case 10:
                    return factor + 0.03;
                case 11:
                    return factor + 0.03;
                case 12:
                    return factor + 0.03;
                //large
                case 13:
                    return factor + 0.065;
                case 14:
                    return factor + 0.065;
                case 15:
                    return factor + 0.065;
                case 16:
                    return factor + 0.065;
                case 17:
                    return factor + 0.065;
                case 18:
                    return factor + 0.065;
                default:
                    return 1;
            }
        }

        public double diameterToMiles(double diameter) {
            //To express any diameter in miles, multiply the value in Earth diameters by 7,930.
            return diameter * 7930;
        }

        public double calcSurfGrav(double diameter, double density) {

            //surface gravity equals diameter (in Earths) times density (in Earths)
            return diameter * density;
        }

        public double calcMass(double density, double diameter) {

            //mass equals density times diameter cubed (in multiples of Earth)
            return density * (Math.Pow(diameter, 3.0));
        }

        public double calcPressure(double atmomass, double gravity) { }

    }
}
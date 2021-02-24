using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gurpsmoontest
{
    public partial class calcpage : System.Web.UI.Page
    {
        Random rand = new Random();
        World[] worlds = new World[280];
        int[] worldTypes = new int[20];
        int count = 0, cursor = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWorldsGet.Text = "Counting worlds...";
            worldTypes = (int[])Context.Items[worldTypes];
            foreach (int x in worldTypes) {//get number of worlds to generate
                count = count + x;
            }
            lblWorldsGet.Text = "Counting worlds... complete!";
            lblWorldsInitialize.Text = "Initializing tiny worlds...";

            if (worldTypes[0] > 0) {//if tiny ice worlds
                for (int i = 0; i > worldTypes[0]; i++) {//tiny ice world generation
                    World temp = new World();//create new World object
                    temp.setType(0);//set type
                    temp.setEarthDensity(icyCoreDensity(roll3D()));//set density by passing 3D6 into density method
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(0);//it's cold outside, there's no kind of atmosphere
                    temp.setHydro(iceHydro(roll1D()));//set hydro with ice world method
                    temp.setSurfaceTemp(genSurfaceTemp(0, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(0, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(0, rand,
                        diameterMaxFactor(0, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(0, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 0));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                } }

            if (worldTypes[1] > 0)
            {//if tiny sulfur worlds
                for (int i = 0; i > worldTypes[1]; i++)
                {//tiny sulfur world generation
                    World temp = new World();//create new World object
                    temp.setType(1);//set type
                    temp.setEarthDensity(icyCoreDensity(roll3D()));//set density by passing 3D6 into density method - all Tiny worlds have icy cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(0);//tiny worlds have no atmosphere
                    temp.setHydro(genHydro(1, rand));//call genydro
                    temp.setSurfaceTemp(genSurfaceTemp(1, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(1, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(1, rand,
                        diameterMaxFactor(1, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(1, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 1));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            if (worldTypes[2] > 0)
            {//if tiny rock worlds
                for (int i = 0; i > worldTypes[2]; i++)
                {//tiny rock world generation
                    World temp = new World();//create new World object
                    temp.setType(2);//set type
                    temp.setEarthDensity(smIronCoreDensity(roll3D()));//set density by passing 3D6 into density method - all Tiny worlds have icy cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(0);//tiny worlds have no atmosphere
                    temp.setHydro(genHydro(2, rand));//call genydro
                    temp.setSurfaceTemp(genSurfaceTemp(2, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(2, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(2, rand,
                        diameterMaxFactor(2, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(2, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 2));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            lblWorldsInitialize.Text = "Tiny worlds complete. Initializing small worlds...";

            if (worldTypes[3] > 0)
            {//if small Hadean worlds
                for (int i = 0; i > worldTypes[3]; i++)
                {//small Hadean world generation
                    World temp = new World();//create new World object
                    temp.setType(3);//set type
                    temp.setEarthDensity(icyCoreDensity(roll3D()));//set density by passing 3D6 into density method - all Tiny worlds have icy cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(0);//small Hadean worlds have no atmosphere
                    temp.setHydro(genHydro(3, rand));//call genydro
                    temp.setSurfaceTemp(genSurfaceTemp(3, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(3, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(3, rand,
                        diameterMaxFactor(3, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(3, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 3));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            if (worldTypes[4] > 0)
            {//if small ice worlds
                for (int i = 0; i > worldTypes[4]; i++)
                {//small ice world generation
                    World temp = new World();//create new World object
                    temp.setType(4);//set type
                    temp.setEarthDensity(icyCoreDensity(roll3D()));//set density by passing 3D6 into density method - all Tiny worlds have icy cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(genAtmo(roll3D()));//small Hadean worlds have no atmosphere
                    temp.setHydro(genHydro(4, rand));//call genydro
                    temp.setSurfaceTemp(genSurfaceTemp(4, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(4, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(4, rand,
                        diameterMaxFactor(4, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(4, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 4));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            if (worldTypes[5] > 0)
            {//if small rocky worlds
                for (int i = 0; i > worldTypes[5]; i++)
                {//small rocky world generation
                    World temp = new World();//create new World object
                    temp.setType(5);//set type
                    temp.setEarthDensity(smIronCoreDensity(roll3D()));//set density by passing 3D6 into density method - all Tiny worlds have icy cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(0);//small rocky worlds have no atmosphere
                    temp.setHydro(genHydro(5, rand));//call genydro
                    temp.setSurfaceTemp(genSurfaceTemp(5, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(5, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(5, rand,
                        diameterMaxFactor(5, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(5, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 5));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            lblWorldsInitialize.Text = "Small worlds complete. Initializing standard worlds...";

            if (worldTypes[6] > 0)
            {//if standard hadean worlds
                for (int i = 0; i > worldTypes[6]; i++)
                {//standard hadean world generation
                    World temp = new World();//create new World object
                    temp.setType(6);//set type
                    temp.setEarthDensity(icyCoreDensity(roll3D()));//set density by passing 3D6 into density method - all Tiny worlds have icy cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(0);//standard hadean worlds have no atmosphere
                    temp.setHydro(0);//hadean worlds lack hydrographic coverage
                    temp.setSurfaceTemp(genSurfaceTemp(6, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(6, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(6, rand,
                        diameterMaxFactor(6, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(6, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 6));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            if (worldTypes[7] > 0)
            {//if Standard Ammonian worlds
                for (int i = 0; i > worldTypes[7]; i++)
                {//Standard Ammonian generation
                    World temp = new World();//create new World object
                    temp.setType(7);//set type
                    temp.setEarthDensity(icyCoreDensity(roll3D()));//set density by passing 3D6 into density method - all Tiny worlds have icy cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(genAtmo(roll3D()));//Standard Ammonian world generation
                    temp.setHydro(genHydro(7, rand));//hadean worlds lack hydrographic coverage
                    temp.setSurfaceTemp(genSurfaceTemp(7, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(7, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(7, rand,
                        diameterMaxFactor(7, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(7, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 7));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            if (worldTypes[8] > 0)
            {//if Standard Greenhouse worlds
                for (int i = 0; i > worldTypes[8]; i++)
                {//Standard Greenhouse generation
                    World temp = new World();//create new World object
                    temp.setType(8);//set type
                    temp.setEarthDensity(lgIronCoreDensity(roll3D()));//set density by passing 3D6 into density method - Standard Greenhouse worlds have large iron cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(genAtmo(roll3D()));//Standard Greenhouse world generation
                    temp.setHydro(genHydro(8, rand));//greenhouse worlds have weird hydrospheres
                    temp.setSurfaceTemp(genSurfaceTemp(8, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(8, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(8, rand,
                        diameterMaxFactor(8, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(8, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 8));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            if (worldTypes[9] > 0)
            {//if Standard Cthon worlds
                for (int i = 0; i > worldTypes[9]; i++)
                {//Standard Cthon generation
                    World temp = new World();//create new World object
                    temp.setType(9);//set type
                    temp.setEarthDensity(lgIronCoreDensity(roll3D()));//set density by passing 3D6 into density method - Standard Greenhouse worlds have large iron cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(0);//Cthonian worlds always have a Trace atmosphere only
                    temp.setHydro(0);//Cthonian worlds always have zero hydrographic coverage 
                    temp.setSurfaceTemp(genSurfaceTemp(9, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(9, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(9, rand,
                        diameterMaxFactor(9, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(9, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 9));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            if (worldTypes[10] > 0)
            {//if Standard Garden worlds
                for (int i = 0; i > worldTypes[10]; i++)
                {//Standard Garden generation
                    World temp = new World();//create new World object
                    temp.setType(10);//set type
                    temp.setEarthDensity(lgIronCoreDensity(roll3D()));//set density by passing 3D6 into density method - Standard Greenhouse worlds have large iron cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(genAtmo(roll3D()));//Garden worlds have normal atmospheres
                    temp.setHydro(genHydro(10, rand));//Garden worlds have normal hydrographic coverage 
                    temp.setSurfaceTemp(genSurfaceTemp(10, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(10, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values
                    temp.setEarthsDiameter(calcDiameter(10, rand,
                        diameterMaxFactor(10, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(10, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 10));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            if (worldTypes[11] > 0)
            {//if Standard Ocean worlds
                for (int i = 0; i > worldTypes[11]; i++)
                {//Standard Ocean generation
                    World temp = new World();//create new World object
                    temp.setType(11);//set type
                    temp.setEarthDensity(lgIronCoreDensity(roll3D()));//set density by passing 3D6 into density method - Standard Ocean worlds have large iron cores
                    temp.setMetricDensity(densityConversion(temp.getEarthDensity()));//call density conversion method on first density value
                    temp.setAtmoMass(genAtmo(roll3D()));//Ocean worlds have normal atmospheres
                    temp.setHydro(genHydro(11, rand));//Garden worlds have normal hydrographic coverage 
                    temp.setSurfaceTemp(genSurfaceTemp(11, roll3D()));//generate surface temperature
                    temp.setBlackBody(genBlackbody(11, temp.getAtmoMass(), temp.getSurfaceTemp(), temp.getHydro()));//set blackbody value with previously generated values -should call special method
                    temp.setEarthsDiameter(calcDiameter(11, rand,
                        diameterMaxFactor(11, temp.getBlackBody(), temp.getEarthDensity()),
                        diameterMinFactor(11, temp.getBlackBody(), temp.getEarthDensity())
                        ));//heckin doozy of a call - calculate diameter by calculating max and min and passing it to main calc method
                    temp.setMilesDiameter(diameterToMiles(temp.getEarthsDiameter()));//call conversion method
                    temp.setSurfaceGravity(calcSurfGrav(temp.getEarthsDiameter(), temp.getEarthDensity()));//call gravity method
                    temp.setMass(calcMass(temp.getEarthDensity(), temp.getEarthsDiameter()));//call mass method
                    temp.setPressure(calcPressure(temp.getAtmoMass(), temp.getSurfaceGravity(), 11));//call pressure method
                    worlds[cursor] = temp;//store World in worlds array
                    cursor++;//increment cursor
                }
            }

            //TODO - world types 12 - 18
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            Context.Items.Add("worlds", worlds);
            Server.Transfer("~/results.aspx");
        }

        public int roll3D()
        {
            int die1 = rand.Next(5) + 1;
            int die2 = rand.Next(5) + 1;
            int die3 = rand.Next(5) + 1;
            int threedee = die1 + die2 + die3;
            return threedee;
        }

        public int roll1D()
        {
            return rand.Next(5) + 1;
        }

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
            int temp = 0;//local method variable
            switch (type)
            {
                case 4:
                    return (rand.Next(5) + 1) + 2;//roll a d6 plus 2
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

        public int iceHydro(int die)
        {//special case because ice hydrography is bananas - roll 2d-10 and multiply by 10 % (minimum 0 %)
            switch (die)
            {//therefore, on a roll of 2-10, you get a zero, with an 11, its 1, with a 12, its 2
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
            int temp = threedee - 3;
            //roll 3d-3, multiply the result by the Step value, and then add the minimum value from the Range
            switch (type)
            {
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
            switch (type)
            {
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
            if (hydro >= 2)
            {
                correction = (.95 * (1 + (atmomass * 0.16)));
            }
            else if (hydro >= 5)
            {
                correction = (.92 * (1 + (atmomass * 0.16)));
            }
            else if (hydro >= 9)
            {
                correction = (.88 * (1 + (atmomass * 0.16)));
            }
            else
            {
                correction = (.84 * (1 + (atmomass * 0.16)));
            }
            return surfacetemp / correction;
        }

        public double diameterMaxFactor(int type, double blackbody, double density)
        {//more values from the book, ugh - have to hardcode
            double factor = Math.Sqrt(blackbody / density);
            switch (type)
            {
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
                    return 1;
            }
        }

        public double diameterMinFactor(int type, double blackbody, double density)
        {//more values from the book, ugh - have to hardcode
            double factor = Math.Sqrt(blackbody / density);
            switch (type)
            {
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

        public double calcDiameter(int type, Random rand, double dMin, double dMax)
        {

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

        public double diameterToMiles(double diameter)
        {
            //To express any diameter in miles, multiply the value in Earth diameters by 7,930.
            return diameter * 7930;
        }

        public double calcSurfGrav(double diameter, double density)
        {

            //surface gravity equals diameter (in Earths) times density (in Earths)
            return diameter * density;
        }

        public double calcMass(double density, double diameter)
        {

            //mass equals density times diameter cubed (in multiples of Earth)
            return density * (Math.Pow(diameter, 3.0));
        }

        public double calcPressure(double atmomass, double gravity, int type)
        {

            switch (type)
            {// pressure = atmomass * book value * surface gravity
                //tiny worlds have no atmosphere
                case 0:
                    return 0;
                case 1:
                    return 0;
                case 2:
                    return 0;
                //small
                case 3:
                    return 0;
                case 4:
                    return atmomass * gravity * 10;
                case 5:
                    return 0;
                //standard
                case 6:
                    return 0;
                case 7:
                    return atmomass * gravity * 10;
                case 8:
                    return atmomass * gravity * 100;
                case 9:
                    return 0;
                case 10:
                    return atmomass * gravity * 10;
                case 11:
                    return atmomass * gravity * 10;
                case 12:
                    return atmomass * gravity * 10;
                //large
                case 13:
                    return atmomass * gravity * 5;
                case 14:
                    return atmomass * gravity * 500;
                case 15:
                    return 0;
                case 16:
                    return atmomass * gravity * 5;
                case 17:
                    return atmomass * gravity * 5;
                case 18:
                    return atmomass * gravity * 5;
                default:
                    return 1;
            }

        }
    }
}

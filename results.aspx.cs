using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gurpsmoontest
{
    public partial class results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int count = (int)Session["count"];//get number of worlds from session variable

            World[] worlds = new World[280]; //initialize local worlds array

            worlds = (World[])Session["worlds"]; //get worlds array from session variable

            //TODO " System.NullReferenceException: 'Object reference not set to an instance of an object.' - worlds[] was null"
            //probably just messed up the variable passing - fix next session

            DataTable worldsLink = new DataTable();//set up DataTable
            worldsLink.Columns.Add("Class", Type.GetType("System.String"));
            worldsLink.Columns.Add("Atmospheric Mass", Type.GetType("System.String"));
            worldsLink.Columns.Add("Hydrographic Coverage (%)", Type.GetType("System.String"));
            worldsLink.Columns.Add("Surface Temp (K)", Type.GetType("System.String"));
            worldsLink.Columns.Add("Density (g/cc)", Type.GetType("System.String"));
            worldsLink.Columns.Add("Diameter (Miles)", Type.GetType("System.String"));
            worldsLink.Columns.Add("Surface Gravity (G)", Type.GetType("System.String"));
            worldsLink.Columns.Add("Mass (compared to Earth)", Type.GetType("System.String"));
            worldsLink.Columns.Add("Atmospheric Pressure (atm)", Type.GetType("System.String"));

            int worldsCount = (int)Session["count"];

            for(int i = 0; i<worldsCount; i++) {

                worldsLink.Rows.Add();//populate DataTable
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Class"] = worlds[i].getTypeName();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Atmospheric Mass"] = worlds[i].getAtmoMass();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Hydrographic Coverage (%)"] = worlds[i].getHydro();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Surface Temp (K)"] = worlds[i].getSurfaceTemp();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Density (g/cc)"] = worlds[i].getMetricDensity();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Diameter (Miles)"] = worlds[i].getMilesDiameter();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Surface Gravity (G)"] = worlds[i].getSurfaceGravity();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Mass (compared to Earth)"] = worlds[i].getMass();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Atmospheric Pressure (atm)"] = worlds[i].getPressure();}

            grdMoons.DataSource = worldsLink;//bind DataTable to GridView for display
            grdMoons.DataBind();

        }



        //TODO export code - should support excel, add more?
    }
}
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
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWorldsGet.Text = "Counting worlds...";
            //insert code to get numbers from array
            lblWorldsGet.Text = "Counting worlds... complete!";
            lblWorldsInitialize.Text = "Initializing tiny worlds...";
            //insert code to generate tiny worlds, etc
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {

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
    }
}
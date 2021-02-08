using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gurpsmoontest
{
    
    public partial class moons : System.Web.UI.Page
    {
        int[] worldTypes = new int[21];    

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {//loads number of each world type into array, passes array to calculation page
            
            worldTypes[0] = dropTinyIceWorld.SelectedIndex;//Tiny Ice World - 0
            worldTypes[1] = dropTinySulfWorld.SelectedIndex;// Tiny Sulfur World - 1
            worldTypes[2] = dropTinyRockWorld.SelectedIndex;// Tiny Rock World - 2
            worldTypes[3] = dropSmallHadeanWorld.SelectedIndex;//Small Hadean World - 3
            worldTypes[4] = dropSmallIceWorld.SelectedIndex;// Small Ice World - 4
            worldTypes[5] = dropSmallRockWorld.SelectedIndex;// Small Rock World - 5
            worldTypes[6] = dropStandardHadeanWorld.SelectedIndex; // Standard Hadean World - 6
            worldTypes[7] = dropStandardAmmoniaWorld.SelectedIndex;//Standard Ammonian World - 7
            worldTypes[8] = dropStandardGreenhouseWorld.SelectedIndex;//Standard Greenhouse World - 8
            worldTypes[9] = dropStandardCthonianWorld.SelectedIndex;//Standard Cthon World - 9
            worldTypes[10] = dropStandardGardenWorld.SelectedIndex;//Standard Garden World - 10
            worldTypes[11] = dropStandardOceanWorld.SelectedIndex;//Standard Ocean World - 11
            worldTypes[12] = dropStandardIceWorld.SelectedIndex;// Standard Ice World - 12
            worldTypes[13] = dropLargeAmmoniaWorld.SelectedIndex;//Large Ammonian World - 13
            worldTypes[14] = dropLargeGreenhouseWorld.SelectedIndex;//Large Greenhouse World - 14
            worldTypes[15] = dropLargeCthonianWorld.SelectedIndex;//Large Cthon World - 15
            worldTypes[16] = dropLargeGardenWorld.SelectedIndex;//Large Garden World - 16
            worldTypes[17] = dropLargeOceanWorld.SelectedIndex;//Large Ocean World - 17
            worldTypes[18] = dropLargeIceWorld.SelectedIndex;//Large Ice World - 18
            worldTypes[19] = dropGasGiants.SelectedIndex;// Gas Giant - 19
            //asteroid belt - 20 NOT IMPLEMENTED

            Context.Items.Add("worldTypes", worldTypes);
            Server.Transfer("~/calcpage.aspx");
        }  
    }
}

//OVERALL TODO
//data flow
//display (chart? exporting?)

//Stretch TODO
//convert to whole-system generator
//pick a star
//generate planets
//hook up moon system to planets
//blackbody base calculation
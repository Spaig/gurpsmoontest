using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace gurpsmoontest
{
    public partial class results : System.Web.UI.Page
    {
        DataTable worldsLink;//instantiate DataTable
        protected void Page_Load(object sender, EventArgs e)
        {
            int count = (int)Session["count"];//get number of worlds from session variable

            World[] worlds = new World[280]; //initialize local worlds array

            worlds = (World[])Session["worlds"]; //get worlds array from session variable


            worldsLink = new DataTable();//set up DataTable
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

            for (int i = 0; i < worldsCount; i++)
            {

                worldsLink.Rows.Add();//populate DataTable
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Class"] = worlds[i].getTypeName();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Atmospheric Mass"] = worlds[i].getAtmoMass();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Hydrographic Coverage (%)"] = worlds[i].getHydro();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Surface Temp (K)"] = worlds[i].getSurfaceTemp();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Density (g/cc)"] = worlds[i].getMetricDensity();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Diameter (Miles)"] = worlds[i].getMilesDiameter();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Surface Gravity (G)"] = worlds[i].getSurfaceGravity();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Mass (compared to Earth)"] = worlds[i].getMass();
                worldsLink.Rows[worldsLink.Rows.Count - 1]["Atmospheric Pressure (atm)"] = worlds[i].getPressure();
            }

            grdMoons.DataSource = worldsLink;//bind DataTable to GridView for display
            grdMoons.DataBind();

        }

        protected void btnCSVExport_Click(object sender, EventArgs e)
        {
            //checked empty and/or null worldsLink
            if (worldsLink != null && worldsLink.Rows.Count > 0)
            {
                // create a StringBuilder
                StringBuilder stringy = new StringBuilder();

                // get columns from worldslink and add to string array
                string[] columnNames = worldsLink.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();

                // create comma-ized column namse based on string array
                stringy.AppendLine(string.Join(",", columnNames));

                // get rows from worldsLink and add comma separated values
                foreach (DataRow row in worldsLink.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                    stringy.AppendLine(string.Join(",", fields));
                }


                Response.AppendHeader("Content-Length", stringy.Length.ToString());
                Response.ContentType = "text/csv";//get as csv file
                Response.AddHeader("Content-Disposition", "attachment;filename=myMoons.csv");//add proper header
                Response.Write(stringy);//write response
                Response.End();//end response
            }

        }

        protected void btnPDFExport_Click(object sender, EventArgs e)
        {
            //checked empty and/or null worldsLink
            if (worldsLink != null && worldsLink.Rows.Count > 0)
            {
                // create a StringBuilder for the data
                StringBuilder stringy = new StringBuilder();

                // get columns from worldslink and add to string array
                string[] columnNames = worldsLink.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();

                // create comma-ized column namse based on string array
                stringy.AppendLine(string.Join(",", columnNames));

                // get rows from worldsLink and add comma separated values
                foreach (DataRow row in worldsLink.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                    stringy.AppendLine(string.Join(",", fields));
                }

                StringReader reader = new StringReader(stringy.ToString());//pass stringbuilder to reader

                Document PDFOut = new Document(PageSize.A4, 10f, 10f, 10f, 0f); //create document to take data

                HTMLWorker newParser = new HTMLWorker(PDFOut);//create HTMLWorker

                using (MemoryStream memoryStream = new MemoryStream())//write string to document "PDFOut"
                {
                    PdfWriter writer = PdfWriter.GetInstance(PDFOut, memoryStream);
                    PDFOut.Open();

                    newParser.Parse(reader);
                    PDFOut.Close();

                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();

                    Response.Clear();
                    Response.ContentType = "application/pdf";//get as pdf
                    Response.AddHeader("Content-Disposition", "attachment; filename=myMoons.pdf");//add proper header
                    Response.Buffer = true;
                    Response.BinaryWrite(bytes); //write response
                    Response.End();//end response
                }
 
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using PMBOL;
using PMBLL;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Net;
using OpenQA.Selenium.Firefox;

namespace POSTMARKS2._0
{
    public partial class Form1 : Form
    {
        public static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }
        PMBOL_CLASS PMBOL = new PMBOL_CLASS();
        private void button4_Click(object sender, EventArgs e)
        {
            if (TXT_USERID2.Text=="")
            {
                PMBOL.userid = PMBOL_CLASS.uid;
                PMBOL.password = PMBOL_CLASS.pwd;
            }
            else
            {
                PMBOL.userid = TXT_USERID2.Text;
                PMBOL.password = TXT_PWD1.Text;
            }

           

            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            LBLMSG.Text = PM_BLL_CLASS.POST_MARKS_CHECK(PMBOL);
            this.WindowState = FormWindowState.Minimized;
        }

        public void CHANGE_SUBJECT( int INDEX)
        {
            if (CMB_CLASS.SelectedIndex == 1 || CMB_CLASS.SelectedIndex == 2)
            {

                CMB_CLASS.SelectedIndex = PMBOL.subjects1to2[INDEX];

            }
            else if (CMB_CLASS.SelectedIndex >= 3 && CMB_CLASS.SelectedIndex <= 5)
            {

                CMB_CLASS.SelectedIndex = PMBOL.subjects3to5[INDEX];

            }
            else if (CMB_CLASS.SelectedIndex >= 6 && CMB_CLASS.SelectedIndex <= 7)
            {

                CMB_CLASS.SelectedIndex = PMBOL.subjects6_7[INDEX];

            }
            else if (CMB_CLASS.SelectedIndex == 8 || CMB_CLASS.SelectedIndex == 10)
            {

                CMB_CLASS.SelectedIndex = PMBOL.subjects8_10[INDEX];

            }
            else if ( CMB_CLASS.SelectedIndex == 9)
            {

                CMB_CLASS.SelectedIndex = PMBOL.subjects9[INDEX];

            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            RAD_SA2.Checked = true;
            CMB_CLASS.SelectedIndex = 6;
            CMB_SUBJECT.SelectedIndex = 0;
            CMB_SECTION.SelectedIndex = 1;
        }
        private void RAD_SA1_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "SA1";
            PMBOL.SAserviceXpath = PMBOL_CLASS.SA1_SERVICES_XPATH;
            PMBOL.SAmarksEntryXpath = PMBOL_CLASS.SA1_MARKS_ENTRY_XPATH;

        }

        private void RAD_SA2_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "SA2";
            PMBOL.SAserviceXpath = PMBOL_CLASS.SA2_SERVICES_XPATH;
            PMBOL.SAmarksEntryXpath = PMBOL_CLASS.SA2_MARKS_ENTRY_XPATH;
        }

        private void CMB_CLASS_SelectedIndexChanged(object sender, EventArgs e)
        {
            PMBOL.CLASS = CMB_CLASS.SelectedItem.ToString();
            PMBOL.CLASS_int = CMB_CLASS.SelectedIndex;

            PMBOL.SECTIONS = 26;
           

            CMB_SUBJECT.Items.Clear();
            switch (CMB_CLASS.SelectedIndex)
            {
                case 1: case 2:
                    CMB_SUBJECT.Items.Add("TEL");
                    CMB_SUBJECT.Items.Add("ENG");
                    CMB_SUBJECT.Items.Add("MAT");
                    break;
                case 3:
                case 4:
                case 5:
                    CMB_SUBJECT.Items.Add("TEL");
                    CMB_SUBJECT.Items.Add("ENG");
                    CMB_SUBJECT.Items.Add("MAT");
                    CMB_SUBJECT.Items.Add("ENV");
                    break;

                case 6:
                case 7:
                     CMB_SUBJECT.Items.Add("TEL");
                    CMB_SUBJECT.Items.Add("HIN");
                    CMB_SUBJECT.Items.Add("ENG");
                    CMB_SUBJECT.Items.Add("MAT");
                    CMB_SUBJECT.Items.Add("GS");
                    CMB_SUBJECT.Items.Add("SS");

                    break;
                case 8:
                case 9:
                case 10:
                    CMB_SUBJECT.Items.Add("TEL");
                    CMB_SUBJECT.Items.Add("HIN");
                    CMB_SUBJECT.Items.Add("ENG");
                    CMB_SUBJECT.Items.Add("MAT");
                    CMB_SUBJECT.Items.Add("PS");
                    CMB_SUBJECT.Items.Add("BS");
                    CMB_SUBJECT.Items.Add("SS");

                    break;


                case 91:
                    
                    CMB_SUBJECT.Items.Add("TEL1");
                    CMB_SUBJECT.Items.Add("TEL2");
                    CMB_SUBJECT.Items.Add("HIN");
                    CMB_SUBJECT.Items.Add("ENG1");
                    CMB_SUBJECT.Items.Add("ENG2");
                    CMB_SUBJECT.Items.Add("MAT1");
                    CMB_SUBJECT.Items.Add("MAT2");
                    CMB_SUBJECT.Items.Add("PS");
                    CMB_SUBJECT.Items.Add("BS");
                    CMB_SUBJECT.Items.Add("SS1");
                    CMB_SUBJECT.Items.Add("SS2");
                    
                    break;


                case 81:
                 
                case 101:
                    CMB_SUBJECT.Items.Add("TEL");
                    CMB_SUBJECT.Items.Add("HIN");
                    CMB_SUBJECT.Items.Add("ENG");
                    CMB_SUBJECT.Items.Add("MAT");
                    CMB_SUBJECT.Items.Add("PS");
                    CMB_SUBJECT.Items.Add("BS");
                    CMB_SUBJECT.Items.Add("SS");

                    break;
                    
            }
            CMB_SUBJECT.SelectedIndex = 0;
        }
        public void saveXpath(string element,string xpath,SqlConnection con)
        {
           string sql= "insert into elements(element,xpath) values('"+element+"','"+xpath+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con_open(con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void CMB_SUBJECT_SelectedIndexChanged(object sender, EventArgs e)
        {
            PMBOL.SUBJECT = CMB_SUBJECT.SelectedItem.ToString();
            PMBOL.SUBJECT_int = CMB_SUBJECT.SelectedIndex;

            switch (PMBOL.SUBJECT)
            {
                case "TEL":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL_COL_limit[CMB_CLASS.SelectedIndex];
                    break;
                case "TEL1":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL1_COL_LIMIT[0];
                    break;
                case "TEL2":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL2_COL_LIMIT[0];
                    break;

                case "HIN":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.HIN_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.HIN_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.HIN_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.HIN_COL_limit[CMB_CLASS.SelectedIndex];
                    break;
                case "ENG":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG_COL_LIMIT[CMB_CLASS.SelectedIndex];
                    break;
                case "ENG1":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG1_COL_LIMIT[0];
                    break;
                case "ENG2":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG2_COL_LIMIT[0];
                    break;
                case "MAT":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT_COL_LIMIT[CMB_CLASS.SelectedIndex];
                    break;
                case "MAT1":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT1_COL_LIMIT[0];
                    break;
                case "MAT2":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT2_COL_LIMIT[0];
                    break;
                case "PS":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.PS_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.PS_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.PS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.PS_COL_LIMIT[CMB_CLASS.SelectedIndex];

                    break;
                case "GS":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.GS_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.GS_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.GS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.GS_COL_LIMIT[CMB_CLASS.SelectedIndex];

                    break;
                case "BS":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.BS_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.BS_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.BS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.BS_COL_LIMIT[CMB_CLASS.SelectedIndex];

                    break;
                case "SS":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS_COL_LIMIT[CMB_CLASS.SelectedIndex];


                    break;
                case "SS1":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS1_COL_LIMIT[0];

                    break;
                case "SS2":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS2_COL_LIMIT[0]; 
                    break;
            }

            if (TXT_USERID2.Text == "")
            {
                if (RAD_SA1.Checked==true)
                {
                PMBOL.TABLE = PMBOL_CLASS.datatablessa1[CMB_CLASS.SelectedIndex - 1];
                }
                else if (RAD_SA2.Checked==true)
                {
                    PMBOL.TABLE = PMBOL_CLASS.datatablessa2[CMB_CLASS.SelectedIndex - 1];
                }
                else if (RAD_FA3.Checked == true)
                {
                    PMBOL.TABLE = PMBOL_CLASS.datatablesFA3[CMB_CLASS.SelectedIndex - 1];
                }


            }
            else
                PMBOL.TABLE = "CLASS" + CMB_CLASS.Text+"_"+TXT_USERID2.Text +"_"+PMBOL.TEST+"$";



            textBox1.Text = PMBOL.SUBJECTWISE_COLUMNS+"\r\n"+ PMBOL.ISEMPTY + "\r\n" + PMBOL.tools + "\r\n" + PMBOL.TOOLS_LIMIT;
            CMB_SECTION.SelectedIndex = 1;
        }

        private void CMB_SUBJECT_SelectedIndexChanged1(object sender, EventArgs e)
        {
            PMBOL.SUBJECT = CMB_SUBJECT.SelectedItem.ToString();
            PMBOL.SUBJECT_int = CMB_SUBJECT.SelectedIndex;

            switch (PMBOL.SUBJECT)
            {
                case "TEL":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL_COL_limit[CMB_CLASS.SelectedIndex];
                    break;
                case "TEL1":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL1_COL_LIMIT[0];
                    break;
                case "TEL2":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL2_COL_LIMIT[0];
                    break;

                case "HIN":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.HIN_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.HIN_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.HIN_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.HIN_COL_limit[CMB_CLASS.SelectedIndex];
                    break;
                case "ENG":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG_COL_LIMIT[CMB_CLASS.SelectedIndex];
                    break;
                case "ENG1":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG1_COL_LIMIT[0];
                    break;
                case "ENG2":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG2_COL_LIMIT[0];
                    break;
                case "MAT":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT_COL_LIMIT[CMB_CLASS.SelectedIndex];
                    break;
                case "MAT1":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT1_COL_LIMIT[0];
                    break;
                case "MAT2":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT2_COL_LIMIT[0];
                    break;
                case "PS":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.PS_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.PS_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.PS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.PS_COL_LIMIT[CMB_CLASS.SelectedIndex];

                    break;
                case "GS":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.GS_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.GS_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.GS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.GS_COL_LIMIT[CMB_CLASS.SelectedIndex];

                    break;
                case "BS":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.BS_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.BS_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.BS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.BS_COL_LIMIT[CMB_CLASS.SelectedIndex];

                    break;
                case "SS":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS_COL[CMB_CLASS.SelectedIndex];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS_ISEMPTY[CMB_CLASS.SelectedIndex];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS_COL_LIMIT[CMB_CLASS.SelectedIndex];


                    break;
                case "SS1":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS1_COL_LIMIT[0];

                    break;
                case "SS2":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[CMB_CLASS.SelectedIndex];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS2_COL_LIMIT[0];
                    break;
            }

            if (TXT_USERID2.Text == "")
            {
                if (RAD_SA1.Checked == true)
                {
                    PMBOL.TABLE = PMBOL_CLASS.datatablessa1[CMB_CLASS.SelectedIndex - 1];
                }
                else if (RAD_SA2.Checked == true)
                {
                    PMBOL.TABLE = PMBOL_CLASS.datatablessa2[CMB_CLASS.SelectedIndex - 1];
                }

            }
            else
                PMBOL.TABLE = "CLASS" + CMB_CLASS.Text + "_" + TXT_USERID2.Text + "_" + PMBOL.TEST + "$";



            textBox1.Text = PMBOL.SUBJECTWISE_COLUMNS + "\r\n" + PMBOL.ISEMPTY + "\r\n" + PMBOL.tools + "\r\n" + PMBOL.TOOLS_LIMIT;
            CMB_SECTION.SelectedIndex = 1;
        }

        private void CMB_SECTION_SelectedIndexChanged(object sender, EventArgs e)
        {
            PMBOL.SECTION = int.Parse(CMB_SECTION.SelectedIndex.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RAD_SA1.Checked = true;
            CMB_CLASS.SelectedIndex = 8;
            CMB_SUBJECT.SelectedIndex = 2;
            CMB_SECTION.SelectedIndex = 6;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cMRDataSet.ELEMENTS' table. You can move, or remove it, as needed.
        //    this.eLEMENTSTableAdapter.Fill(this.cMRDataSet.ELEMENTS);
            if (int.Parse(CheckForInternetConnection().ToString()) == 0)
            {
                MessageBox.Show("Check your Network connection");

            }
            setlocation();
            //read_selections();
            //LODE_INPUTS();
            con.ConnectionString = constr;
            DataSet DS = READSQL(con, "SCHOOLS", "schname","");
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                CMB_SCHOOL.Items.Add(DS.Tables[0].Rows[i][0]);
            DS.Clear();
            DS = READSQL(con, "SYS.TABLES", "name","WHERE name LIKE '%STU%'");
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                CMB_TABLE.Items.Add(DS.Tables[0].Rows[i][0]);

            PMBOL.rowsincycle1 = -1;
            PMBOL.rowsincycle2 = 0;

            FRM_GET_MARKS FM=new FRM_GET_MARKS ();
            this.Hide();
            FM.Show ();
        }
        private DataSet READSQL(SqlConnection con, string tABLE, string cOLUMNS,string CONDITION)
        {
            string sql = "select " + cOLUMNS + " from " + tABLE+" "+CONDITION;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con_open(con);
            DataSet ds = new DataSet();
            da.Fill(ds, "data");
            Console.WriteLine(sql);
            //    Console.WriteLine( "  RECORDS:" + ds.Tables[0].Rows[0]["BS1"] + "--" + ds.Tables[0].Rows[0]["BS2"] + "--" + ds.Tables[0].Rows[0]["BS3"] + "--" + ds.Tables[0].Rows[0]["BS4"]);
            con.Close();
            return ds;
        }

        public static int CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return 1;
            }
            catch
            {
                return 0;
            }
        }
        public static int LOC_X = 50, LOC_Y = 50;

        private void aDDSCHOOLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        public void setlocation()
        {
            Form1 fm = new Form1();

            foreach (System.Windows.Forms.Control ctrl in panel2.Controls)
            {

                if (ctrl.Name.Contains("PNL"))
                {
                    ctrl.Left = LOC_X;
                    ctrl.Top = LOC_Y;
                }
            }
        }

        private void BTN_PNL_ADD_SCHOOL_CLOSE_Click(object sender, EventArgs e)
        {
            PNL_ADD_SCHOOL.Visible = false;
            PNL_POSTMARKS.Visible = true;
            setlocation();
        }
      public   SqlConnection con = new SqlConnection();
        private void BTN_SCHOOL_SAVE_Click(object sender, EventArgs e)
        {
           
            con.ConnectionString = constr;
            LBLMSG1.Text = save_school_SQL(con, Txt_schoolname.Text, Txt_userid.Text, Txt_pwd.Text);
        }
       
        private string save_school_SQL(SqlConnection con, string school, string uid, string pwd)
        {
            string str1 = "";

            SqlParameter @schname_ = new SqlParameter();
            SqlParameter @userid_ = new SqlParameter();
            SqlParameter @passwrd_ = new SqlParameter();
       string      sql = "INSERT INTO schools  ( schname, userid, passwrd) VALUES(@schname_,@userid_,@passwrd_)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@schname_", school);
            cmd.Parameters.AddWithValue("@userid_", uid);
            cmd.Parameters.AddWithValue("@passwrd_", pwd);

            con_open(con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                str1 = "School details inserted succefully.";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("PRIMARY"))
                {

                    update_school_SQL(con, uid, pwd);
                    con.Close();
                    str1 = "School details updated succefully.";
                }
                else
                    str1 = ex.Message;

            }
            return str1;
        }
        private void con_open(SqlConnection con1)
        {
            if (con1.State == ConnectionState.Closed) { con1.Open(); }
        }
        public string sql = "";

       

        private void CMB_SCHOOL_SelectedIndexChanged(object sender, EventArgs e)
        {

            string uid, pwd, condition = "schname='" + CMB_SCHOOL.SelectedItem + "'";
            READSQL_uid_pwd(con, "schools", "[userid],[passwrd]", condition, out uid, out pwd);
            TXT_USERID2.Text = uid;
            TXT_PWD1.Text = pwd;
        }
        private void READSQL_uid_pwd(SqlConnection con, string tABLE, string cOLUMNS, string condition, out string uid, out string pwd)
        {
            string sql = "select " + cOLUMNS + " from " + tABLE + " WHERE " + condition;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con_open(con);
            DataSet ds = new DataSet();
            da.Fill(ds, "data");
            Console.WriteLine(sql);
            //    Console.WriteLine( "  RECORDS:" + ds.Tables[0].Rows[0]["BS1"] + "--" + ds.Tables[0].Rows[0]["BS2"] + "--" + ds.Tables[0].Rows[0]["BS3"] + "--" + ds.Tables[0].Rows[0]["BS4"]);
            con.Close();
            uid = ds.Tables[0].Rows[0][0].ToString();
            pwd = ds.Tables[0].Rows[0][1].ToString();



        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveXpath(cmb_element.SelectedItem.ToString(), txt_xpath.Text, con);
        }

        private void aDDSCHOOLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PNL_ELEMENTS.Visible = true;
            PNL_POSTMARKS.Visible = false;
            PNL_ADD_SCHOOL.Visible = false;
            setlocation();
        }

        private void aDDELEMENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PNL_ADD_SCHOOL.Visible = true;
            PNL_POSTMARKS.Visible = false;
            PNL_ELEMENTS.Visible = false;
            setlocation();
        }
      public static  string  sscconstr = @"Data Source=MURTY\SQLEXPRESS;Initial Catalog=CMR;Persist Security Info=True;User ID=USRBOSS;Password=BNM20";
        SqlConnection ssccon = new SqlConnection(sscconstr);
        private void BTN_SSC_Click(object sender, EventArgs e)
        {
           // IWebDriver Driver = new ChromeDriver();
           IWebDriver Driver = new FirefoxDriver();
            String sql = "select * from [HNOS$] WHERE FNAME IS NULL ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, ssccon);
            con_open(ssccon);
            da.Fill(ds, "halltickets");
            ssccon.Close();
            string hno = "";
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://resultsbse.ap.gov.in/");
           
            string T, H, E, M, S, SS,TOTAL="",TEL_R,HIN_R,ENG_R,MAT_R,SCI_R,SS_R;
            string FNAME = "",SNAME="", RESULT="";
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                hno = ds.Tables[0].Rows[i][0].ToString();
                findById_Sendkeys(Driver, "txtHallTicketNo", hno);
                if (i==0)
                {
                    Thread.Sleep(10000);
                }
                findById_Click(Driver, "btnSubmit");
                Thread.Sleep(1000);

                T = Driver.FindElement(By.Id("lblGrPointFirstLang")).Text;
                H = Driver.FindElement(By.Id("lblGrPointSecLang")).Text;
                E = Driver.FindElement(By.Id("lblGrPointThirdLang")).Text;
                M = Driver.FindElement(By.Id("lblGrPointMath")).Text;
                S = Driver.FindElement(By.Id("lblGrPointSci")).Text;
                SS = Driver.FindElement(By.Id("lblGrPointSoc")).Text;
                
                RESULT= Driver.FindElement(By.Id("lblResult")).Text;
                SNAME= Driver.FindElement(By.Id("lblStudentName")).Text;
                FNAME = Driver.FindElement(By.Id("lblStudentFName")).Text;
                 TOTAL =  Driver.FindElement(By.Id("lblTotal")).Text ;
                TEL_R = GETRES(T);
                HIN_R = GETRES(H,"HIN");
                ENG_R = GETRES(E);
                MAT_R = GETRES(M);
                SCI_R = GETRES(S);
                SS_R = GETRES(SS);

                sql = "UPDATE [HNOS$] SET " +
                     "FNAME='" + FNAME + "'," + 
                     "NAME='" + SNAME + "'," +
                     "RESULTS='" + RESULT + "'," +
                     "TEL='" + T + "'," + 
                     "TOTAL='" + TOTAL + "'," +
                     "HIN='" + H + "'," +
                     "ENG='" + E + "'," +
                     "MAT='" + M + "'," +
                     "SCI='" + S + "'," +
                     "SS='" + SS + "'," +
                     "TEL_R='" + TEL_R + "'," +
                     "HIN_R='" + HIN_R + "'," +
                     "ENG_R='" + ENG_R + "'," +
                     "MAT_R='" + MAT_R + "'," +
                     "SCI_R='" + SCI_R + "'," +
                     "SS_R='" + SS_R + "'" +
                     " WHERE HNO= '"+hno+"'";
                SqlCommand CMD = new SqlCommand(sql, ssccon);
                con_open(ssccon);
                CMD.ExecuteNonQuery();
                ssccon.Close();
                T = "";
                H = "";
                E = "";
                M = "";
                S ="";
                SS = "";
                FNAME = "";
                SNAME = "";
                RESULT = "";
                TOTAL = "";


            }



        }

        private string GETRES(string t, string v)
        {
            string RES = "";
             if (t == " ")
            {
                RES = "NO RESULT";
            }
            else if(t != "AB")
            {

                if (int.Parse(t) < 20)
                    RES = "FAIL";
                else if (int.Parse(t) < 50)
                    RES = "THIRD";
                else if (int.Parse(t) < 60)
                    RES = "SECOND";
                else
                    RES = "FIRST";
            }
         
            else
            {
                RES = "ABSENT";
            }

            return RES;
        }

        private string GETRES(string t)
        {
            string RES = "";
            if (t != "AB")
            {

            if (int.Parse(t) < 35)
                    RES = "FAIL";
            else if (int.Parse(t) < 50)
                    RES = "THIRD";
            else if (int.Parse(t) < 60)
                    RES = "SECOND";
            else
                    RES = "FIRST";
            }
            else
            {
                RES = "ABSENT";
            }

            return RES;

        }

        private void findById_Click(IWebDriver Driver, string id)
        {
            try
            {
                Driver.FindElement(By.Id(id)).Click();


            }
            catch (Exception ex)
            {
               
            
                findById_Click(Driver, id);
            }


        }
        private void con_open1(SqlConnection con1)
        {
            if (con1.State == ConnectionState.Closed) { con1.Open(); }
        }
        public void findById_Sendkeys(IWebDriver Driver, string id, string sendkeys)
        {


            IWebElement TXTBOX = Driver.FindElement(By.Id(id));
            TXTBOX.Clear();
            TXTBOX.SendKeys(sendkeys);
           
        }
        public void findByxpath_Sendkeys(IWebDriver Driver, string xpath, string sendkeys, string ROWS)
        {
            Actions action = new Actions(Driver);
            Console.WriteLine(ROWS + "\r\n");
            
            // Driver.FindElement(By.XPath(xpath)).Click();
            Driver.FindElement(By.XPath(xpath)).Clear();
            Driver.FindElement(By.XPath(xpath)).SendKeys(sendkeys);
        }

        private void RAD_FA3_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "FA1";
            PMBOL.SAserviceXpath = PMBOL_CLASS.SA2_SERVICES_XPATH;
            PMBOL.SAmarksEntryXpath = PMBOL_CLASS.SA2_MARKS_ENTRY_XPATH;
        }

        private void sECTIONMAPPINGToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (TXT_USERID2.Text == "")
            {
                PMBOL.userid = PMBOL_CLASS.uid;
                PMBOL.password = PMBOL_CLASS.pwd;
            }
            else
            {
                PMBOL.userid = TXT_USERID2.Text;
                PMBOL.password = TXT_PWD1.Text;
            }


            PMBOL.MAPPING_CONDITION2 = " AND CLASS LIKE '%" + CMB_CLASS.SelectedItem.ToString() + "%'";
          

            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            LBLMSG.Text = PM_BLL_CLASS.Section_mapping_CHECK(PMBOL);
            this.WindowState = FormWindowState.Minimized;
        }

        private void BTN_CHILDINFO_Click(object sender, EventArgs e)
        {
            // BTN_CHILDINFO
            if (TXT_USERID2.Text == "")
            {
                PMBOL.userid = PMBOL_CLASS.uid;
                PMBOL.password = PMBOL_CLASS.pwd;
            }
            else
            {
                PMBOL.userid = TXT_USERID2.Text;
                PMBOL.password = TXT_PWD1.Text;
            }


            PMBOL.CHILDINFO_CONDITION2 = " AND   admnno>"+int.Parse(TXT_FROM.Text) +" and admnno <"+ int.Parse(TXT_TO.Text);
            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            LBLMSG.Text = PM_BLL_CLASS.CHILDINFO_CHECK(PMBOL);
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (TXT_USERID2.Text == "")
            {
                PMBOL.userid = PMBOL_CLASS.uid;
                PMBOL.password = PMBOL_CLASS.pwd;
            }
            else
            {
                PMBOL.userid = TXT_USERID2.Text;
                PMBOL.password = TXT_PWD1.Text;
            }

            PMBOL.CHILDINFO_CONDITION2 = " AND   admnno>" + int.Parse(TXT_FROM.Text) + " and admnno <" + int.Parse(TXT_TO.Text);
            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            LBLMSG.Text = PM_BLL_CLASS.GET_CHILDID_CHECK(PMBOL);
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (TXT_USERID2.Text == "")
            {
                PMBOL.userid = PMBOL_CLASS.uid;
                PMBOL.password = PMBOL_CLASS.pwd;
            }
            else
            {
                PMBOL.userid = TXT_USERID2.Text;
                PMBOL.password = TXT_PWD1.Text;
            }


            PMBOL.MAPPING_CONDITION2 = " AND CLASS LIKE '%" + CMB_CLASS.SelectedItem.ToString() + "%'";


            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            LBLMSG.Text = PM_BLL_CLASS.GET_PROFILE(PMBOL);
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                       constr= " Data Source=MURTY\\SQLEXPRESS;" +  constr.Substring(constr.Split(';')[0].Length + 1, constr.Length - (constr.Split(';')[0].Length + 1));
                        break;
                    }
                case 1:
                    {
                        constr = " Data Source=MURTY\\SQLSERVER;" + constr.Substring(constr.Split(';')[0].Length + 1, constr.Length - (constr.Split(';')[0].Length + 1));
                        break;
                    }
                case 2:
                    {
                        constr = " Data Source=BSSH\\SQLEXPRESS;" + constr.Substring(constr.Split(';')[0].Length + 1, constr.Length - (constr.Split(';')[0].Length + 1));
                        break;
                    }
            }

            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_count_markss_notPosted_Click(object sender, EventArgs e)
        {
            if (TXT_USERID2.Text == "")
            {
                PMBOL.userid = PMBOL_CLASS.uid;
                PMBOL.password = PMBOL_CLASS.pwd;
            }
            else
            {
                PMBOL.userid = TXT_USERID2.Text;
                PMBOL.password = TXT_PWD1.Text;
            }



            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            
            LBLMSG.Text = PM_BLL_CLASS.MARKS_UPDATED_CHECK(PMBOL);
            this.WindowState = FormWindowState.Minimized;

        }

        private void update_school_SQL(SqlConnection con, string uid, string pwd)
        {

            SqlParameter @schname_ = new SqlParameter();
            SqlParameter @userid_ = new SqlParameter();
            SqlParameter @passwrd_ = new SqlParameter();
            sql = "update schools  set  passwrd=@passwrd_ where userid=@userid_";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@userid_", uid);
            cmd.Parameters.AddWithValue("@passwrd_", pwd);

            con_open(con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

    }
}

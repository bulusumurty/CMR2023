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
using OpenQA.Selenium.DevTools.V100.DOM;

namespace POSTMARKS2._0
{
    public partial class FRM_GET_MARKS : Form
    {
        public FRM_GET_MARKS()
        {
            InitializeComponent();
        }
        PMBOL_CLASS PMBOL = new PMBOL_CLASS();

        private void BTN_GET_MARKS_Click(object sender, EventArgs e)
        {
            try
            {
               // CMB_CLASS.SelectedIndex = 2;
                if (TXT_USERID.Text == "")
                {
                    PMBOL.userid = PMBOL_CLASS.uid;
                    PMBOL.password = PMBOL_CLASS.pwd;
                }
                else
                {
                    PMBOL.userid = TXT_USERID.Text;
                    PMBOL.password = TXT_PASSWORD.Text;
                }


            //    PMBOL.MAPPING_CONDITION2 = " AND CLASS LIKE '%" + CMB_CLASS.SelectedItem.ToString() + "%'";


                PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
                LBLMSG.Text = PM_BLL_CLASS.CHECK_INPUT_TO_LOAD_WEBSITE(PMBOL);
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message.ToString());
            }
            //this.WindowState = FormWindowState.Minimized;
        }

        

        private void CMB_CLASS_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PMBOL. = CMB_CLASS.SelectedItem.ToString();
            DATA_ONLINE DO = new DATA_ONLINE();
            DO.student_mapping_CLASS_SECTION = "AND NEW_CLASS=" + CMB_CLASS.SelectedItem + " AND NEW_SEC='" + CMB_SECMAP_SEC.SelectedItem + "'";

        }

        private void RAD_FA1_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "FA1";
            PMBOL.FAserviceXpath = PMBOL_CLASS.FA1_SERVICES_XPATH;
            PMBOL.FAREPORTSXpath = PMBOL_CLASS.FA1_CCE_MARKS_REPORT_XPATH;
        }

        private void RAD_FA2_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "FA2";
            PMBOL.FAserviceXpath = PMBOL_CLASS.FA2_SERVICES_XPATH;
            PMBOL.FAREPORTSXpath = PMBOL_CLASS.FA2_CCE_MARKS_REPORT_XPATH;
        }

        private void RAD_FA3_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "FA3";
            PMBOL.FAserviceXpath = PMBOL_CLASS.FA3_SERVICES_XPATH;
            PMBOL.FAREPORTSXpath = PMBOL_CLASS.FA3_CCE_MARKS_REPORT_XPATH;
        }

        private void RAD_FA4_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "FA4";
            PMBOL.FAserviceXpath = PMBOL_CLASS.FA4_SERVICES_XPATH;
            PMBOL.FAREPORTSXpath = PMBOL_CLASS.FA4_CCE_MARKS_REPORT_XPATH;
        }

        private void FRM_GET_MARKS_Load(object sender, EventArgs e)
        {
                   }
        /// <summary>
        /// //////////////////////SSC RESULT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver Driver = new FirefoxDriver();
          DataSet ds=  ReaderSqlData();
            load_website(Driver);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string hno2 = "", name = "", fname = "", result = "", gtotal = "", tel = "", hin = "", eng = "", mat = "", sci = "", ss = "";
                //HNO
                Driver.FindElement(By.Id("htno")).Clear();

                Driver.FindElement(By.Id("htno")).SendKeys(ds.Tables[0].Rows[i][0].ToString());Thread.Sleep(1000);
                Driver.FindElement(By.Id("btnsubmit")).Click(); Thread.Sleep(500);
                hno2 = findByid_getText(Driver, "sid0");
                name = findByid_getText(Driver, "sid1");
             
                fname= findByid_getText(Driver, "sid2");
                gtotal = findByid_getText(Driver, "sid21");
                result = findByid_getText(Driver, "sid22");

                tel = (findByid_getText(Driver, "sid3"));
                hin = (findByid_getText(Driver, "sid6"));
            eng = (findByid_getText(Driver, "sid9"));
            mat = (findByid_getText(Driver, "sid12"));
            sci = (findByid_getText(Driver, "sid15"));
            ss = (findByid_getText(Driver, "sid18"));
                string sql_update = "update [dbo].[HNOS2023$]" +
                      "set [NAME] ='" + name + "' , " +
                      "[FNAME] ='" + fname + "' , " +
                      "[RESULTS] ='" + result + "' , " +
                      "[TOTAL]  ='" + gtotal + "' , " +
                      "[TEL]  ='" + tel + "' , " +
                      "[HIN] ='" + hin + "' , " +
                      "[ENG] ='" + eng + "' , " +
                      "[MAT] ='" + mat + "' , " +
                      "[SCI] ='" + sci + "' , " +
                      "[SS] ='" + ss + "' where " +
                      "hno='"+hno2+"';";
                SqlCommand cmd =new SqlCommand (sql_update,con);
                con_open(con);
                cmd.ExecuteNonQuery ();
                con.Close ();



        }




        }
        private string findByxpath_getText(IWebDriver driver, string getdataxpath)
        {
            Actions action = new Actions(driver);
           
                return driver.FindElement(By.XPath(getdataxpath)).Text;
           
            
        }
        private string findByid_getText(IWebDriver driver, string getdataid)
        {
            Actions action = new Actions(driver);

            return driver.FindElement(By.Id(getdataid)).Text;


        }
       public static SqlConnection con = new SqlConnection("server=MURTY\\SQLEXPRESS; database=CMR2023;User ID=USRBOSS;Password=BNM20");
        // con.ConnectionString = "server=MURTY\\SQLEXPRESS; database=CMR2023;User ID=USRBOSS;Password=BNM20";
       
        private DataSet ReaderSqlData()
        {
            con.Open();
            string sql = "select HNO from HNOS2023$ where tel is null and hno is not null";
            
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con_open(con);
            DataSet ds = new DataSet();
            da.Fill(ds, "data");
            con.Close();
            return ds;

        }
        private void con_open(SqlConnection con1)
        {
            if (con1.State == ConnectionState.Closed) { con1.Open(); }
        }
        public void load_website(IWebDriver Driver)
        {
            PMBOL_CLASS BOL = new PMBOL_CLASS();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(PMBOL_CLASS.SSCurl);
        }

        private void BTN_GETMARKS_Click(object sender, EventArgs e)
        {
           // CMB_CLASS.SelectedIndex = 2;
            if (TXT_USERID.Text == "")
            {
                PMBOL.userid = PMBOL_CLASS.uid;
                PMBOL.password = PMBOL_CLASS.pwd;
            }
            else
            {
                PMBOL.userid = TXT_USERID.Text;
                PMBOL.password = TXT_PASSWORD.Text;
            }


            PMBOL.MAPPING_CONDITION2 = " AND NEW_CLASS LIKE '%" + CMB_CLASS.SelectedItem.ToString() + "%' AND NEW_SEC  LIKE '%" + CMB_SECMAP_SEC.SelectedItem.ToString() + "%' AND (REMARK='NO' OR REMARK='FAILED' or REMARK='Unable to locat' or REMARK='Cannot locate e')";

            PMBOL.CLASS=CMB_CLASS.SelectedItem.ToString();
            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            LBLMSG.Text = PM_BLL_CLASS.CHECK_INPUT_TO_section_map(PMBOL);
            //this.WindowState = FormWindowState.Minimized;
           
        }
        public string[] sections = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "R", "T", "U", "V", "W", "X", "Y", "Z"};

        private void BTNqUIT_Click(object sender, EventArgs e)
        {
            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            PM_BLL_CLASS.QUIT();
            FRM_GET_MARKS_Load(sender, e);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
         
            PM_BLL_CLASS.getElement_title(PMBOL);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "SA1";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            PMBOL.TEST = "SA2";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PMBOL.SECMAP_CLASS = CMB_CLASS.SelectedItem.ToString();
            PMBOL.SECMAP_SECTION = CMB_SECMAP_SEC.SelectedItem.ToString();


            PMBLL_CLASS PM_BLL_CLASS = new PMBLL_CLASS();
            LBLMSG.Text = PM_BLL_CLASS.CHECK_INPUT_TO_RESET_SECMAP(PMBOL);


        }
    }
}

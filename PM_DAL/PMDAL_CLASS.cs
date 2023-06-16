using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using PMBOL;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.IE;
using SeleniumExtras.WaitHelpers;
using System.Security.Claims;
using OpenQA.Selenium.DevTools.V100.Browser;
using System.Reflection;
using System.Security.Cryptography;

namespace PM_DAL
{
    public class PMDAL_CLASS
    {
        public IWebDriver Driver;
        public static string constr= ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public void getElement_title(PMBOL_CLASS pMBOL)
        {
            string x = "";int[]indexes = new int[5];
            int j = 0, k = 0;
            for (int i = 1; i <  (Driver1.FindElements(By.XPath("(//span)"))).Count; i++)
            {
                x = Driver1.FindElement(By.XPath("(//span)["+i+"]")).Text.ToString();

                if (x.Replace(" ","").ToUpper() == "CCEMARKS")
                {
                  
                    Driver1.FindElement(By.XPath("(//span)[" + i + "]")).Click(); Thread.Sleep(1000);
                    j = i;
                    k = i;
                    break;
                }
             }

            // services
            for (int i =j; i < (Driver1.FindElements(By.XPath("(//span)"))).Count; i++)
            {
                x = Driver1.FindElement(By.XPath("(//span)[" + i + "]")).Text.ToString();

                 if (x.ToUpper().Contains(pMBOL.TEST))
                {
                    Driver1.FindElement(By.XPath("(//span)[" + i + "]")).Click(); Thread.Sleep(1000);
                    j = i;
                    break;
                }               
            }
            // reports
            for (int i = j; i < (Driver1.FindElements(By.XPath("(//span)"))).Count; i++)
            {
                x = Driver1.FindElement(By.XPath("(//span)[" + i + "]")).Text.ToString();

              
                if (x.Replace(" ", "").ToUpper().Contains("STUDENTWISE"))
                {
                    Driver1.FindElement(By.XPath("(//span)[" + i + "]")).Click(); Thread.Sleep(1000);
                    break;
                }
            }

            Driver1.FindElement(By.XPath("(//span)[" + k + "]")).Click(); Thread.Sleep(1000);

            // selct class
            //SELECT[@ID='student_class']//option[contains(.,'7')]
            int cls = int.Parse(pMBOL.CLASS);
            Driver1.FindElement(By.XPath("//SELECT[@ID='student_class']")).Click(); Thread.Sleep(1000);
            Driver1.FindElement(By.XPath("//SELECT[@ID='student_class']//option[contains(.,"+cls+")]")).Click(); Thread.Sleep(1000);
            char[] SEC = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            for (int i = 0; i < 3; i++)
            {
                //select[@id='student_section']
                Driver1.FindElement(By.XPath("//select[@id='student_section']")).Click(); Thread.Sleep(1000);
                Driver1.FindElement(By.XPath("//select[@ID='student_section']//option[contains(.,'" + SEC[i] + "')]")).Click(); Thread.Sleep(100);

            }
            Thread.Sleep(5000);

          string y=  Driver1.FindElement(By.XPath("(//tr)[4]//td[34]")).Text;
        }
        public String findByxpath_Click(IWebDriver Driver, string xpath, int TIME_DELAY)
        {
            String RES = "";
            try
            {
                if (xpath != null)
                {
                    Thread.Sleep(TIME_DELAY);
                   IWebElement ITEM= Driver.FindElement(By.XPath(xpath));
                    if (ITEM.Displayed == true)
                    {
                        ITEM.Click();
                        RES = "TRUE";
                    }
                    else
                        RES = "FALSE";
                  
                }
                return RES;
            }
            catch (Exception EX)
            {

                if (EX.Message.Contains("TIME"))
                {
                    findByxpath_Click(Driver, xpath, 10 * TIME_DELAY);
                }
                else
                {
                    //ClickShiftTab(Driver, xpath, TIME_DELAY);
                    RES = "FAIL";
                }

            }

            return RES;
        }

        private void ClickShiftTab(IWebDriver Driver, string xpath, int TIME_DELAY)
        {
            Actions action = new Actions(Driver);

            actionShiftTab(action);
            findByxpath_Click(Driver, xpath, 10 * TIME_DELAY);
        }

        public void findByCssSelector_Click(IWebDriver Driver, string CssSelector)
        {

            Driver.FindElement(By.CssSelector(CssSelector)).Click();

        }
        public void findById_checkbox_check_yes(IWebDriver Driver, string id)
        {
            string RES = "";
            IWebElement checkbox = Driver.FindElement(By.Id(id));
            if (checkbox.Selected == false)
            {
                checkbox.Click();

            }

        }
        public void findById_Click(IWebDriver Driver, string id, int TIME_DELAY)
        {
            try
            {
                Thread.Sleep(TIME_DELAY);
                Driver.FindElement(By.Id(id)).Click();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("stopped by the user or " + ex.Message.ToString());
            }


        }

        public void findById_CLICK_ND_Sendkeys2(IWebDriver Driver, string id, string sendkeys,int delay)
        {
            Thread.Sleep(delay*2);
         //   Driver.FindElement(By.Id(id)).Click();
            Driver.FindElement(By.Id(id)).Clear();
            Thread.Sleep(delay * 2);
            Driver.FindElement(By.Id(id)).SendKeys(sendkeys);

        }


    public void findById_CLICK_ND_Sendkeys(IWebDriver Driver, string id, string sendkeys,string row)
        {
            try
            {
                Console.WriteLine(row+"---"+id + "\r\n");
                Driver.FindElement(By.Id(id)).Click();
            }
            catch (Exception ex)
            {

            
                findById_CLICK_ND_Sendkeys(Driver, id, sendkeys,row);

            }
            
            IWebElement TXTBOX = Driver.FindElement(By.Id(id));
           // Thread.Sleep(100);
            TXTBOX.Clear();
            TXTBOX.SendKeys(sendkeys);
            //Actions action = new Actions(Driver);
            //action.SendKeys(Keys.Tab)
            //   .Build()
            //   .Perform();
        }
        public void findById_Sendkeys(IWebDriver Driver, string id, string sendkeys)
        {
            
            IWebElement TXTBOX = Driver.FindElement(By.Id(id));
            TXTBOX.Clear();
            TXTBOX.SendKeys(sendkeys);
            //Actions action = new Actions(Driver);
            //action.SendKeys(Keys.Tab)
            //   .Build()
            //   .Perform();
        }
        public void findByxpath_Sendkeys(IWebDriver Driver, string xpath, string sendkeys)
        {
            Driver.FindElement(By.XPath(xpath)).SendKeys(sendkeys);
        }
        public void findByxpath_Sendkeys(IWebDriver Driver, string xpath, string sendkeys, string ROWS)
        {
            Actions action = new Actions(Driver);
            Console.WriteLine(ROWS+ "\r\n");
            clickTAB(action);
           // Driver.FindElement(By.XPath(xpath)).Click();
            Driver.FindElement(By.XPath(xpath)).Clear();
            Driver.FindElement(By.XPath(xpath)).SendKeys(sendkeys);
        }
        public void postmarks_db(PMBOL_CLASS PMBOL)
        {
          //IWebDriver Driver = new ChromeDriver();
            IWebDriver Driver = new FirefoxDriver();

            load_website(Driver);
            Thread.Sleep(1000);
           
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            findByxpath_Click(Driver, PMBOL_CLASS.POPUP_XPATH,100);
            DEPTLOGiN(Driver, 100);
            EnterUserid(Driver, PMBOL, 100);
            Enterpassword(Driver, PMBOL, 10);
            signin_emp(Driver, 10000);
            ClickOnCCEmarks(Driver, 1000);

            ////List<IWebElement> spanelements = Driver.FindElements(By.XPath("//span"));
            //var spanelements = Driver.FindElements(By.XPath("//span"));
            //for (int i = 0; i < spanelements.Count; i++)
            //{
            //    //Driver.FindElements(By.XPath("//input[@type='checkbox']"))
            //    Console.Write(spanelements[i].Text);
            //}

            //;

            clickdownarrow(Driver);
            Thread.Sleep(1000);
            Clicksa1Service(Driver, PMBOL, 100);
            clickdownarrow(Driver);

            Thread.Sleep(1000); 
            Clicksa1MarksEntry(Driver, PMBOL, 100);


            post_marks(Driver, PMBOL, 1000);
           

        }

        public void MARKS_UPDATED_CHECK_db(PMBOL_CLASS PMBOL)
        {
            //IWebDriver Driver = new ChromeDriver();
            IWebDriver Driver = new FirefoxDriver();

            load_website(Driver);
            Thread.Sleep(1000);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            findByxpath_Click(Driver, PMBOL_CLASS.POPUP_XPATH, 100);
            DEPTLOGiN(Driver, 100);
            EnterUserid(Driver, PMBOL, 100);
            Enterpassword(Driver, PMBOL, 10);
            signin_emp(Driver, 10000);
            ClickOnCCEmarks(Driver, 5000);

            ////List<IWebElement> spanelements = Driver.FindElements(By.XPath("//span"));
            //var spanelements = Driver.FindElements(By.XPath("//span"));
            //for (int i = 0; i < spanelements.Count; i++)
            //{
            //    //Driver.FindElements(By.XPath("//input[@type='checkbox']"))
            //    Console.Write(spanelements[i].Text);
            //}

            //;

            clickdownarrow(Driver);
            Thread.Sleep(1000);
            Clicksa1Service(Driver, PMBOL, 100);
            clickdownarrow(Driver);

            Thread.Sleep(1000);
            Clicksa1MarksEntry(Driver, PMBOL, 100);


            MARKS_UPDATED_CHECK(Driver, PMBOL, 1000);


        }
        public void MARKS_UPDATED_CHECK(IWebDriver Driver, PMBOL_CLASS PMBOL, int TIME_DELAY)
        {
            // IWebDriver driver = new ChromeDriver();
            //  IWebDriver driver = new FirefoxDriver();

            Actions action = new Actions(Driver);


            // PMBOL_CLASS PMBOL = new PMBOL_CLASS();
            String[] SECTION = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int ROWS = 0;
            DataSet DS = new DataSet();
            int FIRST_ROW_IS_AT = 0;

            for (int index = PMBOL.SUBJECT_int; index < PMBOL.totalsubjects[PMBOL.CLASS_int]; index++)
            {

                select_subject(PMBOL, index);

                for (int i = 1 + PMBOL.SECTION; i < 2 + PMBOL.SECTIONS; i++)
                {

                    select_class(Driver, int.Parse(PMBOL.CLASS), TIME_DELAY * 1);
                    select_SECTION(Driver, SECTION[i - 2], 600);
                    select_SUBJECT_CLASS6(Driver, PMBOL, index, 600);

                    // findById_Click(Driver, PMBOL_CLASS.student_subject, 1000);
                    IWebElement ddl = Driver.FindElement(By.Id(PMBOL_CLASS.student_subject));
                    SelectElement select = new SelectElement(ddl);

                    switch (PMBOL.CLASS_int)
                    {
                        case 1:
                        case 2:
                            select.SelectByText(PMBOL.subjects[PMBOL.subjects1to2[index]]);
                            break;
                        case 3:
                        case 4:
                        case 5:

                            select.SelectByText(PMBOL.subjects[PMBOL.subjects3to5[index]]);
                            break;
                        case 6:
                        case 7:
                  
                            select.SelectByText(PMBOL.subjects[PMBOL.subjects6_7[index]]);
                            break;

                        case 81:
                        case 102:
                            select.SelectByText(PMBOL.subjects[PMBOL.subjects8_10[index]]);
                            break;
                        case 8:
                        case 9:
                        case 10:
                            select.SelectByText(PMBOL.subjects[PMBOL.subjects9[index]]);
                            break;


                    }


                    CLICK_ON_GETDATA(Driver, TIME_DELAY);

                    ROWS = get_total_records(Driver);

                    PMBOL.records_completed = 0;
                    // StringBuilder ds_childids = READSQLROWS(con, PMBOL, "CHILDID", PMBOL.ISEMPTY);
                    SqlParameter @class = new SqlParameter();
                    SqlParameter @section = new SqlParameter();
                    SqlParameter @subject = new SqlParameter();
                    SqlParameter @exam = new SqlParameter();
                    SqlParameter @total = new SqlParameter();

                    string sql = "INSERT INTO [dbo].[MARKS_UPDATE]([CLASS],[SECTION],[SUBJECT],[EXAM],[TOTAL]) VALUES(@class,@section,@subject,@exam,@total)";
                    SqlCommand cmd = new SqlCommand(sql, con);



        cmd.Parameters.AddWithValue("@class", READ_DROPDOWN(Driver, "student_class"));
        cmd.Parameters.AddWithValue("@section", READ_DROPDOWN(Driver, "student_section"));
        cmd.Parameters.AddWithValue("@subject", READ_DROPDOWN(Driver, "student_subject"));
        cmd.Parameters.AddWithValue("@exam", PMBOL.TEST);
        cmd.Parameters.AddWithValue("@total", ROWS);
                    con_open(con);

                   
                    cmd.ExecuteNonQuery();
                    con.Close();
 
                   

                   

                }

            }
        }

        private static string READ_DROPDOWN(IWebDriver driver,string dropdown_list_Id)
        {
            IWebElement dropdown = driver.FindElement(By.Id(dropdown_list_Id));

            // Create a SelectElement object and pass in the dropdown control
            SelectElement select = new SelectElement(dropdown);

            // Get the currently selected item
            return select.SelectedOption.Text;
        }

        public void SECTION_MAPPING_db(PMBOL_CLASS PMBOL)
        {
           // IWebDriver Driver = new ChromeDriver();
           IWebDriver Driver = new FirefoxDriver();

            load_website(Driver);
            Thread.Sleep(1000);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            findByxpath_Click(Driver, PMBOL_CLASS.POPUP_XPATH, 100);
            DEPTLOGiN(Driver, 100);
            EnterUserid(Driver, PMBOL, 100);
            Enterpassword(Driver, PMBOL, 10);
            signin_emp(Driver, 10000);
           
            ClickOnAdmissions(Driver, 1000);

            Actions action = new Actions(Driver);
            clickOnEditStudent(Driver, PMBOL, 10);
            DataSet ds = new DataSet();
            ds= READSQLToDataset(con, PMBOL_CLASS.student2022, PMBOL_CLASS.student_mapping_columns, PMBOL_CLASS.student_mapping_CONDITION + PMBOL.MAPPING_CONDITION2);
           // String DIST = "";
            
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                try
                {
                    PMBOL.CHILDID = ds.Tables[0].Rows[i][0].ToString();
                    EnterChildId(Driver, PMBOL.CHILDID, 500);
                         //     findById_Click(Driver, "student_section");
                  movedown(action);
                    //  Console.WriteLine(Driver.FindElement(By.Id("student_class_admitted")).Text);
                    IWebElement ClassStudying = Driver.FindElement(By.Id("student_class_admitted"));
                    SelectElement select = new SelectElement(ClassStudying);
                    if (select.SelectedOption.Text.Contains("Select"))
                    {
                        select.SelectByText("6");
                    }

                    Thread.Sleep(500);
                    clickOn_SecMap_Getdata(Driver, PMBOL_CLASS.stu_getdata_xpath, 100);
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 
                    select_maping_SECTION(Driver, PMBOL_CLASS.student_section, ds.Tables[0].Rows[i][1].ToString(), 100, PMBOL);
                    Thread.Sleep(500);


                    select_distance(Driver, PMBOL_CLASS.stuDistance, 200);

                        select_modeOfTransport(Driver, PMBOL_CLASS.transport_mode, "Auto", 100);
                        movedown(action);

                        click_mapingSubmit(Driver, PMBOL_CLASS.mapingsubmit, 100);

                        Driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/div[1]")).Click();
                        //IAlert alert = Driver.SwitchTo().Alert();
                        //Thread.Sleep(100);
                        //alert.Accept();
                        //Driver.SwitchTo().DefaultContent();
                        SAVERECORD(con, ds, i);
                    
                    
                }
                catch (Exception EX)
                {

                   
                }
            }

           

        }
        public static IWebDriver Driver1 = new FirefoxDriver();
        public void GET_MARKS_DB(PMBOL_CLASS PMBOL)
        {
           
            findByxpath_Click(Driver1, PMBOL_CLASS.CCE_MARKS_XPATH, 1000);
            findByxpath_Click(Driver1, PMBOL.FAserviceXpath, 100);
            findByxpath_Click(Driver1, PMBOL.FAREPORTSXpath, 100);
        }

        public string  section_map_DB(PMBOL_CLASS PMBOL)
        {

            findByxpath_Click(Driver1, PMBOL_CLASS.Admissions_Exit_XPATH, 1000);
            findByxpath_Click(Driver1, PMBOL_CLASS.Edit_Student_Admission_Details_XPATH, 1000);
            section_mapping(Driver1, PMBOL);
            return "mapping is over";
        }
        // SECMAP2023
        private void section_mapping(IWebDriver driver1, PMBOL_CLASS pMBOL_CLASS)
        {
            string CHID = "", SEC = "";
            
         DataSet   ds = READSQLToDataset(con, DATA_ONLINE.ATTENDANCE_TABLE, DATA_ONLINE.student_mapping_columns, DATA_ONLINE.student_mapping_CONDITION+" "+ pMBOL_CLASS.MAPPING_CONDITION2);
             
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                CHID = ds.Tables[0].Rows[i][0].ToString();
                SEC= ds.Tables[0].Rows[i][1].ToString();
                findById_Sendkeys(Driver1, "stud_id", CHID);
                findByxpath_Click(Driver1, "//div[text()=\"GET DETAILS\"]", 1000);
                Thread.Sleep(1000);
                try
                {
                    // CLS ADMITTED
                    IWebElement ddl_CLS_ADMIT = Driver1.FindElement(By.Id("student_class_admitted"));
                    SelectElement select1 = new SelectElement(ddl_CLS_ADMIT);
                    select1.SelectByText("6");

                    IWebElement ddl = Driver1.FindElement(By.Id("student_section"));
                    SelectElement select = new SelectElement(ddl);
                    select.SelectByText(SEC);
                    
                        IWebElement TXT_DISTANCE = Driver1.FindElement(By.Id("distance"));
                    TXT_DISTANCE.Clear();
                    TXT_DISTANCE.SendKeys("5");
                    select_modeOfTransport(Driver1, PMBOL_CLASS.transport_mode, "Auto", 100);
                    findByxpath_Click(Driver1, "(//*[contains(text(), 'SUBMIT')])[2]", 100);
                    Thread.Sleep(1000);
                    
                    if( findByxpath_Click(Driver1, "/html/body/div[4]/div/div/div[2]/div/div[1]", 100)=="TRUE")

                    Update_ADMN_DATA(con,CHID,"YES");
                    else
                        Update_ADMN_DATA(con, CHID, "FAILED");

                }
                catch (Exception EX )
                {
                    Update_ADMN_DATA(con, CHID, EX.Message.Substring(0,15));

                }
                 
            }





        }

        private void Update_ADMN_DATA(SqlConnection con, string cHID,String REMARK)
        {
            String SQL = "UPDATE ADMN_DATA SET REMARK ='" + REMARK + "' WHERE CHID='" + cHID + "'";
            SqlCommand cmd = new SqlCommand(SQL, con);
            con_open(con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void LOAD_WEBSITE(PMBOL_CLASS PMBOL)
        {
            // IWebDriver Driver = new ChromeDriver();
            //IWebDriver Driver = new FirefoxDriver();
            string name = "", cls = "", seconline = "";
            load_website(Driver1);
            Thread.Sleep(1000);

            Driver1.SwitchTo().Window(Driver1.WindowHandles.Last());
            findByxpath_Click(Driver1, PMBOL_CLASS.POPUP_XPATH, 100);
            DEPTLOGiN(Driver1, 100);
            EnterUserid(Driver1, PMBOL, 100);
            Enterpassword(Driver1, PMBOL, 10);
            signin_emp(Driver1, 10000);
            
            //findByxpath_Click(Driver1, PMBOL_CLASS.CCE_MARKS_XPATH, 1000);
            //findByxpath_Click(Driver1, PMBOL.FAserviceXpath, 100);
            //findByxpath_Click(Driver1, PMBOL.FAREPORTSXpath, 100);
        }
        public void GET_STUDENT_DATA_db(PMBOL_CLASS PMBOL)
        {
            // IWebDriver Driver = new ChromeDriver();
            IWebDriver Driver = new FirefoxDriver();
            string name = "",cls="",seconline="";
            load_website(Driver);
            Thread.Sleep(1000);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            findByxpath_Click(Driver, PMBOL_CLASS.POPUP_XPATH, 100);
            DEPTLOGiN(Driver, 100);
            EnterUserid(Driver, PMBOL, 100);
            Enterpassword(Driver, PMBOL, 10);
            signin_emp(Driver, 10000);

            ClickOnAdmissions(Driver, 1000);

            Actions action = new Actions(Driver);
            clickOnEditStudent(Driver, PMBOL, 10);
            Thread.Sleep(5000);
            DataSet ds = new DataSet();
            ds = READSQLToDataset(con, DATA_ONLINE.DATA_ONLINE_TABLE, DATA_ONLINE.student_mapping_columns, DATA_ONLINE.student_mapping_CONDITION  );
            // String DIST = "";
            DATA_ONLINE dATA_ONLINE = new DATA_ONLINE();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                try
                {
                    dATA_ONLINE.CHILDID = "";
                    dATA_ONLINE.NAME_ONLINE = "";
                    dATA_ONLINE.CLASS_ONLINE = "";
                    dATA_ONLINE.SEC_ONLINE="";
                    dATA_ONLINE.CHILDID = ds.Tables[0].Rows[i][0].ToString();
                    EnterChildId(Driver, dATA_ONLINE.CHILDID, 100);
                    clickOn_SecMap_Getdata(Driver, PMBOL_CLASS.stu_getdata_xpath, 100);
                    //findById_Click(Driver, "student_section");
                    ////  Console.WriteLine(Driver.FindElement(By.Id("student_class_admitted")).Text);
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    IWebElement ClassStudying = Driver.FindElement(By.Id("student_class_admitted"));
                    // name of the student
                    IWebElement admnno= Driver.FindElement(By.Id("admission_no"));
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    dATA_ONLINE.ADMNNO = admnno.GetAttribute("value");
                    
                        dATA_ONLINE.NAME_ONLINE = Driver.FindElement(By.XPath(DATA_ONLINE.NAME_ONLINE_XPATH)).Text;
                        //class studying
                        SelectElement select = new SelectElement(ClassStudying);
                        dATA_ONLINE.CLASS_ONLINE = select.SelectedOption.Text;

                        //
                        IWebElement section = Driver.FindElement(By.Id(PMBOL_CLASS.student_section));
                        //section
                        SelectElement select_section = new SelectElement(section);
                        dATA_ONLINE.SEC_ONLINE = select_section.SelectedOption.Text;
                    
                        moveup(action);
                     
                    SAVE_ONLINE_RECORD(con, dATA_ONLINE);
                    EnterChildId(Driver, "REC:"+i, 100);
                    Thread.Sleep(500);
                }
                catch (Exception)
                {
                    
                    SAVE_ONLINE_ErrorRECORD(con, dATA_ONLINE);
                    dATA_ONLINE.CHILDID = "";
                    dATA_ONLINE.NAME_ONLINE = "";
                    dATA_ONLINE.CLASS_ONLINE = "";
                    dATA_ONLINE.SEC_ONLINE = "";
                }
            }



        }
     
        
        private void SAVE_ONLINE_ErrorRECORD(SqlConnection con,DATA_ONLINE dATA_ONLINE)
        {
            string SQL = "";
            SQL = "UPDATE  [DATA_ONLINE$] SET   " +
                " [NAMEONLINE]='ERROR'," +
                " [CLASSONLINE]='ERROR'," +
                  " [NAME2]='ERROR'," +
                " [SECONLINE]='ERROR'" +
                "WHERE CHILDID ='" + dATA_ONLINE.CHILDID + "'";
            SqlCommand cmd = new SqlCommand(SQL, con);
            con_open(con);
            cmd.ExecuteNonQuery();
            con.Close();
            dATA_ONLINE.NAME_ONLINE = "";
            dATA_ONLINE.CLASS_ONLINE = "";
            dATA_ONLINE.SEC_ONLINE = "";
            dATA_ONLINE.CHILDID = "";

        }

        public void CHANGE_PWD_INSPIRE_db(PMBOL_CLASS PMBOL)
        {
            //IWebDriver Driver = new ChromeDriver();
            IWebDriver Driver = new FirefoxDriver();

            load_website(Driver);
            Thread.Sleep(1000);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            findByxpath_Click(Driver, PMBOL_CLASS.POPUP_XPATH, 100);
            DEPTLOGiN(Driver, 100);
            EnterUserid(Driver, PMBOL, 100);
            Enterpassword(Driver, PMBOL, 10);
            signin_emp(Driver, 10000);

            ClickOnAdmissions(Driver, 1000);

            Actions action = new Actions(Driver);
            clickOnEditStudent(Driver, PMBOL, 10);
            DataSet ds = new DataSet();
            ds = READSQLToDataset(con, PMBOL_CLASS.student2022, PMBOL_CLASS.student_mapping_columns, PMBOL_CLASS.student_mapping_CONDITION + PMBOL.MAPPING_CONDITION2);
            String DIST = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                try
                {

                    EnterChildId(Driver, ds.Tables[0].Rows[i][0].ToString(), 500);
                    clickOn_SecMap_Getdata(Driver, PMBOL_CLASS.stu_getdata_xpath, 100);
                    findById_Click(Driver, "student_section");
                    //  Console.WriteLine(Driver.FindElement(By.Id("student_class_admitted")).Text);
                    IWebElement ClassStudying = Driver.FindElement(By.Id("student_class_admitted"));
                    SelectElement select = new SelectElement(ClassStudying);
                    if (select.SelectedOption.Text.Contains("Select"))
                    {
                        select.SelectByText("6");
                    }


                    select_maping_SECTION(Driver, PMBOL_CLASS.student_section, ds.Tables[0].Rows[i][1].ToString(), 1000,PMBOL);
                    movedown(action);
                    select_distance(Driver, PMBOL_CLASS.stuDistance, 500);

                    select_modeOfTransport(Driver, PMBOL_CLASS.transport_mode, "Auto", 100);
                    movedown(action);

                    click_mapingSubmit(Driver, PMBOL_CLASS.mapingsubmit, 100);

                    Driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/div[1]")).Click();
                    //IAlert alert = Driver.SwitchTo().Alert();
                    //Thread.Sleep(100);
                    //alert.Accept();
                    //Driver.SwitchTo().DefaultContent();
                    SAVERECORD(con, ds, i);
                }
                catch (Exception EX)
                {


                }
            }



        }

        public void GET_CHILDID_db(PMBOL_CLASS PMBOL)
        {
            string CHILDID = "", GENDER="";
            string NAME = "";
            string AADHAR = "", CLASS2="";

            // IWebDriver Driver = new InternetExplorerDriver();
              IWebDriver Driver = new FirefoxDriver();
           // IWebDriver Driver = new ChromeDriver();

            Actions action = new Actions(Driver);

            load_website(Driver);
            Thread.Sleep(1000);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            findByxpath_Click(Driver, PMBOL_CLASS.POPUP_XPATH, 100);
            DEPTLOGiN(Driver, 100);
            EnterUserid(Driver, PMBOL, 100);
            Enterpassword(Driver, PMBOL, 10);
            signin_emp(Driver, 10000);

            ClickOnAdmissions(Driver, 1000);


            ACTIVE_INACTIVE(Driver, PMBOL, 1000);

            DataSet ds = new DataSet();
            //ds = READSQLToDataset(con, PMBOL_CLASS.CHILDINFO2022, PMBOL_CLASS.CHILDINFO_columns, PMBOL_CLASS.CHILDINFO_CONDITION + PMBOL.CHILDINFO_CONDITION2);
            //ds = READSQLToDataset(con, PMBOL_CLASS.CHILDINFO2022, PMBOL_CLASS.CHILDINFO_columns, " CHILDID IS NULL AND AADHAR NOT IN (SELECT AADHAR FROM CHINFO_DATA) AND LEN(AADHAR)=12");
            ds = READSQLToDataset(con, PMBOL_CLASS.CHILDINFO2022, PMBOL_CLASS.CHILDINFO_columns, " CHILDID IS NULL");
            String DIST = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
             
             try
                {
                EnterChildAADHAR(Driver, ds.Tables[0].Rows[i][5].ToString(), 100);

                clickOn_childinfo_Getdata(Driver, PMBOL_CLASS.childinfoGetdata_xpath, 500);
                Thread.Sleep(1000);

                    CHILDID= Driver.FindElement(By.XPath(PMBOL_CLASS.CHID_XPATH)).Text;
                    NAME= Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[2]")).Text;
                    AADHAR= Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[2]/table/tbody/tr[2]/td[1]")).Text;
                    CLASS2 = Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[2]/table/tbody/tr[2]/td[2]")).Text;
                    GENDER = Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[2]/table/tbody/tr[3]/td[1]")).Text;
                    string sql = "insert into chinfo_data([CHILDID],[NAME],[AADHAR],[CLASS_STD],GENDER) values(" +
                        "'"+CHILDID+"','"+NAME+"','"+AADHAR+"','"+CLASS2+"','"+GENDER+"')";
                    sql=sql+ " UPDATE CHILDINFO$ SET CHILDID='"+CHILDID+"' WHERE AADHAR='"+AADHAR+"'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con_open(con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    CHILDID = "";
                    NAME = "";
                    AADHAR = ""; CLASS2 = "";
                }
                catch (Exception EX)
                {

                


                }
            }

        }
        public void CHILDINFO_db(PMBOL_CLASS PMBOL)
        {
            //IWebDriver Driver = new ChromeDriver();
            IWebDriver Driver = new FirefoxDriver();
            Actions action = new Actions(Driver);

            load_website(Driver);
            Thread.Sleep(1000);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            findByxpath_Click(Driver, PMBOL_CLASS.POPUP_XPATH, 100);
            DEPTLOGiN(Driver, 100);
            EnterUserid(Driver, PMBOL, 100);
            Enterpassword(Driver, PMBOL, 10);
            signin_emp(Driver, 10000);

            ClickOnAdmissions(Driver, 1000);

          
            ACTIVE_INACTIVE(Driver, PMBOL, 1000);

            DataSet ds = new DataSet();
            //ds = READSQLToDataset(con, PMBOL_CLASS.CHILDINFO2022, PMBOL_CLASS.CHILDINFO_columns, PMBOL_CLASS.CHILDINFO_CONDITION + PMBOL.CHILDINFO_CONDITION2);
            ds = READSQLToDataset(con, PMBOL_CLASS.CHILDINFO2022, PMBOL_CLASS.CHILDINFO_columns, PMBOL_CLASS.CHILDINFO_CONDITION  );
            String DIST = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                PMBOL.CHINFO_DOA_DD = ds.Tables[0].Rows[i][6].ToString();
                PMBOL.CHINFO_ADMNNO = ds.Tables[0].Rows[i][0].ToString();
                PMBOL.CHINFO_MEDIUM = ds.Tables[0].Rows[i][4].ToString();
                PMBOL.CHINFO_CLASS = ds.Tables[0].Rows[i][3].ToString();
                if (PMBOL.CHINFO_CLASS == "6")
                    PMBOL.CHINFO_SECTION = "D";
                else if (PMBOL.CHINFO_CLASS == "7")
                    PMBOL.CHINFO_SECTION = "s";
                else if (PMBOL.CHINFO_CLASS == "8")
                    PMBOL.CHINFO_SECTION = "U";
                else if (PMBOL.CHINFO_CLASS == "9")
                    PMBOL.CHINFO_SECTION = "Y";
                else if (PMBOL.CHINFO_CLASS == "10")
                    PMBOL.CHINFO_SECTION = "Y";

                EnterChildAADHAR(Driver, ds.Tables[0].Rows[i][5].ToString(), 100);

                clickOn_childinfo_Getdata(Driver, PMBOL_CLASS.childinfoGetdata_xpath, 500);
                Thread.Sleep(500);

                movedown(action);
        
                //  findById_Click(Driver, "student_section");
                try
                {
                    Console.WriteLine(Driver.FindElement(By.XPath(PMBOL_CLASS.CHID_XPATH)).Text);
                    findById_Sendkeys(Driver, PMBOL_CLASS.ADMNNO_ID, ds.Tables[0].Rows[i][0].ToString());
                    // medium

                    select_chinfo_ddlById(Driver, PMBOL_CLASS.MEDIUM_ID, PMBOL.CHINFO_MEDIUM, 100);
                    //section
                    select_chinfo_ddlById(Driver, PMBOL_CLASS.student_section, PMBOL.CHINFO_SECTION, 100);
                    //class
                    select_chinfo_ddlByxpath(Driver, PMBOL_CLASS.PRESENTCLASSS_XPATH, PMBOL.CHINFO_CLASS, 100);

                    //      Driver.FindElement(By.Id("admin_date")).Clear();

                    selectDate(Driver, PMBOL.CHINFO_DOA_DD+"/"+ PMBOL.CHINFO_DOA_MM+"/"+ PMBOL.CHINFO_DOA_YY, action);
                    Thread.Sleep(3000);
                    movedown(action);
                    Thread.Sleep(1000);
                  //  Driver.FindElement(By.XPath(PMBOL_CLASS.JOIN_XPATH)).Click();
                    Thread.Sleep(1000);
                    Driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/div[1]")).Click();
                    Thread.Sleep(200);

                    SAVERECORD(con, ds, i);
                    ACTIVE_INACTIVE(Driver, PMBOL, 1000);
                }
                catch (Exception EX)
                {



                    if (EX.Message.Contains("locate"))
                    {
                       // SAVEchildinfo(con, ds, i, "NoReg");
                    }

                }
            }

        }

        private static void movedown(Actions action)
        {
            action.SendKeys(Keys.PageDown);
            action.Perform();
            Thread.Sleep(500);
        }
        private static void press_key_down(Actions action)
        {
            action.SendKeys(Keys.ArrowDown)
                ;
            action.Perform();
            Thread.Sleep(500);
        }


        private static void moveup(Actions action)
        {
            action.SendKeys(Keys.PageUp);
            action.Perform();
            Thread.Sleep(500);
        }

        private void selectchinfoclass(IWebDriver driver, string cHINFO_SECTION, int v)
        {
           
        }

        private void selectDate(IWebDriver driver, string DD,
            Actions action)
        {
            String DDXPATH = "";
           
           
            switch (DD)
            {
                case "1":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[1]/td[6]";
                    break;
                case "2":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[1]/td[7]";
                    break;
                case "3":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[2]/td[1]";

                    break;
                case "4":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[2]/td[2]";
                    break;
                case "5":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[2]/td[3]";
                    break;
                case "6":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[2]/td[4]";
                    break;
                case "7":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[2]/td[5]";
                    break;
                case "8":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[2]/td[6]";
                    break;
                case "9":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[2]/td[7]";

                    break;
                case "10":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[3]/td[1]";
                    break;
                case "11":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[3]/td[2]";
                    break;
                case "12":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[3]/td[3]";
                    break;
                case "13":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[3]/td[4]";
                    break;
                case "14":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[3]/td[5]";
                    break;
                case "15":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[3]/td[6]";
                    break;
                case "16":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[3]/td[7]";
                    break;
                case "17":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[4]/td[1]";
                    break;
                case "18":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[4]/td[2]";
                    break;
                case "19":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[4]/td[3]";
                    break;
                case "20":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[4]/td[4]";
                    break;
                case "21":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[4]/td[5]";
                    break;
                case "22":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[4]/td[6]";
                    break;
                case "23":
                    DDXPATH = "/html/body/div[5]/div[1]/table/tbody/tr[4]/td[7]";
                    break;
            }

            driver.FindElement(By.Id("admin_date")).SendKeys(DD);
            driver.FindElement(By.Id("admin_date")).SendKeys(DD);
            //movedown(action);
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath(DDXPATH)).Click();
            //Thread.Sleep(1000);

        }

        private void SAVEchildinfo(SqlConnection con, DataSet ds,int row,string remark)
        {
            string admnno = "", NAME = "", SEC = "", SEC_ONLINE = "" , _remark="";
            admnno = ds.Tables[0].Rows[row][0].ToString();
            NAME = ds.Tables[0].Rows[row][1].ToString();
            _remark = remark;


            string SQL = "INSERT INTO [CMR].[dbo].[CHINFO_REPORT] ([ADMNNO] ,[NAME],REMARK) VALUES('" + admnno + "','" + NAME + "','" + _remark + "'); UPDATE  CHILDINFO$ SET REMARK = '"+remark+ "' WHERE admnno ='" + admnno + "'";
            SqlCommand cmd = new SqlCommand(SQL, con);
            con_open(con);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void SAVERECORD(SqlConnection con, DataSet ds,int row)
        {
            string CHID = "", NAME = "", SEC = "", SEC_ONLINE = "";
            CHID = ds.Tables[0].Rows[row][0].ToString();
            NAME = ds.Tables[0].Rows[row][2].ToString();
            SEC = ds.Tables[0].Rows[row][3].ToString();
            SEC_ONLINE = ds.Tables[0].Rows[row][1].ToString();


            string SQL = "INSERT INTO [CMR].[dbo].[STUMAPING_REPORT] ([CHID] ,[NAME],[SEC],[SEC_ONLINE]) VALUES('" + CHID + "','" + NAME + "','" + SEC + "','" + SEC_ONLINE + "'); UPDATE  STU2022$ SET REMARK = 'YES' WHERE CHILDID ='"+CHID+"'";
            SqlCommand cmd = new SqlCommand(SQL, con);
            con_open(con);
            cmd.ExecuteNonQuery();
            con.Close();


        }
        private void SAVE_ONLINE_RECORD(SqlConnection con ,DATA_ONLINE dATA_ONLINE)
        {
            string SQL = "";
           SQL = "UPDATE  [DATA_ONLINE$] SET   " +
               " [NAMEONLINE]='" + dATA_ONLINE.NAME_ONLINE + "'," +
               " [CLASSONLINE]='" + dATA_ONLINE.CLASS_ONLINE + "'," +
               " [NAME2]='" + dATA_ONLINE.NAME_ONLINE + "'," +
               " [admnno]='" + dATA_ONLINE.ADMNNO + "'," +
               " [SECONLINE]='" + dATA_ONLINE.SEC_ONLINE+"'" +
               "WHERE CHILDID ='" + dATA_ONLINE.CHILDID + "'";
            SqlCommand cmd = new SqlCommand(SQL, con);
            con_open(con);
            cmd.ExecuteNonQuery();
            con.Close();
            dATA_ONLINE.NAME_ONLINE = "";
            dATA_ONLINE.CLASS_ONLINE = "";
            dATA_ONLINE.SEC_ONLINE = "";
            dATA_ONLINE.CHILDID = "";

        }

        private void click_mapingSubmit(IWebDriver driver, string mapingsubmit, int v)
        {
        //    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
          
            findByxpath_Click(driver, mapingsubmit, v);
        }

        private void select_modeOfTransport(IWebDriver driver, string id, string transport, int delay)
        {
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(delay);
            IWebElement ddl = driver.FindElement(By.Id(id));

            SelectElement select = new SelectElement(ddl);
            select.SelectByText(transport);


        }
        private void select_distance(IWebDriver driver, string stuDistance, int delay)
        { 
            IWebElement DISTANCE=  driver.FindElement(By.Id(stuDistance));

       //     Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            findById_CLICK_ND_Sendkeys2(driver, stuDistance, "3", delay);
             
        }
        private void select_chinfo_ddlByxpath(IWebDriver driver, string id, string section, int delay)
        {
            Thread.Sleep(delay);
            IWebElement ddl = driver.FindElement(By.XPath(id));
            SelectElement select = new SelectElement(ddl);
            select.SelectByText(section);
        }
        private void select_chinfo_ddlById(IWebDriver driver, string id, string section, int delay)
        {
            Thread.Sleep(delay);
            IWebElement ddl = driver.FindElement(By.Id(id));
            SelectElement select = new SelectElement(ddl);
            select.SelectByText(section);
        }
        private string select_maping_SECTION(IWebDriver driver, string id, string section, int delay, PMBOL_CLASS PMBOL)
        {
            string res = "";
            // WebDriverWait  wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
            /// Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           

            IWebElement ddl =  driver.FindElement(By.Id(id));
            SelectElement selectElement = new SelectElement(driver.FindElement(By.Id(id)));
           
            var selectedValue = selectElement.SelectedOption.GetAttribute("text");
            Console.WriteLine(PMBOL.CHILDID + ","+PMBOL.CHILDNAME+","+PMBOL.CLASS+"," + selectedValue + " to " + section);
            if (selectedValue != section)
            {

            SelectElement select = new SelectElement(ddl);
            
            select.SelectByText(section);
                res = "NO";
            }
            else
                res = "YES";


            return res;

        }
        private void clickOn_childinfo_Getdata(IWebDriver driver, string childinfo_getdata_xpath, int delay)
        {
            findByxpath_Click(driver, childinfo_getdata_xpath, delay);
            
        }
        private void clickOn_SecMap_Getdata(IWebDriver driver, string stu_getdata_xpath, int delay)
        {
            findByxpath_Click(driver, PMBOL_CLASS.stu_getdata_xpath , delay);
        }
        public void EnterChildAADHAR(IWebDriver driver, string childid, int delay)
        {
            
            findById_CLICK_ND_Sendkeys2(driver, PMBOL_CLASS.AADHAR_ID, childid, delay);

        }
        public void EnterChildId(IWebDriver driver, string childid, int delay)
        {
            findById_CLICK_ND_Sendkeys2(driver, PMBOL_CLASS.stu_map_Chid_id, childid, delay);
          
        }
        private void ACTIVE_INACTIVE(IWebDriver driver, PMBOL_CLASS pMBOL, int v)
        {
            Thread.Sleep(v);

            // findByxpath_Click(Driver, PMBOL_CLASS.ADMISSIONS_css, v);
            findByxpath_Click(driver, PMBOL_CLASS.ACTIVE_INACTIVE_XPATH, 100);
        }
        private void clickOnEditStudent(IWebDriver driver, PMBOL_CLASS pMBOL, int v)
        {
            Thread.Sleep(v);

            // findByxpath_Click(Driver, PMBOL_CLASS.ADMISSIONS_css, v);
            findByxpath_Click(driver, PMBOL_CLASS.Edit_Student_Details,100);
        }

        private void ClickOnAdmissions(IWebDriver driver, int v)
        {
            Thread.Sleep(v);

           // findByxpath_Click(Driver, PMBOL_CLASS.ADMISSIONS_css, v);
            findByxpath_Click(driver, PMBOL_CLASS.ADMISSIONS_EXIT_XPATH,v);
        }

        public static SqlConnection con = new SqlConnection(constr);
        public IWebElement element;

        public void post_marks(IWebDriver Driver, PMBOL_CLASS PMBOL, int TIME_DELAY)
        {
            // IWebDriver driver = new ChromeDriver();
          //  IWebDriver driver = new FirefoxDriver();

            Actions action = new Actions(Driver);

            
            // PMBOL_CLASS PMBOL = new PMBOL_CLASS();
            String[] SECTION = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int ROWS=0;
            DataSet DS=new DataSet ();
            int FIRST_ROW_IS_AT = 0;
          
            for (int index = PMBOL.SUBJECT_int; index < PMBOL.totalsubjects[PMBOL.CLASS_int]; index++)
            {
               
                select_subject(PMBOL, index);
                
                for (int i =1+ PMBOL.SECTION; i < 2 + PMBOL.SECTIONS; i++)
                {

                    select_class(Driver, int.Parse(PMBOL.CLASS), TIME_DELAY*1 );
                    select_SECTION(Driver, SECTION[i - 2], 10);
                    select_SUBJECT_CLASS6(Driver, PMBOL,index, 600 );
                  
                   // findById_Click(Driver, PMBOL_CLASS.student_subject, 1000);
                    IWebElement ddl = Driver.FindElement(By.Id(PMBOL_CLASS.student_subject));
                    SelectElement select = new SelectElement(ddl);

                    switch (PMBOL.CLASS_int)
                    {
                        case 1:
                        case 2:
                            select.SelectByText(PMBOL.subjects[PMBOL.subjects1to2[index]]);
                            break;
                        case 3:
                        case 4:
                        case 5:

                            select.SelectByText(PMBOL.subjects[PMBOL.subjects3to5[index]]);
                            break;
                        case 6:
                        case 7:
                            select.SelectByText(PMBOL.subjects[PMBOL.subjects6_7[index]]);
                            break;

                        case 8:
                        case 10:
                            select.SelectByText(PMBOL.subjects[PMBOL.subjects8_10[index]]);
                            break;
                        case 9:
                            select.SelectByText(PMBOL.subjects[PMBOL.subjects9[index]]);
                            break;


                    }
                

                    CLICK_ON_GETDATA(Driver, TIME_DELAY);
                  
                    ROWS = get_total_records(Driver);

                    PMBOL.records_completed = 0;
                    StringBuilder ds_childids = READSQLROWS(con, PMBOL,"CHILDID", PMBOL.ISEMPTY );
                    for (int ROW = FIRST_ROW_IS_AT; ROW < ROWS; ROW++)
                    {
                        // Driver.FindElement(By.LinkText("CCE Marks")).Click();
                        if (ROW == FIRST_ROW_IS_AT)
                        {
                            findByxpath_Click(Driver, PMBOL_CLASS.btntoggle, 1000);
                        }
                        Thread.Sleep(1000);
                        StringBuilder ds_marks = new StringBuilder();
                        PMBOL.CHILDID = getchildid(Driver, ROW); 
                        PMBOL.CHILDNAME  = getchildNAME(Driver, ROW);
                        PMBOL.condition = " CHILDID='" + PMBOL.CHILDID + "'";
                        // string s= contitions_toolsLimit(PMBOL.SUBJECT);
                        if (ds_childids.ToString().Contains(PMBOL.CHILDID))
                        { 

                            ds_marks = READSQL(con, PMBOL.TABLE, PMBOL.SUBJECTWISE_COLUMNS, PMBOL.ISEMPTY + " and " + PMBOL.condition +" AND "+PMBOL.TOOLS_LIMIT);


                            if (ds_marks.Length > 0)
                            {

                                PMBOL.CHECKBOXXPATH = GET_CHECKBOX_XPATH(ROW);

                                string[] toolxpath = { "", "", "", "", "", "" };
                                findByxpath_Click(Driver, PMBOL.CHECKBOXXPATH, 100);
                                select_present(Driver, getattendance_Id(Driver, ROW + 1));
                                //  setattendance_present(Driver, ROW + 1);
                                // Driver.Findby(By.XPath(PMBOL.CHECKBOXXPATH)).Click();
                                //  findByCssSelector_Click(Driver, "#check_no_" + (ROW+1).ToString());

                                // string  marks = "";

                                // Thread.Sleep(1000);
                                int col = 0;
                                for (col = 0; col < PMBOL.tools; col++)
                                {


                                    toolxpath[col] = "//*[@id='t" + (col + 1).ToString() + "_marks_" + (ROW + 1).ToString() + "']";
                                    // element = Driver.FindElement(By.XPath(toolxpath[col]));

                                    findByxpath_Sendkeys(Driver, toolxpath[col],
                                        ds_marks.ToString().Split(',')[col], ROW.ToString() + "/" + ROWS.ToString());

                                }
                                moveLeft(Driver, action, ROW);



                                // Thread.Sleep(300);


                                ds_marks.Clear();


                                PMBOL.records_completed++;

                            }
                            else
                            {
                               


                                Console.WriteLine("row is at:" + FIRST_ROW_IS_AT + "child id:" + ROW + " " + " data not found");
                            }
                            if (PMBOL.records_completed == 20)
                            {

                                break;

                            }
                        }
                        else
                        {
                            ds_marks = READSQL(con, PMBOL.TABLE, PMBOL_CLASS.REMARK, " not ("+PMBOL.ISEMPTY + ") and " + PMBOL.condition );
                            if (ds_marks.ToString() == "LA")
                            {

                                PMBOL.CHECKBOXXPATH = GET_CHECKBOX_XPATH(ROW);

                                string[] toolxpath = { "", "", "", "", "", "" };
                                findByxpath_Click(Driver, PMBOL.CHECKBOXXPATH, 100);
                                select_ABSENT(Driver, getattendance_Id(Driver, ROW + 1));
                                PMBOL.records_completed++;
                            }

                                Console.WriteLine(PMBOL.CHILDID+"  NOT FOUND");
                        }
                        if (PMBOL.records_completed == 0)
                            FIRST_ROW_IS_AT = ROW;
                    }//bnm

                   IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
                    //clickTAB(action);
                    //clickTAB(action);
                    Thread.Sleep(1000);
                    clickarrow(Driver,action,ROWS-1);
                    Thread.Sleep(1000);
              //      clickrIGHTARROW(action);
                    jse.ExecuteScript("window.scrollBy(100,30000)");
                    try
                    {
                    Driver.FindElement(By.XPath("//*[@id=\"myTable\"]/tbody/tr[" + ROWS + "]/td[3]")).Click();
                   
                    Thread.Sleep(1000);
                        if (PMBOL.records_completed >0)
                        {

                            Thread.Sleep(1000);
                       
                            findById_Click(Driver, "myBtn");
                            IAlert alert = Driver.SwitchTo().Alert();
                            Thread.Sleep(1000);
                            alert.Accept();
                            Driver.SwitchTo().DefaultContent();
                        }
                        if (ROWS > 0)
                        {
                            
                            if (PMBOL.rowsincycle2 != PMBOL.rowsincycle1)
                            {
                            i--;
                            PMBOL.rowsincycle2 = PMBOL.rowsincycle1;
                            PMBOL.rowsincycle1 = ROWS;
                            }
                            else
                            {
                                PMBOL.rowsincycle2 = -1;
                                FIRST_ROW_IS_AT = 0;
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }

                }

            }
        }

      
        public void SectionMapping(IWebDriver Driver, PMBOL_CLASS PMBOL, int TIME_DELAY)
        {
            
            Actions action = new Actions(Driver);


          
        }


        private void moveLeft(IWebDriver Driver, Actions action, int rOW)
        {
           
            clickarrow(Driver, action,rOW);
        }

        private static void actionShiftTab(Actions action)
        {
            action.KeyDown(Keys.Shift)
                .SendKeys(Keys.Tab)
                .KeyUp(Keys.Shift)
                .Build().Perform();
        }

        private static void clickTAB(Actions action)
        {
          
            action.SendKeys(Keys.Tab )
                  .Build()
                  .Perform();
        }
        private static void clickrIGHTARROW(Actions action)
        {

            action.SendKeys(Keys.ArrowRight)
                              .Build()
                  .Perform();
        }

        private static void clickarrow(IWebDriver Driver, Actions action1,int rOW)
        {
            try
            {
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"myTable\"]/tbody/tr[" + (rOW + 1).ToString() + "]/td[15]"));
                Console.WriteLine("//*[@id=\"myTable\"]/tbody/tr[" + (rOW + 1).ToString() + "]/td[15]");
                Actions action = new Actions(Driver);
                // Thread.Sleep(100);
                action.MoveToElement(element)
                    .Click()
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                       .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                       .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                       .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                       .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                       .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                       .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .SendKeys(Keys.ArrowLeft)
                      .Build()
                      .Perform();
            }
            catch (Exception)
            {

                
            }
        }
        private static void clickdownarrow(IWebDriver Driver )
        {
            try
            {
                //IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"myTable\"]/tbody/tr[" + (rOW + 1).ToString() + "]/td[15]"));
                //Console.WriteLine("//*[@id=\"myTable\"]/tbody/tr[" + (rOW + 1).ToString() + "]/td[15]");
                Actions action = new Actions(Driver);
                // Thread.Sleep(100);
                action.SendKeys(Keys.PageDown)
                      .SendKeys(Keys.ArrowDown)
                      .SendKeys(Keys.ArrowDown)
                      .SendKeys(Keys.ArrowDown)
                      .SendKeys(Keys.ArrowDown)
                      .SendKeys(Keys.ArrowDown)
                      .SendKeys(Keys.ArrowDown)
                      .SendKeys(Keys.ArrowDown)
                      .Build()
                      .Perform();
            }
            catch (Exception)
            {


            }
        }

        private static void select_subject(PMBOL_CLASS PMBOL, int index)
        {
            PMBOL.SUBJECT_int = index;
           
            switch (PMBOL.CLASS)
            {
                case "1":
                case "2":
                    PMBOL.SUBJECT = PMBOL.subjects[PMBOL.subjects1to2[index]];

                    break;
                case "3":
                case "4":
                case "5":
                    PMBOL.SUBJECT = PMBOL.subjects[PMBOL.subjects3to5[index]];

                    break;
                case "6":
                case "7":
            
                    PMBOL.SUBJECT = PMBOL.subjects[PMBOL.subjects6_7[index]];
                    break;

                case "9":
                case "8":
                case "10":
                      PMBOL.SUBJECT = PMBOL.subjects[PMBOL.subjects9[index]];

                    break;
                    //case "8":
                    //case "10":
                    //    PMBOL.SUBJECT = PMBOL.subjects[PMBOL.subjects8_10[index]];
                    //    break;
            }
            select_subject_columns( PMBOL);
        }
        public static void select_subject_columns(PMBOL_CLASS PMBOL)
        {
            switch (PMBOL.SUBJECT)
            {
                case "Telugu":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL_COL[int.Parse(PMBOL.CLASS)];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL_ISEMPTY[int.Parse(PMBOL.CLASS)];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL_COL_limit[PMBOL.CLASS_int];
                    break;
                case "First language Telugu":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL_COL[PMBOL.CLASS_int];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL_ISEMPTY[PMBOL.CLASS_int];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL_COL_limit[PMBOL.CLASS_int];
                    break;
                case "First language Telugu Paper I":

                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL1_COL_LIMIT[0];
                    break;
                case "First language Telugu Paper II":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.TEL2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.TEL2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.TEL_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.TEL2_COL_LIMIT[0];
                    break;

                case "Second language Hindi":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.HIN_COL[int.Parse(PMBOL.CLASS)];
                    PMBOL.ISEMPTY = PMBOL_CLASS.HIN_ISEMPTY[int.Parse(PMBOL.CLASS)];
                    PMBOL.tools = PMBOL_CLASS.HIN_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.HIN_COL_limit[int.Parse(PMBOL.CLASS)];
                    break;
                case "English":
                case "Thrird language English":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG_COL[int.Parse(PMBOL.CLASS)];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG_ISEMPTY[int.Parse(PMBOL.CLASS)];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG_COL_LIMIT[int.Parse(PMBOL.CLASS)];
                    break;
                case "Thrird language English Paper I":

                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG1_COL_LIMIT[0];
                    break;
                case "Thrird language English Paper II":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.ENG2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.ENG2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.ENG_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.ENG2_COL_LIMIT[0];
                    break;
                case "Mathematics":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT_COL[int.Parse(PMBOL.CLASS)];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT_ISEMPTY[int.Parse(PMBOL.CLASS)];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT_COL_LIMIT[int.Parse(PMBOL.CLASS)];
                    break;
                case "Mathematics Paper":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT_COL[PMBOL.CLASS_int];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT_ISEMPTY[PMBOL.CLASS_int];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT_COL_LIMIT[PMBOL.CLASS_int];
                    break;
                case "Mathematics Paper I":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT1_COL_LIMIT[0];
                    break;
                case "Mathematics Paper II":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.MAT2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.MAT2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.MAT_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.MAT2_COL_LIMIT[0];
                    break;
                case "Physical Science":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.PS_COL[int.Parse(PMBOL.CLASS)];
                    PMBOL.ISEMPTY = PMBOL_CLASS.PS_ISEMPTY[int.Parse(PMBOL.CLASS)];
                    PMBOL.tools = PMBOL_CLASS.PS_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.PS_COL_LIMIT[int.Parse(PMBOL.CLASS)];

                    break;
                case "General Science":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.GS_COL[int.Parse(PMBOL.CLASS)];
                    PMBOL.ISEMPTY = PMBOL_CLASS.GS_ISEMPTY[int.Parse(PMBOL.CLASS)];
                    PMBOL.tools = PMBOL_CLASS.GS_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.GS_COL_LIMIT[int.Parse(PMBOL.CLASS)];

                    break;
                case "Biological Science":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.BS_COL[int.Parse(PMBOL.CLASS)];
                    PMBOL.ISEMPTY = PMBOL_CLASS.BS_ISEMPTY[int.Parse(PMBOL.CLASS)];
                    PMBOL.tools = PMBOL_CLASS.BS_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.BS_COL_LIMIT[int.Parse(PMBOL.CLASS)];

                    break;
                case "Social Studies":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS_COL[int.Parse(PMBOL.CLASS)];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS_ISEMPTY[int.Parse(PMBOL.CLASS)];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS_COL_LIMIT[int.Parse(PMBOL.CLASS)];


                    break;
                case "Social Studies Paper":
                 PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS_COL[PMBOL.CLASS_int];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS_ISEMPTY[PMBOL.CLASS_int];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS_COL_LIMIT[PMBOL.CLASS_int];

                    break;
                case "Social Studies Paper I":

                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS1_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS1_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS1_COL_LIMIT[0];

                    break;
                case "Social Studies Paper II":
                    PMBOL.SUBJECTWISE_COLUMNS = PMBOL_CLASS.SS2_COL[0];
                    PMBOL.ISEMPTY = PMBOL_CLASS.SS2_ISEMPTY[0];
                    PMBOL.tools = PMBOL_CLASS.SS_tools[int.Parse(PMBOL.CLASS)];
                    PMBOL.TOOLS_LIMIT = PMBOL_CLASS.SS2_COL_LIMIT[0];
                    break;
            }
        }
        private void findById_Click(IWebDriver Driver, string id)
        {
            try
            {
                 Driver.FindElement(By.Id(id)).Click();
               

                }
            catch (Exception ex)
            {
                Actions action = new Actions(Driver);
                clickrIGHTARROW(action);
                //Console.WriteLine("stopped by the user or " + ex.Message.ToString());
               // findById_Click(Driver, id);
            }


        }
        private void select_present(IWebDriver Driver, string id)
        {
            try
            {
                
                IWebElement ddl = Driver.FindElement(By.Id(id));
                SelectElement select = new SelectElement(ddl);
                Thread.Sleep(500);
                select.SelectByText("Present");

            }
            catch (Exception ex)
            {
                Console.WriteLine("stopped by the user or " + ex.Message.ToString());
            }


        }
        private void select_ABSENT(IWebDriver Driver, string id)
        {
            try
            {

                IWebElement ddl = Driver.FindElement(By.Id(id));
                SelectElement select = new SelectElement(ddl);
                Thread.Sleep(500);
                select.SelectByText("Abcent");

            }
            catch (Exception ex)
            {
                Console.WriteLine("stopped by the user or " + ex.Message.ToString());
            }


        }

        private string GET_CHECKBOX_XPATH(int rOW)
        {
            return "//*[@id='check_no_" + (rOW  + 1).ToString() + "']";
        }

        private StringBuilder READSQLROWS_ALL_SECTIONS(SqlConnection con, PMBOL_CLASS PMBOL, string cOLUMNS, string condition)
        {
            StringBuilder marksstr = new StringBuilder();
            string sql = "select " + cOLUMNS + " from " + PMBOL.TABLE + " WHERE " + condition;
            Console.WriteLine(sql);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con_open(con);
            DataSet ds = new DataSet();
            da.Fill(ds, "data");
            con.Close();  marksstr.Append("");
            if (ds.Tables[0].Rows.Count>0)
            {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    marksstr.Append(ds.Tables[0].Rows[i][0].ToString());
                    marksstr.Append(",");
                }
                else
                    continue;

            }
            if(marksstr.Length>0)
            marksstr.Remove(marksstr.Length - 1, 1);
           // Console.WriteLine(sql);            
            }
            return marksstr;
        }

        private StringBuilder READSQLROWS(SqlConnection con, PMBOL_CLASS PMBOL, string cOLUMNS, string condition)
        {
            StringBuilder marksstr = new StringBuilder();
            string sql = "select " + cOLUMNS + " from " + PMBOL.TABLE + " WHERE " + condition;
            Console.WriteLine(sql);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con_open(con);
            DataSet ds = new DataSet();
            da.Fill(ds, "data");
            con.Close(); marksstr.Append("");
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        marksstr.Append(ds.Tables[0].Rows[i][0].ToString());
                        marksstr.Append(",");
                    }
                    else
                        continue;

                }
                if (marksstr.Length > 0)
                    marksstr.Remove(marksstr.Length - 1, 1);
                // Console.WriteLine(sql);            
            }
            return marksstr;
        }




        private StringBuilder READSQL(SqlConnection con, string tABLE, string cOLUMNS, string condition)
        {
            StringBuilder marksstr = new StringBuilder();
            string sql = "select " + cOLUMNS + " from " + tABLE + " WHERE " + condition;
            Console.WriteLine(sql);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con_open(con);
            DataSet ds = new DataSet();
            da.Fill(ds, "data");
            con.Close(); marksstr.Append("");
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        marksstr.Append(ds.Tables[0].Rows[0][i].ToString());
                        marksstr.Append(",");

                    }
                    else
                        continue;

                }
                if (marksstr.Length > 0)
                    marksstr.Remove(marksstr.Length - 1, 1);
                // Console.WriteLine(sql);            
            }
            return marksstr;
        }
        private DataSet READSQLToDataset(SqlConnection con, string tABLE, string cOLUMNS, string condition)
        {
          
            string sql = "select " + cOLUMNS + " from " + tABLE + " WHERE " + condition;
            Console.WriteLine(sql);
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
        public string gettoolXpath(IWebDriver Driver, int rowno, int col)
        {
            string tool_XPATH = "t" + col + "_marks_" + (rowno).ToString(); ;
            return tool_XPATH;

        }
        public string getattendance_Id(IWebDriver Driver, int rowno)
        {
            string tool_XPATH = "";
            //*[@id="t-3_student_attendance_1"]
        

                tool_XPATH = "t1_student_attendance_" + (rowno).ToString();
        

            return tool_XPATH;

        }
        public void setattendance_present(IWebDriver Driver, int rowno)
        {
            Thread.Sleep(200);
            string present_XPATH = "//*[@id=\"t1_student_attendance_"+rowno+"\"]/option[2]";

            findByxpath_Click(Driver, present_XPATH, 1);
        }
        public void setattendance_absent(IWebDriver Driver, int rowno)
        {
            string present_XPATH = "//*[@id=\"t1_student_attendance_" + rowno + "\"]/option[3]";

            findByxpath_Click(Driver, present_XPATH, 100);
        }
        public string getchildid(IWebDriver Driver, int rowno)
        {
            rowno++;
            string CHID_XPATH = "//*[@id=\"myTable\"]/tbody/tr[" + rowno + "]/td[2]";
            return findByxpath_getText(Driver, CHID_XPATH);


        }
        public string getchildNAME(IWebDriver Driver, int rowno)
        {
            rowno++;
            string CHID_XPATH = "//*[@id=\"myTable\"]/tbody/tr[" + rowno + "]/td[3]";
            
            return findByxpath_getText(Driver, CHID_XPATH);


        }
        public void CLICK_ON_GETDATA(IWebDriver Driver, int TIME_DELAY)
        {
            
            findByxpath_Click(Driver, PMBOL_CLASS.BUTTON_GETDATA_ID, TIME_DELAY);
        }
        private string findByxpath_getText(IWebDriver driver, string getdataxpath)
        {
            Actions action = new Actions(driver);
            try
            {
                return driver.FindElement(By.XPath(getdataxpath)).Text;
            }
            catch (Exception)
            {
                clickTAB(action);
                findByxpath_getText(driver, getdataxpath);
                return "";
            }
        }
        public int get_total_records(IWebDriver Driver)
        {
            var CHKLIST = Driver.FindElements(By.XPath("//input[@type='checkbox']"));
            return CHKLIST.Count;
        }
        public void load_website(IWebDriver Driver)
        {
            PMBOL_CLASS BOL = new PMBOL_CLASS();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(PMBOL_CLASS.url);
         
        }
        public void DEPTLOGiN(IWebDriver Driver , int time_delay)
        {
            Thread.Sleep(time_delay);

            findByxpath_Click(Driver, PMBOL_CLASS.DEPTlOGIN_XPATH, time_delay);
        }
        public void EnterUserid(IWebDriver Driver, PMBOL_CLASS pMBOL, int time_delay)
        {
            Thread.Sleep(time_delay);

            findById_CLICK_ND_Sendkeys(Driver, PMBOL_CLASS.userid_id, pMBOL.userid,"-1");
        }
        public void Enterpassword(IWebDriver Driver, PMBOL_CLASS pMBOL, int time_delay)
        {
            Thread.Sleep(time_delay);

            findById_CLICK_ND_Sendkeys(Driver, PMBOL_CLASS.password_id, pMBOL.password,"-1");

        }
        public void signin_emp(IWebDriver Driver, int time_delay)
        {
                Thread.Sleep(time_delay);
                findById_Click(Driver, PMBOL_CLASS.SIGN_IN_BUTTON_ID, time_delay);
        }
            
        public void ClickOnCCEmarks(IWebDriver Driver, int time_delay)
        {
            Thread.Sleep(time_delay);

            findByxpath_Click(Driver, PMBOL_CLASS.CCE_MARKS_XPATH, time_delay);

        }
        public void Clicksa1Service(IWebDriver Driver, PMBOL_CLASS PMBOL, int time_delay)
        {
            Thread.Sleep(time_delay);

            findByxpath_Click(Driver, PMBOL_CLASS.SA1_SERVICES_XPATH, time_delay);
        }
        public void Clicksa1MarksEntry(IWebDriver Driver, PMBOL_CLASS PMBOL, int time_delay)
        {
            Thread.Sleep(time_delay);

            findByxpath_Click(Driver, PMBOL_CLASS.SA1_MARKS_ENTRY_XPATH, time_delay);
        }
        public void select_class(IWebDriver Driver, int Class, int time_delay)
        {
           

            Thread.Sleep(time_delay);
           // findById_Click(Driver, PMBOL_CLASS.CLASS_ID, time_delay);
            switch (Class)
            {
                case 6:
                    findByxpath_Click(Driver, PMBOL_CLASS.CLASS6_XPATH, time_delay);
                    break;
                case 7:
                    findByxpath_Click(Driver, PMBOL_CLASS.CLASS7_XPATH, time_delay);
                    break;
                case 8:
                    findByxpath_Click(Driver, PMBOL_CLASS.CLASS8_XPATH, time_delay);
                    break;
                case 9:
                    findByxpath_Click(Driver, PMBOL_CLASS.CLASS9_XPATH, time_delay);
                    break;
                case 10:
                    findByxpath_Click(Driver, PMBOL_CLASS.CLASS10_XPATH, time_delay);
                    break;
            }
        }
        public void select_SECTION(IWebDriver Driver, String SECTION, int time_delay)
        {
             
            Thread.Sleep(time_delay);

           // findById_Click(Driver, PMBOL_CLASS.student_section, time_delay);
            switch (SECTION)
            {
                case "A":

                    findByxpath_Click(Driver, PMBOL_CLASS.sectionA_xPATH, time_delay);
                    break;
                case "B":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionB_xPATH, time_delay);
                    break;
                case "C":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionC_xPATH, time_delay);
                    break;
                case "D":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionD_xPATH, time_delay);
                    break;
                case "E":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionE_xPATH, time_delay);
                    break;
                case "F":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionF_xPATH, time_delay);
                    break;
                case "G":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionG_xPATH, time_delay);
                    break;
                case "H":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionH_xPATH, time_delay);
                    break;
                case "I":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionI_xPATH, time_delay);
                    break;
                case "J":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionJ_xPATH, time_delay);
                    break;
                case "K":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionK_xPATH, time_delay);
                    break;
                case "L":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionL_xPATH, time_delay);
                    break;
                case "M":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionM_xPATH, time_delay);
                    break;
                case "N":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionN_xPATH, time_delay);
                    break;
                case "O":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionO_xPATH, time_delay);
                    break;
                case "P":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionP_xPATH, time_delay);
                    break;
                case "Q":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionQ_xPATH, time_delay);
                    break;
                case "R":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionR_xPATH, time_delay);
                    break;
                case "S":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionS_xPATH, time_delay);
                    break;
                case "T":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionT_xPATH, time_delay);
                    break;
                case "U":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionU_xPATH, time_delay);
                    break;
                case "V":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionV_xPATH, time_delay);
                    break;
                case "W":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionW_xPATH, time_delay);
                    break;
                case "X":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionX_xPATH, time_delay);
                    break;
                case "Y":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionY_xPATH, time_delay);
                    break;
                case "Z":
                    findByxpath_Click(Driver, PMBOL_CLASS.sectionZ_xPATH, time_delay);
                    break;
                 
            }



        }
       

        public void select_SUBJECT_CLASS6(IWebDriver Driver, PMBOL_CLASS PMBOL,int index, int time_delay)
        {
          
            Thread.Sleep(time_delay);
           
          //  findById_Click(Driver, PMBOL_CLASS.student_subject, time_delay);
            try
            {

            IWebElement ddl = Driver.FindElement(By.Id(PMBOL_CLASS.student_subject));
            SelectElement select = new SelectElement(ddl);
               
                switch (PMBOL.CLASS_int)
            {
                case 1:
                case 2:
                    select.SelectByText(PMBOL.subjects[PMBOL.subjects1to2[index]]);
                 
                    break;
                case 3:
                case 4:
                case 5:
                    select.SelectByText(PMBOL.subjects[PMBOL.subjects3to5[index]]);

                    break;
                case 6:                   
                case 7:
               
                        Thread.Sleep(1000);
                    select.SelectByText(PMBOL.subjects[PMBOL.subjects6_7[index]]);

                     break;
                case 81:
                case 101:
                    Thread.Sleep(1000);
                    select.SelectByText(PMBOL.subjects[PMBOL.subjects8_10[index]]);
                  
                    break;
                    case 8:
                    case 9:
                    case 10:

                        select.SelectByText(PMBOL.subjects[PMBOL.subjects9[index]]);
                     

                    break;
                 

            }
            }
            catch (Exception EX)
            {
                if (EX.Message.ToString().Contains("locate"))
                {
                    select_SUBJECT_CLASS6(Driver, PMBOL, index, time_delay*2);
                   
                }
              
            }



        }

        public void QUIT()
        {
           Driver1.Quit();
        }

        public String RESET_SEC_MAP(PMBOL_CLASS pMBOL)
        {
            String SQL = "UPDATE ADMN_DATA SET REMARK='NO' WHERE NEW_CLASS=" + pMBOL.SECMAP_CLASS + " AND " +
                " NEW_SEC='" + pMBOL.SECMAP_SECTION + "' AND REMARK = 'FAILED'";
            SqlCommand CMD= new SqlCommand(SQL,con );
            con_open(con);
           int RES= CMD.ExecuteNonQuery();
            con.Close();
            return RES.ToString();
        }
    }
}

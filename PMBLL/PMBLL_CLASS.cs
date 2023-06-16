using System;
using System.Collections.Generic;
using System.Text;
using PMBOL;
using PM_DAL;
using System.Configuration;

using System.Data;
using System.Data.SqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
namespace PMBLL
{
   public class PMBLL_CLASS
    {

        public string POST_MARKS_CHECK(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            if (PMBOL.TEST == null)
                return "please select test";
            else if (PMBOL.CLASS == null)
                return "please select class";
            else if (PMBOL.SECTION == null)
                return "please select section";
            else if (PMBOL.SUBJECT == null)
                return "please select subject";
            else
            {

                PMDAL_DB.postmarks_db(PMBOL);
                return "SUCCESS";
            }

        }

        public string MARKS_UPDATED_CHECK(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            if (PMBOL.TEST == null)
                return "please select test";
            else if (PMBOL.CLASS == null)
                return "please select class";
            else if (PMBOL.SECTION == null)
                return "please select section";
            else if (PMBOL.SUBJECT == null)
                return "please select subject";
            else
            {

                PMDAL_DB.MARKS_UPDATED_CHECK_db(PMBOL);
                return "SUCCESS";
            }

        }
        public string Section_mapping_CHECK(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
           if (PMBOL.CLASS == null)
                return "please select class";
           
            else
            {

                PMDAL_DB.SECTION_MAPPING_db(PMBOL);
                return "SUCCESS";
            }

        }
        public string GET_PROFILE2(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            if (PMBOL.CLASS == null)
                return "please select class";

            else
            {

                PMDAL_DB.GET_STUDENT_DATA_db(PMBOL);
                return "SUCCESS";
            }

            return "";
        }
        public string GET_PROFILE(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            if (PMBOL.CLASS == null)
                return "please select class";

            else
            {

                PMDAL_DB.GET_STUDENT_DATA_db(PMBOL);
                return "SUCCESS";
            }

        }
        public string CHECK_INPUT_TO_GETMARKS(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            if (PMBOL.CLASS == null)
                return "please select class";

            else
            {

                PMDAL_DB.GET_MARKS_DB(PMBOL);
                return "SUCCESS";
            }

        }
        public string CHECK_INPUT_TO_section_map(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            if (PMBOL.CLASS == null)
                return "please select class";

            else
            {

                PMDAL_DB.section_map_DB(PMBOL);
                return "mapping is over";
            }

        }
        public string CHECK_INPUT_TO_LOAD_WEBSITE(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            

                PMDAL_DB.LOAD_WEBSITE(PMBOL);
                return "SUCCESS";
            

        }
        public string GET_CHILDID_CHECK(PMBOL_CLASS PMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            PMDAL_DB.GET_CHILDID_db(PMBOL);
                return "SUCCESS";
             

        }

        public string CHILDINFO_CHECK(PMBOL_CLASS PMBOL)
        {

            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            if (PMBOL.CLASS == null)
                return "please select class";

            else
            {

                PMDAL_DB.CHILDINFO_db(PMBOL);
                return "SUCCESS";
            }

        }

        public void QUIT()
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            PMDAL_DB.QUIT();
        }

        public void getElement_title(PMBOL_CLASS pMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();
            PMDAL_DB.getElement_title(pMBOL);
        }

        public string CHECK_INPUT_TO_RESET_SECMAP(PMBOL_CLASS pMBOL)
        {
            PMDAL_CLASS PMDAL_DB = new PMDAL_CLASS();

            return PMDAL_DB.RESET_SEC_MAP(pMBOL);
        }
    }
}

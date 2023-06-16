using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace PMBOL
{
    public class DATA_ONLINE
    {
        public static string NAME_ONLINE_XPATH = "//*[@id='pcoded']/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/th[4]";
        public static string DATA_ONLINE_TABLE = "[DATA_ONLINE$]";
        public static string ATTENDANCE_TABLE = "[ADMN_DATA]";
        public static string student_mapping_columns = "CHID,NEW_SEC";
        public static string student_mapping_CONDITION = "chid is not null and  NEW_SEC IS NOT NULL ";
        public string student_mapping_CLASS_SECTION { get; set; }

        public string CLASS_ONLINE { get; set; }
        public string SEC_ONLINE { get; set; }
        public string NAME_ONLINE { get; set; }
        public string CHILDID { get; set; }
        public string NAME2 { get; set; }
        public string ADMNNO { get; set; }

    }
    public  class PMBOL_CLASS
    {
        
        //SECTION MAPPING 
        public static string ADMISSIONS_XPATH = "/html/body/div[3]/div[2]/div/div/nav/div/div/div[1]/div/ul/li[4]/a/span[2]";
        public static string Edit_Student_Details = "//span[text()='Edit Student Admission Details']";
       
        public static string Mapping_Stud_Id = "stud_id";
        public static string mapping_GetData = "//*[@id=\"pcoded\"]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div/div[2]/div/div[3]/div";
        public static string Student_section = "student_section";
        public static string Mapping_Submit = "//*[@id=\"pcoded\"]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[5]/div[3]/div/div";
        public static string student2022 = "STU2022$";
        public string  TABLE { get; set; }
        public static string student_mapping_columns = "CHILDID,SEC_ONLINE,NAME,SEC";
        public static string student_mapping_CONDITION =" REMARK ='NO' ";
        public static string stu_map_Chid_id = "stud_id";
        public static string stu_section_id = "student_section";
        public static string stu_getdata_xpath = "/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[1]/div[2]/div/div[3]/div";
        public static string stuDistance = "distance";
        public static string transport_mode = "transport_mode";
        public static string mapingsubmit= "/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[5]/div[3]/div/div";
        public String MAPPING_CONDITION2 { get; set; }


        // CHILD INFO


        public int CHINFO_ADMNNO_FROM { get; set; }
        public int CHINFO_ADMNNO_TO { get; set; }
        public string CHINFO_DOA_DD { get; set; }
        public string CHINFO_DOA_MM { get; set; }
        public string CHINFO_DOA_YY { get; set; }
        public string CHINFO_AADHAR { get; set; }
        public string CHINFO_ADMNNO { get; set; }
        public string CHINFO_MEDIUM { get; set; }
        public string CHINFO_CLASS { get; set; }
        public string CHINFO_SECTION { get; set; }
        public string CHILDINFO_CONDITION2 { get; set; }
        public static string CHILDINFO2022 = "CHILDINFO$";
        public static string CHILDINFO_columns = "[ADMNNO],[NAME],[GENDER],[CLASS],[MEDIUM],[AADHAR],[DOADD],[DOAMM],[DOAYY],[CHILDID]";
        public static string CHILDINFO_CONDITION = "REMARK='NO' AND  LEN(AADHAR)=12 AND LEN(ADMNNO)>=4";
        public static string ADMISSIONS_EXIT_XPATH = "/html/body/div[3]/div[2]/div/div/nav/div/div/div[1]/div/ul/li[2]/a/span[1]";
       
        public static string ACTIVE_INACTIVE_XPATH = "/html/body/div[3]/div[2]/div/div/nav/div/div/div[1]/div/ul/li[3]/ul[6]/li/a/span";
        public static string AADHAR_ID = "student_id";
        public static string childinfoGetdata_xpath = "/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[1]/div[3]/div";
        public static string CHID_XPATH = "/html/body/div[3]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[1]";
        public static string ADMNNO_ID = "admin_no";
        public static string MEDIUM_ID = "medium";
        public static string PRESENTCLASSS_XPATH = "//*[@id=\"class\"]";
        public static string SECTION_XPATH = "section";
        public static string JOIN_XPATH="//*[@id=\"pcoded\"]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div[2]/table/tbody/tr[8]/th/div";
 

        //POST MARKS
        public String userid { get; set; }
        public String password { get; set; }
        public int rowsincycle1 { get; set; }
        public StringBuilder  CHILDIDS { get; set; }
        public int rowsincycle2 { get; set; }

        public int rowsincycle3 { get; set; }


        public String TEST { get; set; }
        public String CLASS { get; set; }
        public int CLASS_int { get; set; }
        public String SUBJECT { get; set; }
        public int SUBJECT_int { get; set; }

        public int SECTION { get; set; }
        public string CHILDID { get; set; }
        public string CHILDNAME { get; set; }

       
        public string SUBJECTWISE_COLUMNS { get; set; }

        public string ISEMPTY { get; set; }

        public string condition { get; set; }
        public int SECTIONS { get; set; }
        public int tools { get; set; }
        public string TOOLS_LIMIT { get; set; }

        public  string  CHECKBOXXPATH { get; set; }
        public int records_completed { get; set; }
        public string FAserviceXpath { get; set; }
        public string FAREPORTSXpath { get; set; }
        public string SAREPORTSXpath { get; set; }
        public string SAserviceXpath { get; set; }
        public string SAmarksEntryXpath { get; set; }
        public string SECMAP_CLASS { get; set; }
        public string SECMAP_SECTION { get; set; }

        public static string SSCurl = "http://www.results.manabadi.co.in/2023/AP/ssc/Andhra-Pradesh-10th-Class-Exam-AP-SSC-Results-May-2023.htm";
        public static string url = "https://studentinfo.ap.gov.in/";
        //public static string url = "https://physics4ever.in/";
        public static string POPUP_XPATH = "//*[@id=\"LatestUpdates\"]/div/div/div[1]/button";
        public static string uid = "28132800310";
        public static string pwd = "Zphs@048";
        public static string DEPTlOGIN_XPATH = "//*[@id='navbar']/ul/li[8]/a";
        public static string userid_id = "username";
        public static string password_id = "password";

        public static string SIGN_IN_BUTTON_ID = "signin_emp";//signin_emp
        public static string CCE_MARKS_XPATH = "//span[contains(text(),'CCE')]";
        public static string FA1_SERVICES_XPATH = "//span[text()='FA1 Services']";
        public static string FA2_SERVICES_XPATH = "//span[text()='FA2 Services']";
        public static string FA3_SERVICES_XPATH = "//span[text()='FA3 Services']";
        public static string FA4_SERVICES_XPATH = "//span[text()='FA4 Services']";
        public static string SA1_SERVICES_XPATH = "//span[text()='Sa1 Services']";
        public static string SA2_SERVICES_XPATH = "//span[text()='Sa2 Services']";

        public static string FA3_MARKS_SERVICES_XPATH = "/html/body/div[3]/div[2]/div/div/nav/div/div/div[1]/div/ul/li[3]/ul[2]/li/a/span";
        public static string FA3_MARKS_XPATH = "/html/body/div[3]/div[2]/div/div/nav/div/div/div[1]/div/ul/li[3]/ul[2]/li/ul[1]/li/a/span";

        public static string Admissions_Exit_XPATH = "//span[contains(text(), \"Admissions & Exit\")]";
        public static string Edit_Student_Admission_Details_XPATH = "//span[contains(text(), \"Edit Student Admission Details\")]";

        //                                      

        //*[@id="mCSB_1_container"]/ul/li[3]/ul[5]/li/a/span
        //*[@id="mCSB_1_container"]/ul/li[3]/ul[3]/li/a/span
        public static string FA1_CCE_MARKS_REPORT_XPATH = "//span[contains(text(),'Cce Studentwise Marks Report')]";
        public static string FA2_CCE_MARKS_REPORT_XPATH = "//span[contains(text(),'FA2') and contains(text(),'Student') ]";
        public static string FA3_CCE_MARKS_REPORT_XPATH = "//span[contains(text(),'FA3') and contains(text(),'Student') ]";
        public static string FA4_CCE_MARKS_REPORT_XPATH = "//span[contains(text(),'FA4') and contains(text(),'Student') ]";
        public static string SA1_CCE_MARKS_REPORT_XPATH = "//span[contains(text(),'SA1') and contains(text(),'Student') ]";
        public static string SA2_CCE_MARKS_REPORT_XPATH = "//span[contains(text(),'SA2') and contains(text(),'Student') ]";

        public static string FA3_MARKS_ENTRY_XPATH = "//*[@id=\"mCSB_1_container\"]/ul/li[3]/ul[3]/li/ul[2]/li/a/span";
        public static string SA1_MARKS_ENTRY_XPATH = "/html/body/div[3]/div[2]/div/div/nav/div/div/div[1]/div/ul/li[3]/ul[5]/li/ul[3]/li/a/span";
        public static string SA2_MARKS_ENTRY_XPATH = "//span[text()='Sa2 Services']/following::span[contains(text(),'SA1 Marks Entry')]";
        //*[@id="mCSB_1_container"]/ul/li[3]/ul[5]/li/ul[2]/li/a/span
        //*[@id="mCSB_1_container"]/ul/li[2]/ul[1]/li/ul[1]/li/a/span
        //*[@id="mCSB_1_container"]/ul/li[3]/ul[3]/li/ul[1]/li/a/span
        //*[@id="mCSB_1_container"]/ul/li[2]/ul[2]/li/ul[3]/li/a/span         
        public static string btntoggle = "//*[@id=\"mobile-collapse\"]/i" ;
        public static string CLASS_ID = "student_class";

        public static string CLASS6_XPATH = "//*[@id=\"student_class\"]/option[7]";
        public static string CLASS7_XPATH = "//*[@id=\"student_class\"]/option[8]";
        public static string CLASS8_XPATH = "//*[@id=\"student_class\"]/option[9]";
        public static string CLASS9_XPATH = "//*[@id=\"student_class\"]/option[10]";
        public static string CLASS10_XPATH = "//*[@id=\"student_class\"]/option[11]";

        public static string student_section = "student_section";
        public static string sectionA_xPATH = "//*[@id=\"student_section\"]/option[2]";
        public static string sectionB_xPATH = "//*[@id=\"student_section\"]/option[3]";
        public static string sectionC_xPATH = "//*[@id=\"student_section\"]/option[4]";
        public static string sectionD_xPATH = "//*[@id=\"student_section\"]/option[5]";
        public static string sectionE_xPATH = "//*[@id=\"student_section\"]/option[6]";
        public static string sectionF_xPATH = "//*[@id=\"student_section\"]/option[7]";
        public static string sectionG_xPATH = "//*[@id=\"student_section\"]/option[8]";
        public static string sectionH_xPATH = "//*[@id=\"student_section\"]/option[9]";
        public static string sectionI_xPATH = "//*[@id=\"student_section\"]/option[10]";
        public static string sectionJ_xPATH = "//*[@id=\"student_section\"]/option[11]";
        public static string sectionK_xPATH = "//*[@id=\"student_section\"]/option[12]";
        public static string sectionL_xPATH = "//*[@id=\"student_section\"]/option[13]";
        public static string sectionM_xPATH = "//*[@id=\"student_section\"]/option[14]";
        public static string sectionN_xPATH = "//*[@id=\"student_section\"]/option[15]";
        public static string sectionO_xPATH = "//*[@id=\"student_section\"]/option[16]";
        public static string sectionP_xPATH = "//*[@id=\"student_section\"]/option[17]";
        public static string sectionQ_xPATH = "//*[@id=\"student_section\"]/option[18]";
        public static string sectionR_xPATH = "//*[@id=\"student_section\"]/option[19]";
        public static string sectionS_xPATH = "//*[@id=\"student_section\"]/option[20]";
        public static string sectionT_xPATH = "//*[@id=\"student_section\"]/option[21]";
        public static string sectionU_xPATH = "//*[@id=\"student_section\"]/option[22]";
        public static string sectionV_xPATH = "//*[@id=\"student_section\"]/option[23]";
        public static string sectionW_xPATH = "//*[@id=\"student_section\"]/option[24]";
        public static string sectionX_xPATH = "//*[@id=\"student_section\"]/option[25]";
        public static string sectionY_xPATH = "//*[@id=\"student_section\"]/option[26]";
        public static string sectionZ_xPATH = "//*[@id=\"student_section\"]/option[27]";


        public static string student_subject = "student_subject";
        public static string SUBJECT_TELUGU_xPATH = "//*[@id=\"student_subject\"]/option[12]";
        public static string SUBJECT_HINDI_xPATH = "//*[@id=\"student_subject\"]/option[44]";
        public static string SUBJECT_ENGLISH_xPATH = "//*[@id=\"student_subject\"]/option[53]";
        public static string SUBJECT_MATHS_xPATH = "//*[@id=\"student_subject\"]/option[40]";
        public static string SUBJECT_GENERAL_SCIENCE_xPATH = "//*[@id=\"student_subject\"]/option[39]";
        public static string SUBJECT_SOCIAL_STUDIES_xPATH = "//*[@id=\"student_subject\"]/option[50]";
        public static string BUTTON_GETDATA_ID = "//*[@id=\"pcoded\"]/div[2]/div/div/div/div/div/div/div/div[3]/div/form/div/div[2]/div/div[2]/div/div/div/div[5]/div";
                                                 
        public static int[] TEL_tools = { 0,0,0,0,0,0, 3, 3, 3, 3, 3 };
        public static int[] HIN_tools = { 0, 0, 0, 0, 0, 0, 3, 4, 4, 3, 3 };
        public static int[] ENG_tools = { 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3 };
        public static int[] MAT_tools = { 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5 };
        public static int[] PS_tools = { 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6 };
        public static int[] GS_tools = { 0, 0, 0, 0, 0, 0, 6, 6 };
        public static int[] BS_tools = { 0, 0, 0, 0, 0, 0, 0,0,6, 6, 6 };


        public static int[] SS_tools = { 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6 };

        public int[] totalsubjects = {0,3,3,4,4,4,6,6,7,7,7};
        public string [] subjects = {
        "Telugu",//0
        "First language Telugu",//1                   class1to2 : 0,5,9
        "First language Telugu Paper I",//2           class3to5 : 0,5,9,17
        "First language Telugu Paper II",//3          class6    : 1,4,6,9,18,14
        "Second language Hindi",//4                   class7    : 1,4,6,9,18,14
        "English",//5                                 class8    : 1,4,6,9,12,13,14      
        "Thrird language English",//6                 class9    : 2,3,4,7,8,10,11,12,13,15,16
        "Thrird language English Paper I",//7         class10   : 1,4,6,9,12,13,14
        "Thrird language English Paper II",//8
        "Mathematics",//9
        "Mathematics Paper I",//10 
        "Mathematics Paper II", //11
        "Physical Science",//12
        "Biological Science",//13
        "Social Studies",//14
        "Social Studies Paper I",//15 
        "Social Studies Paper II",//16
        "EVS",//17
        "General Science"};//18
        public int[] subjects1to2 = { 0, 5, 9};
        public int[] subjects3to5 = { 0, 5,9,17 };
        public int[] subjects6_7 = { 1, 4, 6, 9, 18, 14 };
        public int[] subjects8_10 = { 1, 4, 6, 9, 12, 13, 14 };
        public int[] subjects9 = { 1, 4, 6, 9, 12, 13, 14 };
//        public int[] subjects9 = { 2, 3, 4, 7, 8, 10, 11, 12, 13, 15, 16 };

        public static string REMARK = "REMARK";
        public static string[] datatablessa1 = { "", "", "", "", "", "CLASS6_SA1$", "CLASS7_SA1$", "CLASS8_SA1$", "CLASS9_SA1$", "CLASS10_SA1$" };
        public static string[] datatablesFA3 = { "", "", "", "", "", "CLASS6_FA3$", "CLASS7_FA3$", "CLASS8_FA3$", "CLASS9_FA3$", "CLASS10_FA3$" };

        public static string[] datatablessa2 = { "", "", "", "", "", "CLASS6_SA2$", "CLASS7_SA2$", "CLASS8_SA2$", "CLASS9_SA2$", "CLASS10_SA2$" };

        public static string[] TEL_COL = { "0", "0", "0", "0", "0", "0", "TEL1,TEL2,TEL3", "TEL1,TEL2,TEL3", "TEL1,TEL2,TEL3", "TEL1,TEL2,TEL3,TEL4,TEL5,TEL6", "TEL1,TEL2,TEL3" };
        public static string[] TEL_COL_limit = { "0", "0", "0", "0", "0", "0", "TEL1<=24 AND TEL2<=36 AND TEL3<=20", "TEL1<=24 AND TEL2<=36 AND TEL3<=20", "TEL1<=24 AND TEL2<=36 AND TEL3<=20", "TEL1<=12 AND TEL2<=18 AND TEL3<=10 AND TEL4<=12 AND TEL5<=18 AND TEL6<=10", "TEL1<=32 AND TEL2<=36 AND TEL3<=32" };
        public static string[] TEL1_COL = { "TEL1 , TEL2 , TEL3" };
        public static string[] TEL2_COL = { "TEL4 , TEL5 ,  TEL6" };

        public static string[] TEL1_COL_LIMIT = { "TEL1<=12 AND TEL2<=18  AND TEL3<=10" };
        public static string[] TEL2_COL_LIMIT = { "TEL4<=12  AND  TEL5<=18  AND  TEL6<=10" };

        public static string[] HIN_COL = { "0", "0", "0", "0", "0", "0", 
            "HIN1  ,  HIN2  ,  HIN3", 
            "HIN1  ,  HIN2  ,  HIN3  ,  HIN4", 
            "HIN1  ,  HIN2  ,  HIN3  ,  HIN4", 
            "HIN1  ,  HIN2  ,  HIN3  ", 
            "HIN1  ,  HIN2  ,  HIN3" };
        public static string[] HIN_COL_limit = { "0", "0", "0", "0", "0", "0",
            "HIN1<=40  AND  HIN2<=30  AND  HIN3<=10", 
            "HIN1<=20  AND  HIN2<=30  AND  HIN3<=10  AND  HIN4<=20", 
            "HIN1<=20  AND  HIN2<=30  AND  HIN3<=10  AND  HIN4<=20", 
            "HIN1<=20  AND  HIN2<=40  AND  HIN3<=20  "  ,  
            "HIN1<=15  AND  HIN2<=68  AND  HIN3<=17" };



        public static string[] ENG_COL = { "0", "0", "0", "0", "0", "0", 
            "ENG1  ,  ENG2  ,  ENG3"  ,  
            "ENG1  ,  ENG2  ,  ENG3"  , 
            "ENG1  ,  ENG2  ,  ENG3"  , 
            "ENG1  ,  ENG2  ,  ENG3  ,  ENG4  ,  ENG5  ,  ENG6"  ,  
            "ENG1  ,  ENG2  ,  ENG3" };

        public static string[] ENG_COL_LIMIT = { "0", "0", "0", "0", "0", "0", "ENG1<=30  AND  ENG2<=20  AND  ENG3<=30" ,   "ENG1<=30  AND  ENG2<=20  AND  ENG3<=30"  ,   "ENG1<=30  AND  ENG2<=20  AND  ENG3<=30"  ,   "ENG1<=15  AND  ENG2<=10  AND  ENG3<=15  AND  ENG4<=15  AND  ENG5<=10  AND  ENG6<=15"  ,   "ENG1<=30  AND  ENG2<=40  AND  ENG3<=30" };


        public static string[] ENG1_COL = { "ENG1,ENG2,ENG3" };
        public static string[] ENG2_COL = { "ENG4,ENG5,ENG6" };

        public static string[] ENG1_COL_LIMIT = { "ENG1<=15 AND ENG2<=10 AND ENG3<=15" };
        public static string[] ENG2_COL_LIMIT = { "ENG4<=15 AND ENG5<=10 AND ENG6<=15" };

        public static string[] MAT_COL = { "0", "0", "0", "0", "0", "0", 
            "MAT1  ,  MAT2  ,  MAT3  ,  MAT4  ,  MAT5"  ,  
            "MAT1  ,  MAT2  ,  MAT3  ,  MAT4  ,  MAT5"  ,  
            "MAT1  ,  MAT2  ,  MAT3  ,  MAT4  ,  MAT5"  , 
            "MAT1  ,  MAT2  ,  MAT3  ,  MAT4  ,  MAT5  ,  MAT6  ,  MAT7  ,  MAT8  ,  MAT9  , MAT10"  , 
            "MAT1  ,  MAT2  ,  MAT3  ,  MAT4  ,  MAT5" };
        public static string[] MAT_COL_LIMIT = { "0", "0", "0", "0", "0", "0",
            "MAT1<=32  AND  MAT2<=16  AND  MAT3<=8  AND  MAT4<=12  AND  MAT5<=12"  , 
            "MAT1<=32  AND  MAT2<=16  AND  MAT3<=8  AND  MAT4<=12  AND  MAT5<=12"  , 
            "MAT1<=32  AND  MAT2<=16  AND  MAT3<=8  AND  MAT4<=12  AND  MAT5<=12"  ,  
            "MAT1<=16  AND  MAT2<=8  AND  MAT3<=4  AND  MAT4<=6  AND  MAT5<=6  AND  MAT6<=16  AND  MAT7<=8  AND  MAT8<=4  AND  MAT9<=6  AND  MAT10<=6"  , 
            "MAT1<=40  AND  MAT2<=20  AND  MAT3<=10  AND  MAT4<=15  AND  MAT5<=15" };
        public static string[] MAT1_COL = { "MAT1,MAT2 ,MAT3,MAT4,MAT5" };
        public static string[] MAT2_COL = { "MAT6 ,MAT7,MAT8,MAT9,MAT10" };

        public static string[] MAT1_COL_LIMIT = { "MAT1<=16  AND  MAT2<=8  AND  MAT3<=4  AND  MAT4<=6  AND  MAT5<=6" };
        public static string[] MAT2_COL_LIMIT = { "MAT6<=16  AND  MAT7<=8  AND  MAT8<=4  AND  MAT9<=6  AND  MAT10<=6" };
        public static string[] PS_COL = { "0", "0", "0", "0", "0", "0", "0", "0", 
            "PS1  ,  PS2  ,  PS3  ,  PS4  ,  PS5  ,  PS6"  ,   
            "PS1  ,  PS2  ,  PS3  ,  PS4  ,  PS5  ,  PS6"  ,   
            "PS1  ,  PS2  ,  PS3  ,  PS4  ,  PS5  ,  PS6" };
        public static string[] PS_COL_LIMIT = { "0", "0", "0", "0", "0", "0", "0", "0", 
            "PS1<=16  AND  PS2<=4  AND  PS3<=6  AND  PS4<=6  AND  PS5<=4  AND  PS6<=4"  ,   "PS1<=16  AND  PS2<=4  AND  PS3<=6  AND  PS4<=6  AND  PS5<=4  AND  PS6<=4"  ,   "PS1<=20  AND  PS2<=5  AND  PS3<=8  AND  PS4<=7  AND  PS5<=5  AND  PS6<=5" };
        public static string[] GS_COL = { "0", "0", "0", "0", "0", "0",
            "GS1  ,  GS2  ,  GS3  ,  GS4  ,  GS5  ,  GS6"  ,   
            "GS1  ,  GS2  ,  GS3  ,  GS4  ,  GS5  ,  GS6"  ,   "0"  ,   "0"  ,   "0" };
        public static string[] GS_COL_LIMIT = { "0", "0", "0", "0", "0", "0", 
            "GS1<=32  AND  GS2<=8  AND  GS3<=12  AND  GS4<=12  AND  GS5<=8  AND  GS6<=8"  ,   "GS1<=32  AND  GS2<=8  AND  GS3<=12  AND  GS4<=12  AND  GS5<=8  AND  GS6<=8", 
            "0", "0", "0" };
        public static string[] BS_COL = { "0", "0", "0", "0", "0", "0", "0", "0", 
            "BS1  ,  BS2  ,  BS3  ,  BS4  ,  BS5  ,  BS6"  ,   "BS1  ,  BS2  ,  BS3  ,  BS4  ,  BS5  ,  BS6"  ,   "BS1  ,  BS2  ,  BS3  ,  BS4  ,  BS5  ,  BS6" };
        public static string[] BS_COL_LIMIT = { "0", "0", "0", "0", "0", "0", "0", "0", 
            "BS1<=16  AND  BS2<=4  AND  BS3<=6  AND  BS4<=6  AND  BS5<=4  AND  BS6<=4"  ,   "BS1<=16  AND  BS2<=4  AND  BS3<=6  AND  BS4<=6  AND  BS5<=4  AND  BS6<=4"  ,   "BS1<=20  AND  BS2<=5  AND  BS3<=8  AND  BS4<=7  AND  BS5<=5  AND  BS6<=5" };

        public static string[] SS_COL = { "0", "0", "0", "0", "0", "0", 
            "SS1  ,  SS2  ,  SS3  ,  SS4  ,  SS5  ,  SS6"  ,   "SS1  ,  SS2  ,  SS3  ,  SS4  ,  SS5  ,  SS6"  ,   "SS1  ,  SS2  ,  SS3  ,  SS4  ,  SS5  ,  SS6"  ,   "SS1  ,  SS2  ,  SS3  ,  SS4  ,  SS5  ,  SS6  ,  SS7  ,  SS8  ,  SS9  ,  SS10  ,  SS11  ,  SS12"  ,   "SS1  ,  SS2  ,  SS3  ,  SS4  ,  SS5  ,  SS6" };
 
        public static string[] SS_COL_LIMIT = { "0", "0", "0", "0", "0", "0", "SS1<=32  AND  SS2<=8  AND  SS3<=12  AND  SS4<=8  AND  SS5<=12  AND  SS6<=8"  ,   "SS1<=32  AND  SS2<=8  AND  SS3<=12  AND  SS4<=8  AND  SS5<=12  AND  SS6<=8"  ,   "SS1<=32  AND  SS2<=8  AND  SS3<=12  AND  SS4<=8  AND  SS5<=12  AND  SS6<=8"  ,   "SS1<=16  AND  SS2<=4  AND  SS3<=6  AND  SS4<=4  AND  SS5<=6  AND  SS6<=4  AND  SS7<=16  AND  SS8<=4  AND  SS9<=6  AND  SS10<=4  AND  SS11<=6  AND  SS12<=4"  ,   "SS1<=40  AND  SS2<=10  AND  SS3<=15  AND  SS4<=10  AND  SS5<=15  AND  SS6<=10" };
        public static string[] SS1_COL = { "SS1,SS2,SS3,SS4,SS5,SS6" };
        public static string[] SS2_COL = { "SS7,SS8,SS9,SS10,SS11,SS12" };
        public static string[] SS1_COL_LIMIT = { "SS1<=16  AND  SS2<=4  AND  SS3<=6  AND  SS4<=4  AND  SS5<=6  AND  SS6<=4" };
        public static string[] SS2_COL_LIMIT = { "SS7<=16 AND SS8<=4 AND SS9<=6 AND SS10<=4 AND SS11<=6 AND SS12<=4" };

        public static string[] TEL_ISEMPTY = { "0", "0", "0", "0", "0", "0",
            "TEL1  is not null AND TEL2  is not null AND TEL3  is not null",
            "TEL1  is not null AND TEL2  is not null AND TEL3  is not null",
            "TEL1  is not null AND TEL2  is not null AND TEL3  is not null",
            "TEL1  is not null AND TEL2  is not null AND TEL3  is not null AND " +
            "TEL4  is not null AND TEL5  is not null AND TEL6  is not null AND ",
            "TEL1  is not null AND TEL2  is not null AND TEL3  is not null", };
        public static string[] TEL1_ISEMPTY = {"TEL1  is not null AND TEL2  is not null AND TEL3  is not null"};
        public static string[] TEL2_ISEMPTY = { "TEL4  is not null AND TEL5  is not null AND TEL6  is not null" };
        public static string[] HIN_ISEMPTY = { "0",  "0", "0", "0", "0", "0",
          "HIN1  is not null AND HIN2  is not null AND HIN3  is not null ", 
          "HIN1  is not null AND HIN2  is not null AND HIN3  is not null AND HIN4  is not null ",
          "HIN1  is not null AND HIN2  is not null AND HIN3  is not null AND HIN4  is not null ",
          "HIN1  is not null AND HIN2  is not null AND HIN3  is not null ",
           "HIN1  is not null AND HIN2  is not null AND HIN3  is not null  ", };
        public static string[] ENG_ISEMPTY = { "0",  "0", "0", "0", "0", "0",
        "ENG1  is not null AND ENG2  is not null AND ENG3  is not null  ",
        "ENG1  is not null AND ENG2  is not null AND ENG3  is not null  ",     
        "ENG1  is not null AND ENG2  is not null AND ENG3  is not null  ",
        "ENG1  is not null AND ENG2  is not null AND ENG3  is not null AND " +
        "ENG4  is not null AND ENG5  is not null AND ENG6  is not null ",
        "ENG1  is not null AND ENG2  is not null AND ENG3  is not null  " };
        public static string[] ENG1_ISEMPTY = {"ENG1  is not null AND ENG2  is not null AND ENG3  is not null" };
        public static string[] ENG2_ISEMPTY = { "ENG4  is not null AND ENG5  is not null AND ENG6  is not null" };
        public static string[] MAT_ISEMPTY = { "0",  "0", "0", "0", "0", "0",
        "MAT1  is not null AND MAT2  is not null AND MAT3  is not null AND MAT4  is not null AND MAT5  is not null  ",
         "MAT1  is not null AND MAT2  is not null AND MAT3  is not null AND MAT4  is not null AND MAT5  is not null  ",
         "MAT1  is not null AND MAT2  is not null AND MAT3  is not null AND MAT4  is not null AND MAT5  is not null  ",
        "MAT1  is not null AND MAT2  is not null AND MAT3  is not null AND MAT4  is not null AND MAT5  is not null AND MAT6  is not null AND MAT7  is not null AND MAT8  is not null AND MAT9  is not null AND MAT10  is not null  ",
         "MAT1  is not null AND MAT2  is not null AND MAT3  is not null AND MAT4  is not null AND MAT5  is not null  "};
        public static string[] MAT1_ISEMPTY = {"MAT1  is not null AND MAT2  is not null AND MAT3  is not null AND MAT4  is not null AND MAT5  is not null" };
        public static string[] MAT2_ISEMPTY = { "MAT6  is not null AND MAT7  is not null AND MAT8  is not null AND MAT9  is not null AND MAT10  is not null  " };
        public static string[] PS_ISEMPTY = { "0", "0", "0", "0", "0", "0", "0", "0",
            "PS1  is not null AND PS2  is not null AND PS3  is not null AND PS4  is not null AND PS5  is not null AND PS6  is not null  ",
            "PS1  is not null AND PS2  is not null AND PS3  is not null AND PS4  is not null AND PS5  is not null AND PS6  is not null  ",
            "PS1  is not null AND PS2  is not null AND PS3  is not null AND PS4  is not null AND PS5  is not null AND PS6  is not null  ",};
        public static string[] GS_ISEMPTY = { "0",  "0", "0", "0", "0", "0",
            "GS1  is not null AND GS2  is not null AND GS3  is not null AND GS4  is not null AND GS5  is not null AND GS6  is not null ",
             "GS1  is not null AND GS2  is not null AND GS3  is not null AND GS4  is not null AND GS5  is not null AND GS6  is not null ","0","0","0" };

        public static string[] BS_ISEMPTY = { "0", "0", "0", "0", "0", "0", "0", "0",
             "BS1  is not null AND BS2  is not null AND BS3  is not null AND BS4  is not null AND BS5  is not null AND BS6  is not null ",
             "BS1  is not null AND BS2  is not null AND BS3  is not null AND BS4  is not null AND BS5  is not null AND BS6  is not null ",
                  "BS1  is not null AND BS2  is not null AND BS3  is not null AND BS4  is not null AND BS5  is not null AND BS6  is not null "};
        public static string[] SS_ISEMPTY = { "0",  "0", "0", "0", "0", "0",
             "SS1  is not null AND SS2  is not null AND SS3  is not null AND SS4  is not null AND SS5  is not null AND SS6  is not null  ",
             "SS1  is not null AND SS2  is not null AND SS3  is not null AND SS4  is not null AND SS5  is not null AND SS6  is not null  ",
             "SS1  is not null AND SS2  is not null AND SS3  is not null AND SS4  is not null AND SS5  is not null AND SS6  is not null  ",
            "SS1  is not null AND SS2  is not null AND SS3  is not null AND SS4  is not null AND SS5  is not null AND SS6  is not null AND SS7  is not null AND SS8  is not null AND SS9  is not null AND SS10  is not null AND SS11  is not null AND SS12  is not null ",
             "SS1  is not null AND SS2  is not null AND SS3  is not null AND SS4  is not null AND SS5  is not null AND SS6  is not null  " };

        public static string[] SS1_ISEMPTY = { "SS1  is not null AND SS2  is not null AND SS3  is not null AND SS4  is not null AND SS5  is not null AND SS6  is not null" };
        public static string[] SS2_ISEMPTY = { "SS7  is not null AND SS8  is not null AND SS9  is not null AND SS10  is not null AND SS11  is not null AND SS12  is not null" };


    }

public class pmbol_test
    {
        public int slno { get; set; }
        public string name { get; set; }
        public int age { get; set; }

    }

}

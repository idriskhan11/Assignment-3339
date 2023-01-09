//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ConsoleApp1;

//namespace SampleFrameworksApp.Hospital
//{
//    //enum CauseType { INTERNAL, EXTERNAL}
//    ///enum SeverityType { LOW, MEDIUM, HIGH }


//    interface DiseaseManagement
//    {
//        Array AddDiseaseDetails();
//        void AddSymptomsToDiseases();
//        void CheckPatient();
//    }
//    class DiseaseManagementImplements : DiseaseManagement
//    {
//        Array DiseaseManagement.AddDiseaseDetails()
//        {

//            String name = Utilities.Prompt("Enter the Disease Name").ToUpper();
//            string severness = Utilities.Prompt("Select low, medium or high").ToUpper(); 
//            string cause = Utilities.Prompt("Select internal or External disorder").ToUpper(); 

//            CauseType causetype = (CauseType)Enum.Parse(typeof(CauseType), cause);
//            SeverityType severity = (SeverityType)Enum.Parse(typeof(SeverityType), severness);
//            string Description = Utilities.Prompt("Enter the Description not more than 30 words");
//            string[] Disease = new string[] { name, severness, cause, Description };

//            return Disease;

//        }



//        void DiseaseManagement.AddSymptomsToDiseases()
//        {
//            for (int i = 0; i < Disease.length; i++)
//            {

//            }

            
//        }

//        void DiseaseManagement.CheckPatient()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

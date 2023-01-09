using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace SampleFrameworksApp.Hospital
{

    enum CauseType { INTERNAL, EXTERNAL }
    enum SeverityType { LOW, MEDIUM, HIGH }
    class Disease
    {
        public string DiseaseName { get; set; }
        public string Severity { get; set; }
        public string Cause { get; set; }
        public string Description { get; set; }

        public string[] disease = null;

        public Array AddDiseaseDetails()
        {

            String Diseasename = Utilities.Prompt("Enter the Disease Name").ToUpper();
            string Severity = Utilities.Prompt("Select low, medium or high").ToUpper();
            //to check enum values
            SeverityType severity = (SeverityType)Enum.Parse(typeof(SeverityType), Severity);
            string Cause = Utilities.Prompt("Select internal or External disorder").ToUpper();
            //to check enum values
            CauseType causetype = (CauseType)Enum.Parse(typeof(CauseType), Cause);

            string Description = Utilities.Prompt("Enter the Description not more than 30 words");

            for (int i = 0; i < disease.Length; i++)
            {
                Disease d = new Disease();
                if (disease[i] == null)
                {
                    d.DiseaseName = DiseaseName;
                    d.Severity = Severity;
                    d.Cause = Cause;
                    d.Description = Description;
                }
                else
                {
                    throw new Exception("Enter the correct value");
                }
            }
            return disease;
        }
    }
    class Symptoms : Disease
    {
        public string SymptomName { get; set; }
        public string Description { get; set; }
        public string[] symptoms = null;

        public static void addSymptoms(Symptoms syp)
        {
            if()


        }




    }
    class Patient
    {
        public string name { get; set; }
        string SymptomName { get; set; }

        public void addPatientName()
        {
            string patienName = Utilities.Prompt("Enter the Pateint Name");
            string symptoms = Utilities.Prompt("Enter the Symptoms");
        }



    }
}

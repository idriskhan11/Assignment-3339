using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MedicalEmergeny
{


    class Disease
    {
        public string DiseaseName { get; set; }
        public String cause { get; set; }
        public string Severity { get; set; }
        public string Description { get; set; }


    }
    class Symptom
    {
        public string DiseaseName { get; set; }
        public string SymptomName { get; set; }
        public string Description { get; set; }
    }

    class patient
    {
        public string PatientName { get; set; }
        public string DiseaseName { get; set; }
        public string symptomName { get; set; }
    }
    class DiseaseImpl
    {
        private Disease[] _disease = null;
        private Symptom[] _symptom = null;
        private readonly int _size;
        public DiseaseImpl(int size)
        {
            _size = size;
            _disease = new Disease[_size];
            _symptom = new Symptom[_size];
        }

        public void AddDisease(Disease dis)
        {
            for (int i = 0; i < _disease.Length; i++)
            {
                if (_disease[i] == null)
                {
                    _disease[i] = new Disease { DiseaseName = dis.DiseaseName, cause = dis.cause, Severity = dis.Severity, Description = dis.Description };
                    return;

                }
            }


        }
        public void AddSymptom(Symptom sym)
        {
            for (int i = 0; i < _symptom.Length; i++)
            {
                if (_symptom[i] == null)
                {
                    _symptom[i] = new Symptom { DiseaseName = sym.DiseaseName, SymptomName = sym.SymptomName, Description = sym.Description };
                    return;
                }

            }

        }
        public void Patient(Symptom symp)
        {
            string patientName = Utilities.Prompt("Enter the patient Name");
            string DiseaseName = Utilities.Prompt("Enter the Disease");
            string SymptoName = Utilities.Prompt("Enter the syamptom");

            for (int i = 0; i < _symptom.Length; i++)
            {
                if (SymptoName.Contains(symp.SymptomName))
                {
                    string diseases = symp.DiseaseName;
                    Console.WriteLine(diseases + " umay have");
                    return;
                }
                else
                    throw new Exception("Disease Not Found");


            }


        }
    }
    enum Severity { LOW, MEDIUM, HIGH };
    enum Cause { INTERNAL, EXTERNAL }
    enum Choice { ADD = 1, ADDSYMPTOM, ADDPATIENT }
    class HelperFunction
    {
        public static void run()
        {
            int size = Utilities.GetNumber("Enter the number of Diseases you want to Add");

            bool processing = true;
            do
            {
                Choice choice = (Choice)Utilities.GetNumber(menu);
                processing = process(choice);
            }
            while (processing);
            Console.WriteLine("Thanks for Using our Application!!!");
        }
        private static bool process(Choice choice)
        {
            switch (choice)
            {
                case Choice.ADD:
                    AddHelper();
                    break;
                case Choice.ADDSYMPTOM:
                    SymptomHelper();
                    break;
                case Choice.ADDPATIENT:
                    PatientHelper();
                    break;
                default:
                    break;
            }
            return true;
        }
        public static DiseaseImpl di = new DiseaseImpl(10);
        public static Symptom sym = new Symptom();
        public static Disease dis = null;
        public static void AddHelper()
        {
            string Diseases = Utilities.Prompt("Enter the Disease Name");
            string severity = Utilities.Prompt("Enter the severity as low, medium,high").ToUpper();
            Severity severness = (Severity)Enum.Parse(typeof(Severity), severity);
            string cause = Utilities.Prompt("Enter the cause Internal or external factor").ToUpper();
            Cause cause1 = (Cause)Enum.Parse(typeof(Cause), cause);
            string Description = Utilities.Prompt("Enter the Description more tha 30 character");
            

            Disease dis = new Disease { DiseaseName = Diseases, Severity = severity, cause = cause, Description = Description };
            di.AddDisease(dis);
            Console.WriteLine("Added Sucessfully");




        }
        public static void SymptomHelper()
        {
            string DiseaseName = Utilities.Prompt("Enter Disease Name");
            string Symptoms = Utilities.Prompt("Enter the Symptoms");
            string description = Utilities.Prompt("Enter the Description more than 30 words");
            Symptom sym = new Symptom { DiseaseName = DiseaseName, SymptomName = Symptoms, Description = description };
            di.AddSymptom(sym);
            Console.WriteLine("Symptom Added successfully");
        }
        public static void PatientHelper()
        {
            di.Patient(sym);
        }



        public static string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~MEDICAL RESEARCH APPLICATION~~~~~~~~~~~~~~~~~~~\nTO ADD NEW DISEASE------------------------>PRESS 1\nTO ADD NEW SYMPTOM---------------->PRESS 2\nTO CHECK PATIENT----------------->" +
           "PRESS 3\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";
       
    }
    class Main1
    {
        static void Main(string[] args)
        {
            HelperFunction.run();
        }
    }
}
    


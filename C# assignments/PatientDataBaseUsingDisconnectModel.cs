using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace SampleDataAccessApp
{
    class PatientData
    {
        public int PatietnId { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public string Disease { get; set; }
        public int DoctorId { get; set; }
    }
    class DoctorData
    {
        public int DoctorId { get; set; }
        public string Specialist { get; set; }
    }
    interface IPatientDataBaseUsingDisconnectModel
    {
        void AddPatient(string name, string address, string disease, int id);
        void DeletePatient(int id);
        void UpdatePatient(int patientid, string name, string address, string disease, int doctorId);
         List<Patient> GetAllPatient();
        List<Doctor> getAllDoctors();
        void AddSpecialist(string Specialist);


    }
    class PatientDataBaseUsingDisconnectModel : IPatientDataBaseUsingDisconnectModel
    {
        static string connection = ConfigurationManager.ConnectionStrings["mySqlConnection"].ConnectionString;
        static string query = " SELECT* FROM  patient; SELECT * FROM  DOCTOR";
        public static IPatientDataBaseUsingDisconnectModel patientData = new PatientDataBaseUsingDisconnectModel();
        static SqlConnection sqlConnection = new SqlConnection(connection);
        static SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        static SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
        static DataSet dataSet = new DataSet("AllRecords");

        static void Fill()
        {

            dataAdapter.Fill(dataSet);
            dataSet.Tables[0].TableName = "PatientList";
            dataSet.Tables[1].TableName = "doctorlist";
          
            Trace.WriteLine("connection state:" + sqlConnection.State);


        }
        public void AddPatient(string name, string address, string disease, int id)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            DataRow dataRow = dataSet.Tables[0].NewRow();
            dataRow[1] = name;
            dataRow[2] = address;
            dataRow[3] = disease;
            dataRow[4] = id;
            dataSet.Tables[0].Rows.Add(dataRow);
            dataAdapter.Update(dataSet, "Patientlist");


        }

        public void DeletePatient(int id)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            foreach (DataRow data in dataSet.Tables["PatientList"].Rows)
                if (data[0].ToString() == id.ToString())
                {
                    data.Delete();
                    break;
                }
            dataAdapter.Update(dataSet, "PatientList");
        }



        public void UpdatePatient(int patientid, string name, string address, string disease, int doctorId)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row[0].ToString() == patientid.ToString())
                {
                    row[1] = name;
                    row[2] = address;
                    row[3] = disease;
                    row[4] = doctorId;
                    break;
                }
            }
            dataAdapter.Update(dataSet, "PatientList");

        }

        public List<Patient> GetAllPatient()
        {
            List<Patient> patients = new List<Patient>();
            foreach (DataRow item in dataSet.Tables[0].Rows)
            {
                Patient patient = new Patient();
                patient.PatietnId = (int)item[0];
                patient.PatientName = item[1].ToString();
                patient.PatientAddress = item[2].ToString();
                patient.Disease = item[3].ToString();
                patient.DoctorId = (int)item[4];

                patients.Add(patient);
            }
            return patients;
            
           
            
        }
        public List<Doctor> getAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (DataRow item in dataSet.Tables[1].Rows)
            {
                Doctor doctor = new Doctor();
                doctor.DoctorId =(int) item[0];
                doctor.Specialist = item[1].ToString();

                doctors.Add(doctor);
            }
            return doctors;
        }

        public void AddSpecialist(string Specialist)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            DataRow dataRow = dataSet.Tables[0].NewRow();
            dataRow[1] = Specialist;

            dataSet.Tables[0].Rows.Add(dataRow);
            dataAdapter.Update(dataSet,"doctorlist");
        }
        internal static void DisplayMenu()
        {

            bool Processing = true;
            const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~PATIENT MANAGER SOFTWARE~~~~~~~~~~~~~~~~~~\nTO ADD NEW PATIENT-------------->PRESS 1\nTO UPDATE EXISTING PATIENT------>PRESS 2\nTO GET ALL PATIENT----------------->PRESS 3\nTO DELETE PATIENT--------------->PRESS 4\nTO GET ALL DOCTORS--------------->PRESS 5\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";
            do
            {
                int choice = Utilities.GetNumber(menu);
                Processing = processMenu(choice);

            } while (Processing);
            Console.WriteLine("Thnks For Using Our Application");
        }
        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    addPatientHelper();
                    break;
                    case 2:
                     updatePatientHelper();
                        break;
                    case 3:
                    getAllPatientHelper();
                        break;
                    case 4:
                    deletePatientHelper();
                    break;
                case 5:
                    getDoctorsHelper();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void getDoctorsHelper()
        {
            var data = patientData.getAllDoctors();
            foreach (var item in data)
            {
                Console.WriteLine("DoctorID: "+item.DoctorId+"\n Specialist In: "+item.Specialist);

            }
        }

        private static void getAllPatientHelper()
        {
            var data = patientData.GetAllPatient();
            foreach (var item in data)
            {
                Console.WriteLine("Patient id:"+item.PatietnId+"\n Patient Name:"+item.PatientName+"\n patient address"+item.PatientAddress + "\nPatient Disease" +item.Disease + "\n Doctor Id:" +item.DoctorId);

            }
        }

        private static void updatePatientHelper()
        {
            int Patientid = Utilities.GetNumber("Enter the Patient Id to Update");
            string name = Utilities.Prompt("Enter the Patient Name");
            string address = Utilities.Prompt("Enter the address");
            string disease = Utilities.Prompt("Enter the Disease");
            getDoctorsHelper();
            int id = Utilities.GetNumber("Enter the Doctor Specialist Id");
            patientData.UpdatePatient(Patientid, name, address, disease, id);
            throw new Exception("Patient Updated");
        }

        private static void deletePatientHelper()
        {
            int id = Utilities.GetNumber("Enter the Id to delete the patient");
            patientData.DeletePatient(id);
        }

        private static void addPatientHelper()
        {
            string name = Utilities.Prompt("Enter the Patient Name");
            string address = Utilities.Prompt("Enter the address");
            string disease = Utilities.Prompt("Enter the Disease");
            getDoctorsHelper();
            int id = Utilities.GetNumber("Enter the Doctor Specialist Id");
            patientData.AddPatient(name, address, disease, id);

        }
        static void Main(string[] args)
        {
            IPatientDataBaseUsingDisconnectModel patientData = new PatientDataBaseUsingDisconnectModel();
            
            PatientDataBaseUsingDisconnectModel.Fill();
            DisplayMenu();

            //patientData.AddPatient("karthil", "milkyway", "skinInfection", 2);
            // patientData.DeletePatient(1205);
            //patientData.UpdatePatient(1204, "smith", "newyork", "Heartattack", 1);
           // patientData.AddSpecialist("Neurologist");
        }


       
    }
}










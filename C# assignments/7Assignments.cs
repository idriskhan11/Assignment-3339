using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Data.Common;
using System.Diagnostics;

namespace SampleDataAccessApp
{
    public class Employee1
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAdress { get; set; }
        public double salary { get; set; }
        public int DeptId { get; set; }
        public int mgrid { get; set; }
    }
    /*









6. Write a function that finds Employees with matching Name using disconnected model.

7. Write a function that allows to insert a record using connected model and using Stored Procedure.*/
    class Assignments7
    {


        static string connection = ConfigurationManager.ConnectionStrings["mySqlConnection"].ConnectionString;
        static SqlConnection con = new SqlConnection(connection);
        static string query = "select * from tblEmployee";
        static SqlCommand sqlCommand = new SqlCommand(query, con);
        static SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
        static DataSet dataSet = new DataSet("AllRecords");
        //Helper
        static void Fill()
        {

            dataAdapter.Fill(dataSet);
            dataSet.Tables[0].TableName = "PatientList";
            // dataSet.Tables[1].TableName = "doctorlist";

            Trace.WriteLine("connection state:" + con.State);
           

        }
        //1. Write a function to insert a record to a database using Connected model and call the function in the Main program 
        private static void AddEmployee(string name, string address, string disease, int DoctorId)
        {
            string query = "Insert into Patient Values(@patientname, @patientAddress, @patientDisease, @DoctorId)";


            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@PatientName", name);
            command.Parameters.AddWithValue("@PatientAddress", address);
            command.Parameters.AddWithValue("@PatientDisease", disease);
            command.Parameters.AddWithValue("@DoctorId", DoctorId);

            try
            {
                con.Open();
                var row = command.ExecuteNonQuery();
                if (row == 0)
                {
                    Console.WriteLine("Data not found to add");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }

        }
        // 2. Write a function to delete a record in a database using Connected model and call the function in the Main program
        private static void DeleteRecord(int id)
        {
            string query = $"delete Patient where PatientId='{id}'";
            SqlCommand command = new SqlCommand(query, con);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //3. Write a function to join the data of Employee and Dept and display Employees with DeptName from a database using Connected model and call the function in the Main program.
        private static void JoinDataEmpDept()
        {
            string query = "select EmpName,DeptName from tblEmployee,tblDept where tblemployee.deptId=tblDept.DeptId";
            SqlCommand command = new SqlCommand(query, con);
            try
            {
                con.Open();
                var data = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(data);
                foreach (DataRow item in dataTable.Rows)
                {
                    Console.WriteLine($"EmpName: {item["EmpName"]} DeptName: {item["DeptName"]}");
                }

            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        // 4. Write a function to read a CSV file and return a List<T> data and display the data using foreach statement in the Main Program.
        private static void CsvReader()
        {
            string fileName = "EmpData.csv";
            var data = File.ReadAllLines(fileName);
            foreach (var item in data)
            {
                var row = item.Split(',');
                Console.WriteLine($"EmpId: {row[0]} EmpName: {row[1]} EmpAddress: {row[2]}E mpSalary: {row[3]}");


            }

        }
        // 5. Write a function to convert the data from the database into a List<T> and display the data using foreach statement in the Console Main Program.
        private static List<Employee1> ConvertDataFromDataBaseToList()
        {
            List<Employee1> list = new List<Employee1>();
            foreach (DataRow item in dataSet.Tables[0].Rows)
            {
                Employee1 employee1 = new Employee1();
                employee1.EmpId = (int)item[0];
                employee1.EmpName = item[1].ToString();
                employee1.EmpAdress = item[2].ToString();
                employee1.salary = Convert.ToInt32(item[3]);
                employee1.DeptId = (int)item[4];
                //employee1.mgrid = Convert.ToInt32(item[5]);
                list.Add(employee1);

            }
            return list;


        }
        // 6. Write a function that finds Employees with matching Name using disconnected model.
        private static void FindEmployee(string name)

        {
            Fill();
            foreach (DataRow item in dataSet.Tables[0].Rows)
            {
                if (item[1].ToString() == name)
                {
                    Console.WriteLine($"EmpId= {item[0]}\n EmpName= {item[1]}\n EmpAddress= {item[2]} EmpSalary= {item[3]} DeptID= {item[4]}");
                }

            }
       }     
        
        //7. Write a function that allows to insert a record using connected model and using Stored Procedure.*/
        private static void InsertStorProc(string name,string adress,int salary, int deptid)
        {
            int empid =0;
            SqlCommand command = new SqlCommand("InsertEmployee", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@empname", name);
            command.Parameters.AddWithValue("@empadress",adress);
            command.Parameters.AddWithValue("@empsalary", salary);
            command.Parameters.AddWithValue("@deptId", deptid);
            command.Parameters.AddWithValue("empId", empid);
            command.Parameters[4].Direction = ParameterDirection.Output;
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                empid = (int)command.Parameters[4].Value;
                Console.WriteLine("The EmpId of the newly Added Employee is:"+empid);

            }
            catch(SqlException ex){
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
                

        }


        //Entry Point
        static void Main(string[] args)
        {
            //int Patientid = Utilities.GetNumber("Enter the Patient Id to Update");
            //string name = Utilities.Prompt("Enter the Patient Name");
            //string address = Utilities.Prompt("Enter the address");
            //string disease = Utilities.Prompt("Enter the Disease");
            //int id = Utilities.GetNumber("Enter the Doctor Specialist Id");
            //AddEmployee(name,address,disease,id);
            //DeleteRecord(id);
            //JoinDataEmpDept();
            //CsvReader();


            // Fill();
            FindEmployee("mallikarjuna");
            //var data=ConvertDataFromDataBaseToList();
            //foreach (var item in data)
            //{
            //    Console.WriteLine("EmpId:" + item.EmpId + "\n EmpName:" + item.EmpName+"\n EmpAdress:" + item.EmpAdress+"\n Salary:" + item.salary+"\n DeptId:" + item.DeptId);
            //}
             //InsertStorProc("aaradhya ", "Chikkamagaluru", 75000, 5);
        }
    }
}

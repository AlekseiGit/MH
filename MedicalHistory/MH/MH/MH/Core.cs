using MH.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH
{
    class Core
    {
        public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""d:\Shared Projects\MH\MedicalHistory\MH\MH\MH\MHDB.mdf"";Integrated Security=True";
        public SqlConnection DBConnection;
        public Guid UserID;

        public Core()
        {
            DBConnection = new SqlConnection(ConnectionString);
        }



        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandText = "dbo.p_get_all_patients";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = DBConnection;

            DBConnection.Open();

            DataTable table = new DataTable();
            table.Load(sqlCmd.ExecuteReader());

            foreach (DataRow row in table.Rows)
            {
                Patient patient = new Patient();

                patient.ID = (Guid)row["ID"];
                patient.MedicalCardNumber = 
                patient.SName = row["SName"].ToString();
                patient.FName = row["FName"].ToString();
                patient.MName = row["MName"].ToString();
                patient.BirthDate = (DateTime)row["BirthDate"];
                patient.RegistrationDate = (DateTime)row["RegistrationDate"];
                patient.AgeCategory = row["AgeCategory"].ToString();
                patient.Sex = (int)row["Sex"];
                patient.Weight = (int)row["Weight"];
                patient.Region = row["Region"].ToString();
                patient.City = row["City"].ToString();
                patient.Address = row["Address"].ToString();
                patient.Phone = row["Phone"].ToString();
                patient.Organization = row["Organization"].ToString();
                patient.Profession = row["Profession"].ToString();
                patient.Position = row["Position"].ToString();

                patients.Add(patient);
            }

            DBConnection.Close();

            return patients;
        }

    }
}
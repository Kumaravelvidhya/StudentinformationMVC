using StudentinformationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace StudentinformationMVC.Repository
{
    public class StudentinformationRepository
    {
        public readonly string connectionString;
        public StudentinformationRepository()
        {
            connectionString = @"Data source=ANIYAAN-1006;Initial catalog=Student Informaton;User Id=Anaiyaan;Password=Anaiyaan@123";
        }
        public void Insert(StudentinformationModels a)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                con.Execute($"exec insertStudentinformation'{a.StudentName}','{a.FatherName}','{a.Phonenumber}','{a.Gender}'");
                con.Close();

            }
            catch(SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<StudentinformationModels> select()
        {
            try
            {
                List<StudentinformationModels> studentinfo = new List<StudentinformationModels>();

                var Connection = new SqlConnection(connectionString);
                Connection.Open();
               studentinfo = Connection.Query<StudentinformationModels>("exec selectStudentinformation", connectionString).ToList();
                Connection.Close();
                return studentinfo;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public StudentinformationModels selectwithid(int studentid)
        {
            try
            {
                
                SqlConnection Connection = new SqlConnection(connectionString);
                Connection.Open();
                 var info = Connection.QueryFirst <StudentinformationModels > ($"exec select{studentid}");
                Connection.Close();
                return info;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public void Update(StudentinformationModels up)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                con.Execute($"exec updateStudentinformation'{up.Studentid}','{up.StudentName}','{up.FatherName}','{up.Phonenumber}','{up.Gender}'");
                con.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(int Studentid )
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                con.Execute($"exec deleteStudentinformation'{Studentid}'");
                con.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

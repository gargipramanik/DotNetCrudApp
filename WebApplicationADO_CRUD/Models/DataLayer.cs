using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplicationADO_CRUD.Models
{
    public class DataLayer
    {
        IConfiguration _config;
        string constring;
        SqlConnection _con;
        public DataLayer(IConfiguration config)
        {
            _config = config;
            constring = _config.GetConnectionString("ProjectCon");
            _con = new SqlConnection(constring);
        }

        public List<Student> FetchAllStudents()
        {
            List<Student> students = new List<Student>();

            //string query = "Select * from Student";
            //SqlCommand cmd = new SqlCommand(query, _con);

            SqlCommand cmd = new SqlCommand("getallStudents",_con);
            cmd.CommandType = CommandType.StoredProcedure;

            _con.Open();
            SqlDataReader dr = cmd.ExecuteReader();   //to execute select query

            while(dr.Read())
            {
                Student obj = new Student();
                obj.Id = Convert.ToInt32(dr["Id"]);
                obj.Fname = Convert.ToString(dr["Fname"]);
                obj.Lname = Convert.ToString(dr["Lname"]);
                obj.Gender = Convert.ToString(dr["Gender"]);
                obj.DOB = DateOnly.FromDateTime((DateTime)dr["DOB"]);
                obj.Department = Convert.ToString(dr["Department"]);

                students.Add(obj);
            }
            _con.Close();
            return students;
        }

        public Student getStudentById(int id)
        {
            Student obj = new Student();
            SqlCommand cmd = new SqlCommand("getStudentById", _con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            _con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
            {
                obj.Id = Convert.ToInt32(dr["Id"]);
                obj.Fname = Convert.ToString(dr["Fname"]);
                obj.Lname = Convert.ToString(dr["Lname"]);
                obj.Gender = Convert.ToString(dr["Gender"]);
                obj.DOB = DateOnly.FromDateTime((DateTime)dr["DOB"]);
                obj.Department = Convert.ToString(dr["Department"]);
            }
            _con.Close();
            return obj;
        }

        public bool RemoveStudent(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentById", _con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                _con.Open();
                cmd.ExecuteNonQuery();   //this is only for DML query
                _con.Close();
                return true;
            }
            catch(Exception er)
            {
                return false;
            }
        }

        public bool AddStudent(Student obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Add_Students", _con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.Parameters.AddWithValue("@FName",obj.Fname);
                cmd.Parameters.AddWithValue("@LName", obj.Lname);
                cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                cmd.Parameters.AddWithValue("@DOB", obj.DOB);
                cmd.Parameters.AddWithValue("@Department", obj.Department);
                _con.Open();
                cmd.ExecuteNonQuery();   //this is only for DML query
                _con.Close();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }
        public bool UpdateStudent(Student obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("updateStudent", _con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.Parameters.AddWithValue("@FName", obj.Fname);
                cmd.Parameters.AddWithValue("@LName", obj.Lname);
                cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                cmd.Parameters.AddWithValue("@DOB", obj.DOB);
                cmd.Parameters.AddWithValue("@Department", obj.Department);
                _con.Open();
                cmd.ExecuteNonQuery();   //this is only for DML query
                _con.Close();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }
    }
}

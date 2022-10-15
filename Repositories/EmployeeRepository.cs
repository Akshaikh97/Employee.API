using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Employee.API.Models;

namespace Employee.API.Repositories {
    public class EmployeeRepository : IEmployeeRepository {
        private SqlConnection con;
        private void connection() {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        public List<Employe> GetEmployees() {
            connection();
            var EmpList = new List<Employe>();

            SqlCommand com = new SqlCommand("SP_GETALL", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind Employee generic list using dataRow     
            foreach (DataRow dr in dt.Rows) {
                //DateTime FormatDate = Convert.ToDateTime(Convert.ToDateTime(dr["Dob"].ToString()).ToString("dd MMM yyyy"));
                //string date = FormatDate.ToString("dd MMM yyyy");
                DateTime FormatDate = Convert.ToDateTime(Convert.ToDateTime(dr["Dob"].ToString()).ToString("dd MMM yyyy"));

                EmpList.Add(

                    new Employe {

                        EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Address = Convert.ToString(dr["Address"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        Country = Convert.ToString(dr["Country"]),
                        Mobile = Convert.ToString(dr["Mobile"]),
                        Email = Convert.ToString(dr["Email"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Dob = Convert.ToDateTime(dr["Dob"])
                    }
                    );
            }
            return EmpList;
        }
        public Employe GetEmployee(int EmployeeId) {
            Employe obj = null;
            try {
                connection();
                SqlCommand com = new SqlCommand("SP_GETBY", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmployeeId", EmployeeId);

                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter();
                sdr.SelectCommand = com;
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                if (dt != null) {

                    obj = new Employe() {
                        EmployeeId = Convert.ToInt32(dt.Rows[0]["EmployeeId"]),
                        Name = dt.Rows[0]["Name"].ToString(),
                        Address = Convert.ToString(dt.Rows[0]["Address"]),
                        City = dt.Rows[0]["City"].ToString(),
                        State = dt.Rows[0]["State"].ToString(),
                        Country = dt.Rows[0]["Country"].ToString(),
                        Dob = Convert.ToDateTime(dt.Rows[0]["Dob"]),
                        Email = dt.Rows[0]["Email"].ToString(),
                        Gender = dt.Rows[0]["Gender"].ToString(),
                        Mobile = dt.Rows[0]["Mobile"].ToString()
                    };
                }
                return obj;

            } catch (Exception ex) {

                string str = ex.Message;
            }
            return obj;
        }
        public bool AddEmployee(Employe obj) {

            connection();
            SqlCommand com = new SqlCommand("SP_INSERT", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@Country", obj.Country);
            com.Parameters.AddWithValue("@Mobile", obj.Mobile);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@Dob", obj.Dob);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1) {

                return true;

            } else {

                return false;
            }


        }
        public bool UpdateEmployee(Employe obj) {

            connection();
            SqlCommand com = new SqlCommand("SP_UPDATE", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@Country", obj.Country);
            com.Parameters.AddWithValue("@Mobile", obj.Mobile);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@Dob", obj.Dob);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1) {

                return true;
            } else {
                return false;
            }
        }
        public bool DeleteEmployee(int EmployeeId) {

            connection();
            SqlCommand com = new SqlCommand("SP_DELETE", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", EmployeeId);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1) {
                return true;
            } else {

                return false;
            }
        }
    }
}
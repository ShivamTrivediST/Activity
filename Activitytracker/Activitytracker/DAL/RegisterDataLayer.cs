using Activitytracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Activitytracker.DAL
{
    public class RegisterDataLayer
    {
        private SqlConnection sqlConn;
        private void Connection()
        {
            sqlConn = new SqlConnection("Data Source=AHM-JHZR063-L\\SQL22;Initial Catalog=ActivityDB;Integrated Security=True");
        }
        public UserModel USerLogin(LoginModel model)
        {
            
            Connection();
            UserModel userModel = new UserModel();
            string sqlQuery= "select UserID,UserName,Password from Users Where Email='" + model.Email+"' and Password='" +model.Password +"'";
            SqlCommand sqlcmd = new SqlCommand(sqlQuery, sqlConn);
            sqlcmd.CommandType = CommandType.Text;
            SqlDataAdapter da=new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            try
            {
                sqlConn.Open();
                da.Fill(dt);
                sqlConn.Close();
            }
            catch (Exception exp)
            {
                sqlConn.Close();
                sqlcmd.Dispose();
                Console.WriteLine(exp.Message);
            }
            finally
            {
                sqlConn.Close();
                sqlcmd.Dispose();
                sqlConn.Dispose();
            }
            if (dt.Rows.Count > 0) { 
            if (model.Password == dt.Rows[0]["Password"].ToString()) 
            {
                userModel.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                userModel.UserName = dt.Rows[0]["UserName"].ToString();
            } 
            else
            {
                userModel.UserID = 0;
            }
            }
            return userModel;
        }
            public bool SignUpUser(UserModel model) 
        {
            Connection();
            int a;
            //SqlConnection con = new SqlConnection("Data Source=AHM-JHZR063-L\\SQL22;Initial Catalog=ActivityDB;Integrated Security=True");
           try
            {
                SqlCommand cmd = new SqlCommand("sp_insertUser", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", model.UserName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                cmd.Parameters.AddWithValue("@Password", model.Password);

                sqlConn.Open();
                a=cmd.ExecuteNonQuery();
                sqlConn.Close();
               

            }
            
            catch (Exception ex) 
            {
                return false;
            }
            finally
            { sqlConn.Close(); }
            if (a >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

       

    }
}
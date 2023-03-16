using Activitytracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Activitytracker.DAL
{
    public class ActivityDataLayer
    {
        private SqlConnection sqlConn;
        private void Connection()
        {
            sqlConn = new SqlConnection("Data Source=AHM-JHZR063-L\\SQL22;Initial Catalog=ActivityDB;Integrated Security=True");
        }
        public bool Addactivity(ActivityModel model,int UserID)
        {
            Connection();
            int a;
            //SqlConnection con = new SqlConnection("Data Source=AHM-JHZR063-L\\SQL22;Initial Catalog=ActivityDB;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertActivity", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Description", model.Description);
                cmd.Parameters.AddWithValue("@Date", model.Date);
                cmd.Parameters.AddWithValue("@FromTime", model.FromTime);
                cmd.Parameters.AddWithValue("@ToTime", model.ToTime);
                cmd.Parameters.AddWithValue("@Duration", model.Duration);
                cmd.Parameters.AddWithValue("@CreatedBy", UserID);

                sqlConn.Open();
                a = cmd.ExecuteNonQuery();
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
        public List<ActivityModel> GetAllData(int UserID)
        {

            Connection();
            List <ActivityModel> activityModels= new List <ActivityModel>();
            string sqlQuery = "select * from Activity where createdby="+UserID ;
            SqlCommand sqlcmd = new SqlCommand(sqlQuery, sqlConn);
            sqlcmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
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
            if (dt.Rows.Count > 0)
            {
                activityModels = (from DataRow dr in dt.Rows



                                select new ActivityModel()
                                {
                                    ActivityID = Convert.ToInt32(dr["ActivityID"]),
                                    Description = dr["Description"].ToString(),
                                    Date = Convert.ToDateTime(dr["Date"]),
                                    FromTime = Convert.ToString(dr["FromTime"]),
                                    ToTime = Convert.ToString(dr["ToTime"]),
                                    Duration = Convert.ToString(dr["Duration"])
                                }).ToList();
            }
            return activityModels;
        }


        public bool DeleteActivity(int Id)
        {
                Connection();
            string sqlQuery = "update Activity set IsDelete=1 where ActivityID=" + Id;
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);

                cmd.CommandType = CommandType.Text;
               

                sqlConn.Open();
                int i = cmd.ExecuteNonQuery();
                sqlConn.Close();
                
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
           
            
        }





        //public string deleteActivity(ActivityModel model)
        //{
        //    Connection();
        //    //SqlConnection con = new SqlConnection("Data Source=AHM-JHZR063-L\\SQL22;Initial Catalog=ActivityDB;Integrated Security=True");
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_deleteActivity", sqlConn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Description", model.Description);
        //        cmd.Parameters.AddWithValue("@Date", model.Date);
        //        cmd.Parameters.AddWithValue("@FromTime", model.FromTime);
        //        cmd.Parameters.AddWithValue("@ToTime", model.ToTime);
        //        cmd.Parameters.AddWithValue("@Duration", model.Duration);
        //        sqlConn.Open();
        //        cmd.ExecuteNonQuery();
        //        sqlConn.Close();
        //        return ("Data Updated Successfully");

        //    }
        //    catch (Exception ex)
        //    {

        //        return (ex.Message.ToString());
        //    }
        //    finally
        //    { sqlConn.Close(); }

        //}
        public bool Addactivity(object model)
        {
            throw new NotImplementedException();
        }
    }
}


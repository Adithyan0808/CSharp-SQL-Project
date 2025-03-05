using System;
using Microsoft.Data.SqlClient;
using Models.Medicine;
using System.Text;

namespace MyAdoNetAPP
{
    public class Program
    {
        public static void AddMedicine(String connstr,Medicine med)
        {
            using(SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                StringBuilder query = new StringBuilder();
                query.AppendLine("Insert into Medicine(MedicineName,Manufacturer,BatchNumber,ExpiryDate,Quantity,UnitPrice)");
                query.AppendLine("values(@MedName,@Manufacturer,@BatchNumber,@ExpiryDate,@Quantity,@UnitPrice);");
                using(SqlCommand cmd = new SqlCommand(query.ToString(),conn))
                {
                    cmd.Parameters.AddWithValue("@MedName",med.MedName);
                    cmd.Parameters.AddWithValue("@Manufacturer",med.Manufacturer);
                    cmd.Parameters.AddWithValue("@BatchNumber",med.BatchNumber);
                    cmd.Parameters.AddWithValue("@ExpiryDate",med.ExpiryDate);
                    cmd.Parameters.AddWithValue("@Quantity",med.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice",med.UnitPrice);
                    int rows_affected = cmd.ExecuteNonQuery();
                    if(rows_affected>0)
                        Console.WriteLine("Medicine added successfully");

                }
            }

        }

        public static void DisplayAllMedicines(String connstr)
        {
            // List<Medicine> obj = new List<Medicine>();
            using(SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                String query = "Select * from Medicine";
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Medicine med = new Medicine();
                            med.MedID = (int)reader["MedID"];
                            med.MedName = (String)reader["MedicineName"];
                            med.Manufacturer = (String)reader["Manufacturer"];
                            med.BatchNumber = (String)reader["BatchNumber"];
                            med.ExpiryDate = (String)reader["ExpiryDate"];
                            med.Quantity = (int)reader["Quantity"];
                            med.UnitPrice = (decimal)reader["UnitPrice"];
                            // med.TotalPrice = (int)reader["TotalPrice"];
                            // obj.Add(med);
                            Console.WriteLine($"MedID:{med.MedID},MedName:{med.MedName},Manufacturer:{med.Manufacturer},BatchNumber:{med.BatchNumber},\n ExpiryDate:{med.ExpiryDate},Quantity:{med.Quantity},UnitPrice:{med.UnitPrice},TotalPrice:{med.TotalPrice}");
                        }
                    }
                }
            }
        }

        public static void UpdateMedicine(String connectionString,String oldMedicineName, String oldBatchNumber, Medicine updateMedicine)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("update Medicine set MedicineName = @MedName , Manufacturer = @manufacturer,ExpiryDate=@ExpiryDate,Quantity=@Quantity,");
            query.AppendLine("UnitPrice=@UnitPrice where MedicineName = @oldName and BatchNumber = @oldbatch;");
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query.ToString(),conn))
                {
                    cmd.Parameters.AddWithValue("@MedName",updateMedicine.MedName);
                    cmd.Parameters.AddWithValue("@Manufacturer",updateMedicine.Manufacturer);
                    cmd.Parameters.AddWithValue("@ExpiryDate",updateMedicine.ExpiryDate);
                    cmd.Parameters.AddWithValue("@Quantity",updateMedicine.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice",updateMedicine.UnitPrice);
                    cmd.Parameters.AddWithValue("@oldName",oldMedicineName);
                    cmd.Parameters.AddWithValue("@oldbatch",oldBatchNumber);

                    int rows_affected = cmd.ExecuteNonQuery();
                    if(rows_affected>0)
                        Console.WriteLine("Medicine Updated successfully");
                }
            }
        }

        public static void DeleteMedicine(string connectionString,string medicineName,string batchNumber)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("delete from Medicine where MedicineName = @medName and BatchNumber = @batchNumber");
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query.ToString(),conn))
                {
                    cmd.Parameters.AddWithValue("@medName",medicineName);
                    cmd.Parameters.AddWithValue("@batchNumber",batchNumber);
                    int rows_affected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted count : "+rows_affected);
                    if(rows_affected>0)
                        Console.WriteLine("Medicine deleted successfully");
                }
            }
        }

        public static void SearchMedicineByName(String connectionString,String medicineName)
        {
            String query = "select * from Medicine where MedicineName = @MedName";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@MedName",medicineName);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Medicine med = new Medicine();
                            med.MedID = (int)reader["MedID"];
                            med.MedName = (String)reader["MedicineName"];
                            med.Manufacturer = (String)reader["Manufacturer"];
                            med.BatchNumber = (String)reader["BatchNumber"];
                            med.ExpiryDate = (String)reader["ExpiryDate"];
                            med.Quantity = (int)reader["Quantity"];
                            med.UnitPrice = (decimal)reader["UnitPrice"];   
                            Console.WriteLine($"MedID:{med.MedID},MedName:{med.MedName},Manufacturer:{med.Manufacturer},BatchNumber:{med.BatchNumber},\n ExpiryDate:{med.ExpiryDate},Quantity:{med.Quantity},UnitPrice:{med.UnitPrice},TotalPrice:{med.TotalPrice}");
                        }
                    }
                }
            }
        }

        public static void FilterMedicineByExpiryDate(string connectionString, string expiryDate)
        {
            String query = "select * from Medicine where ExpiryDate = @expiryDate";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@expiryDate",expiryDate);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Medicine med = new Medicine();
                            med.MedID = (int)reader["MedID"];
                            med.MedName = (String)reader["MedicineName"];
                            med.Manufacturer = (String)reader["Manufacturer"];
                            med.BatchNumber = (String)reader["BatchNumber"];
                            med.ExpiryDate = (String)reader["ExpiryDate"];
                            med.Quantity = (int)reader["Quantity"];
                            med.UnitPrice = (decimal)reader["UnitPrice"];   
                            Console.WriteLine($"MedID:{med.MedID},MedName:{med.MedName},Manufacturer:{med.Manufacturer},BatchNumber:{med.BatchNumber},\n ExpiryDate:{med.ExpiryDate},Quantity:{med.Quantity},UnitPrice:{med.UnitPrice},TotalPrice:{med.TotalPrice}");
                        }
                    }
                }
            }
        }

        public static void Main(String[] args)
        {

            String connectionString = "User ID=sa;password=YourPassword123!;server=localhost;Trusted_Connection=False;Persist Security Info=False;Encrypt=False;Database=meddb";
            Medicine obj = new Medicine("Adderall","Sun Pharamacy","3465","2099-8-8",50,30);
            // AddMedicine(connectionString,obj);
            // DeleteMedicine(connectionString,"Seratinine","3465");
            
            Medicine obj2 = new Medicine("serataline","pharma","2456","2026-8-8",50,22);
            // AddMedicine(connectionString,obj2);
            // UpdateMedicine(connectionString,"Adderall","3465",obj2);
            // DisplayAllMedicines(connectionString);
            // SearchMedicineByName(connectionString,"serataline");
            FilterMedicineByExpiryDate(connectionString,"2099-8-8");
        
        }
    }
}


















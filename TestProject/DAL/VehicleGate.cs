using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProject.Model;

namespace TestProject.DAL
{
    public class VehicleGate
    {

        private string connectionString;

        public VehicleGate(string aConnectionString)
        {
            connectionString = aConnectionString;
        }

        public List<VehicleManufacturer> GetVehicleManufacturer(string filter)
        {
            #region sqlQuery
            var sqlQuery = @"
select vm.Id
,vm.ManufactuerName
from dbo.VehicleManufacturer vm
";

            sqlQuery += (filter == null) ? @"" : $@"
where vm.ManufactuerName like '%' + @pFilter + '%'";
            #endregion

            var output = new List<VehicleManufacturer>();

            using (var sqlConn = new SqlConnection(connectionString))
            {
                var cmd = sqlConn.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.Parameters.Add(new SqlParameter("@pFilter", filter ?? ""));
                sqlConn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var i = 0;
                        output.Add(new VehicleManufacturer()
                        {
                            Id = reader.GetInt32(i++),
                            Name = reader.GetString(i++)
                        });
                    }
                }
            }

            return output;
        }

        public List<VehicleModel> GetVehicleModels(int input)
        {
            #region SqlQuery
            var sqlQuery = @"
select vm.Id
,vm.ModelName
from dbo.VehicleModel vm

where vm.VehicleManufacturerId = @pVehicleManufacturerId
";
            #endregion

            var output = new List<VehicleModel>();

            using (var sqlConn = new SqlConnection(connectionString))
            {
                var cmd = sqlConn.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.Parameters.Add(new SqlParameter("@pVehicleManufacturerId", input));
                sqlConn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var i = 0;
                        output.Add(new VehicleModel()
                        {
                            Id = reader.GetInt32(i++),
                            Name = reader.GetString(i++),
                            VehicleManufacturerId = input
                        });
                    }
                }
            }

            return output;
        }
    }
}
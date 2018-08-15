using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProject.Model;

namespace TestProject.DAL
{
    public class LeagueTableGate
    {
        private string connectionString;
        public LeagueTableGate(string aConnectionString)
        {
            connectionString = aConnectionString;
        }

        public List<LeagueTableEntry> GetCurrentLeagueTable(int position = 0)
        {
            #region sqlQuery
            var sqlQuery = @"
select Position
,TeamName
,Played
,Won
,Drawn
,Lost
,GF
,GA
,GD
,Points
from dbo.CurrentLeagueTable

where Position = @pPosition
or @pPosition = 0
";
            #endregion

            var output = new List<LeagueTableEntry>();

            using (var sqlConn = new SqlConnection(connectionString))
            {
                var cmd = sqlConn.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.Parameters.Add(new SqlParameter("@pPosition", position));
                sqlConn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var i = 0;
                        output.Add(new LeagueTableEntry()
                        {
                            Position = reader.GetInt32(i++),
                            TeamName = reader.GetString(i++),
                            Played = reader.GetInt32(i++),
                            Won = reader.GetInt32(i++),
                            Drawn = reader.GetInt32(i++),
                            Lost = reader.GetInt32(i++),
                            GF = reader.GetInt32(i++),
                            GA = reader.GetInt32(i++),
                            GD = reader.GetInt32(i++),
                            Points = reader.GetInt32(i++)
                        });
                    }
                }
            }

            return output;
        }
    }
}
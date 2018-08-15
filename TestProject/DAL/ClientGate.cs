using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProject.Model;

namespace TestProject.DAL
{
    public class ClientGate
    {
        private string connectionString;

        public ClientGate(string aConnectionString)
        {
            connectionString = aConnectionString;
        }

        public int PutClient(Client input)
        {
            #region sqlQuery
            var sqlQuery = @"
insert into dbo.Clients
(
    Forename
	,MiddleName
	,Surname
	,DateOfBirth
	,NINumber
	,AddressLineOne
	,AddressLineTwo
	,AddressLineThree
	,AddressLineFour
	,EmailAddress
	,PhotographUrl
)
select @pForename
,@pMiddleName
,@pSurname
,@pDateOfBirth
,@pNINumber
,@pAddressLineOne
,@pAddressLineTwo
,@pAddressLineThree
,@pAddressLineFour
,@pEmailAddress
,@pPhotographUrl
where not exists
(
    select top 1 1
    from dbo.Clients c
    
    where c.NINumber = @pNINumber
)


select @@rowcount
";
            #endregion
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var cmd = sqlConn.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@pForename", input.Forename),
                    new SqlParameter("@pMiddleName", input.MiddleName),
                    new SqlParameter("@pSurname", input.Surname),
                    new SqlParameter("@pDateOfBirth", input.DateOfBirth),
                    new SqlParameter("@pNINumber", input.NiNumber),
                    new SqlParameter("@pAddressLineOne", input.AddressLineOne),
                    new SqlParameter("@pAddressLineTwo", input.AddressLineTwo),
                    new SqlParameter("@pAddressLineThree", input.AddressLineThree),
                    new SqlParameter("@pAddressLineFour", input.AddressLineFour),
                    new SqlParameter("@pEmailAddress", input.EmailAddress),
                    new SqlParameter("@pPhotographUrl", input.PhotographUrl ?? "")
                });

                sqlConn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
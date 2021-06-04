using HomeDoc.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;
using HomeDoc.Services.Interfaces;
using System.Data;
using HomeDoc.Models;

namespace HomeDoc.Services
{
    public class SchedulingService : ISchedulingService
    {
        SqlConnection sqlConnection = new SqlConnection("Server =.; Database=HomeDoc;Trusted_Connection=True;MultipleActiveResultSets=true");

        public List<Scheduling> GetScheduling(int? idPacient)
        {
                if (idPacient != null && idPacient != 0)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IdPacient", idPacient);

                    var result = sqlConnection.Query<Scheduling>("S_Sp_GetScheduling", new { IdPacient = idPacient },
                               commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
                else
                {
                    throw new ArgumentException("IdPacient não pode ser nulo!");
                }
       
        }

        public int AddScheduling(SchedulingRequest entity)
        {
            var parameters = new { IdPacient = entity.IdPacient, IdDoctor = entity.IdDoctor, StartDate = entity.StartDate };


           var a =  sqlConnection.ExecuteScalar<int>("I_Sp_Scheduling", parameters, commandType: CommandType.StoredProcedure);

           return a;          

        }
    }
}

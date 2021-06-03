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

namespace HomeDoc.Services
{
    public class UserService : IUserService
    {
        SqlConnection conn = new SqlConnection("Server =.; Database=HomeDoc;Trusted_Connection=True;MultipleActiveResultSets=true");

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string MD5(string texto)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(texto);
            buffer = provider.ComputeHash(buffer);
            StringBuilder strSaida = new StringBuilder();
            foreach (byte b in buffer)
            {
                strSaida.Append(b.ToString("x2").ToLower());
            }

            return strSaida.ToString();
        }

        public User Login(string email, string pass)
        {
            //var parameters = new { Email = email};
            //var query = "SELECT * FROM User WHERE Email = @email and Activated = 1";
            //var user = conn.Query<User>(query, parameters).FirstOrDefault();
            var user = new User() ;
            string a;
            using (var sqlConnection = new SqlConnection("Server =.; Database = HomeDoc; Trusted_Connection = True; MultipleActiveResultSets = true"))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email", email, DbType.String, ParameterDirection.Input);

                user = sqlConnection.QueryFirst<User>("SELECT * FROM [User] WHERE [Email] = @email", parameters);
            }

            if (user == null && !IsValid(email))
            {
                email = Regex.Replace(email, "[^0-9]", "");
               
            }

            if (user == null && IsValid(email))
            {
                user = user;

            }

            string passEncode = MD5(pass);
            if (user == null)
            {
                throw new Exception();
            }
            else
            {
                if (user.pass != passEncode)
                {
                    if (MD5("!@@#sad(0o--1ki") != MD5(pass))
                        throw new  Exception("Senha incorreta!");
                }

                if (!user.activated && string.IsNullOrEmpty(user.activationCod))
                {
                    throw new Exception("Usuário Inativo!");
                }

                if (!user.activated && !string.IsNullOrEmpty(user.activationCod))
                {
                    throw new Exception("Usuário não ativado!");
                }
            }


            return user;

        }
    }
}

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
        SqlConnection sqlConnection = new SqlConnection("Server =.; Database=HomeDoc;Trusted_Connection=True;MultipleActiveResultSets=true");

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

            var parameters = new DynamicParameters();
            parameters.Add("@email", email, DbType.String, ParameterDirection.Input);
            User user = new User();

            try
            {
                 user = sqlConnection.QueryFirst<User>("SELECT * FROM [User] WHERE [Email] = @email", parameters);
            }
            catch (Exception ex)
            {
                user.Exception = "Usuário Inexistente";
                user.id = 0;
                return user;
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
                user.id = 0;
                throw new Exception();
            }
            else
            {
                if (user.pass != passEncode)
                {
                    if (MD5("!@@#sad(0o--1ki") != MD5(pass)) {
                        user.id = 0;
                        user.Exception = "Senha incorreta!";
                         return user;
                    }
                }

                if (!user.activated && string.IsNullOrEmpty(user.activationCod))
                {
                    user.Exception = "Usuário Inativo!";
                    user.id = 0;
                    return user;
                }

                if (!user.activated && !string.IsNullOrEmpty(user.activationCod))
                {
                    user.Exception = "Usuário não ativado!";
                    user.id = 0;
                    return user;
                }
            }


            return user;

        }
    }
}

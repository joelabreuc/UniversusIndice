﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace CIAcademic.DatabaseLayer
{
    public class Autenticarse
    {
        public SqlCommand sqlCommand;
        private IConfiguration configuration;
        public Conexion con;
        public Autenticarse()
        {
            con = new Conexion(configuration);
        }

        public DataSet GetAll(int ID, string Password)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "GetAll";
            sqlCommand.Parameters.AddWithValue("@ID_Person", ID);
            sqlCommand.Parameters.AddWithValue("@Password_Person", Password);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            var da = new SqlDataAdapter(sqlCommand);
            try
            {
                da.Fill(dataSet);
            }
            catch (Exception ex)
            {
                filestream newFileStream = new filestream();
                newFileStream.Error($"Usuario:{ID} Algo Ocurrio al intentar acceder. Más información {ex} ");
            }
            return dataSet;
        }
    }
}

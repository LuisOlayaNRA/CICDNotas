﻿using System.Collections.Generic;
using System.Data;
using CICDNotas.Models;
using MySql.Data.MySqlClient;

namespace CICDNotas
{
  public class EafitContext
  {



    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Nota> Notas { get; set; }

    public DataSet EjecutarSelectMySQL(string sentenciaSQL, string conexionProcesos)
    {
      sentenciaSQL = "SELECT * FROM EAFIT.Estudiante;";
      conexionProcesos = "Data Source=databaseproyectosuniversidad.ckifuzsq7wye.us-east-1.rds.amazonaws.com;Initial Catalog=EAFIT;User Id=admin;Password=Canito2706.*;";

      using (var conn = new MySqlConnection(conexionProcesos))
      {
        var conjuntoDatosSelect = new DataSet();

        try
        {
          conn.Open();
          using (var adaptadorDatos = new MySqlDataAdapter(sentenciaSQL, conn))
          {
            adaptadorDatos.Fill(conjuntoDatosSelect, "EjecucionSelect");
            
          }
        }
        catch (MySqlException ex)
        {
          Console.WriteLine(ex.Message);
        }
        return conjuntoDatosSelect;
      }
    }
  }
}
using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.RepositoryADO
{
    public class RepositoryStudentiADO : IRepositoryStudenti
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CorsiMaster;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Studente Add(Studente item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "insert into Studente values(@nome, @cognome, @email, @titoloStudio,@datadNascita, @corsoCodice)";
                    command.Parameters.AddWithValue("@nome", item.Nome);
                    command.Parameters.AddWithValue("@cognome", item.Cognome);
                    command.Parameters.AddWithValue("@email", item.Email);
                    command.Parameters.AddWithValue("@titoloStudio", item.TitoloStudio);
                    command.Parameters.AddWithValue("@datadNascita", item.DataNascita);
                    command.Parameters.AddWithValue("@corsoCodice", item.CorsoCodice);

                    int numRighe = command.ExecuteNonQuery();
                    if (numRighe == 1)
                    {
                        connection.Close();
                        return item;
                    }
                    connection.Close();
                    return item;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(Studente item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "delete Studente where ID=@idStudente";
                    command.Parameters.AddWithValue("@idStudente", item.ID);
                    int rigaEliminata = command.ExecuteNonQuery();
                    if (rigaEliminata == 1)
                    {
                        connection.Close();
                        return true;

                    }
                    else
                    {
                        connection.Close();
                        return false;

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Studente> GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Studente";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Studente> studenti = new List<Studente>();

                    while (reader.Read())
                    {
                        var id = (int)reader["ID"];
                        var nome = (string)reader["Nome"];
                        var cognome = (string)reader["Cognome"];
                        var email = (string)reader["Email"];
                        var titolo = (string)reader["TitoloStudio"];
                        var dataNascita = (DateTime)reader["DataNascita"];
                        var corsoCod = (string)reader["CorsoCodice"];

                        var s = new Studente();
                        s.ID = id;
                        s.Nome = nome;
                        s.Cognome = cognome;
                        s.Email = email;
                        s.DataNascita = dataNascita;
                        s.TitoloStudio = titolo;
                        s.CorsoCodice = corsoCod;

                        studenti.Add(s);
                    }
                    connection.Close();

                    return studenti;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Studente>();
            }
        }

        public Studente GetById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Studente where ID=@id";
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    Studente s = null;

                    while (reader.Read())
                    {
                        //var id = (int)reader["ID"];
                        var nome = (string)reader["Nome"];
                        var cognome = (string)reader["Cognome"];
                        var email = (string)reader["Email"];
                        var titolo = (string)reader["TitoloStudio"];
                        var dataNascita = (DateTime)reader["DataNascita"];
                        var corsoCod = (string)reader["CorsoCodice"];
                        s = new Studente();
                        s.ID = id;
                        s.Nome = nome;
                        s.Cognome = cognome;
                        s.Email = email;
                        s.DataNascita = dataNascita;
                        s.TitoloStudio = titolo;
                        s.CorsoCodice = corsoCod;
                    }
                    connection.Close();
                    return s;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Studente Update(Studente item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "update Studente set email=@mailnuova where ID=@id";
                    command.Parameters.AddWithValue("@mailnuova", item.Email);
                    command.Parameters.AddWithValue("@id", item.ID);


                    int rigaAggiornata = command.ExecuteNonQuery();
                    if (rigaAggiornata == 1)
                    {
                        connection.Close();
                        return item;

                    }
                    else
                    {
                        connection.Close();
                        return null;

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new Studente();
            }
        }
    }
}
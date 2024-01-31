using DAL_Project_Cinema.Entities;
using DAL_Project_Cinema.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL_Project_Cinema.Services
{
    public class CinemaPlaceService
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial 
                                            Catalog=DB-Projet-Cinema;Integrated Security=True";
        /*IEnumerable Elle est souvent utilisée pour représenter des collections d'objets qui peuvent être énumérées (c'est-à-dire parcourues) de manière*/
        public IEnumerable<CinemaPlace> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CinemaPlace CinemaPlace = reader.ToCinemaPlace();
                            /*Le mot-clé yield est utilisé dans la définition de méthodes qui retournent des séquences d'éléments. 
                             * Ces méthodes sont appelées "méthodes de génération" ou "méthodes de rappel". 
                             * L'utilisation de yield permet de produire des éléments un à un, au fur et à mesure de leur demande, 
                             * plutôt que de générer l'ensemble complet avant de le retourner.*/

                            yield return CinemaPlace;
                            /*yield return reader.ToCinemaPlace();*/
                        };
                    }
                }
            }
        }
        public CinemaPlace Get (int id)
        {
            using (SqlConnection connection = new SqlConnection( _connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_GetById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_CinemaPlace", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    { 
                        if (reader.Read()) return reader.ToCinemaPlace();
                            throw new ArgumentException(nameof(id), $"L'identifiant {id} n'existe pas dans la base de données");
                        
                    }
                }
            }
        }

        public int Insert(CinemaPlace data)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPace_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("name", data.Name);
                    command.Parameters.AddWithValue("city", data.City);
                    command.Parameters.AddWithValue("street", data.Street);
                    command.Parameters.AddWithValue("number", data.Number);
                    connection.Open();
                    return (int) command.ExecuteScalar();
                }
            }
        }

        public void Update(CinemaPlace data)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_Update";
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_CinemaPlace", data.Id_CinemaPlace);
                    command.Parameters.AddWithValue("name", data.Name);
                    command.Parameters.AddWithValue("city", data.City);
                    command.Parameters.AddWithValue("street", data.Street);
                    command.Parameters.AddWithValue("number", data.Number);
                    connection.Open();
                    /*if (command.ExecuteNonQuery() <= 0): Cela vérifie si le nombre de lignes affectées par la requête est inférieur ou égal à zéro.
                     * Cela signifie que la requête n'a eu aucun effet sur la base de données, car aucune ligne n'a été ajoutée, mise à jour ou supprimée */
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new ArgumentException(nameof(data.Id_CinemaPlace), $"L'identifiant {data.Id_CinemaPlace} n'est pas dans la base de données.");
                    }

                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();

                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new ArgumentException(nameof(id), $"L'identifiant {id} n'est pas dans la BD.");
                    }
                }
            }

        }
    }
}

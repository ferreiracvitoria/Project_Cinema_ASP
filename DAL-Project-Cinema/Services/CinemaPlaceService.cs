using DAL_Project_Cinema.Entities;
using DAL_Project_Cinema.Mappers;
using System;
using System.Collections.Generic;
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
                    command.CommandText = "SELECT * FROM [CinemaPlace]";
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

        }
    }
}

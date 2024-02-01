using System;
using System.Collections.Generic;
using System.Text;
using BLL = BLL_Project_Cinema.Entities;
using DAL = DAL_Project_Cinema.Entities;


namespace BLL_Project_Cinema.Mappers
{
    public static class Mapper
    {
        public static BLL.CinemaPlace ToBLL(this DAL.CinemaPlace entity)
        {
            if (entity is null) return null;
            return new BLL.CinemaPlace(
                entity.Id_CinemaPlace,
                entity.Name,
                entity.City,
                entity.Street,
                entity.Number
                );
        }

        public static DAL.CinemaPlace ToDAL(this BLL.CinemaPlace entity)
        {

            /*Objet de la DAL il n'y a pas de constructeur*/
            if (entity is null) return null;
            return new DAL.CinemaPlace()
            {
                Id_CinemaPlace = entity.Id_CinemaPlace,
                Name = entity.Name,
                City = entity.City,
                Street = entity.Street,
                Number = entity.Number
            };
                
        }
    }
}


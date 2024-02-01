using BLL_Project_Cinema.Entities;
using DAL = DAL_Project_Cinema.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL_Project_Cinema.Mappers;

namespace BLL_Project_Cinema.Services
{
    public class CinemaPlaceService
    {
        private readonly DAL.CinemaPlaceService _repository;

        public CinemaPlaceService() 
        {
            _repository = new DAL.CinemaPlaceService();
        }


        public IEnumerable<CinemaPlace> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public CinemaPlace Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(CinemaPlace data)
        {
            return _repository.Insert(data.ToDAL());
        }

        public void Update (CinemaPlace data)
        {
            _repository.Update(data.ToDAL());
        }

        public void Delete (int id) 
        {
            _repository.Delete(id);
        }
    }
}

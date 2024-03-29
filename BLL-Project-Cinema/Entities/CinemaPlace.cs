﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Project_Cinema.Entities
{
    public class CinemaPlace
    {

        public int Id_CinemaPlace { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public CinemaPlace(int id, string name, string city, string street, string number)
        {
            Id_CinemaPlace = id;
            Name = name;
            City = city;
            Street = street;
            Number = number;
        }
    }

}

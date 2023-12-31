﻿using Microsoft.EntityFrameworkCore;
using Property.Domain.Models.PropertyDtos;

namespace Property.Domain.Models.UserDtos
{
    public class UserWtihPropertiesDto
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }
        public ICollection<PropertyDto> Properties { get; set; } = new List<PropertyDto>();

        //public ICollection<RoomReservation> RoomReservations { get; set; } = new List<RoomReservation>();

    }
}

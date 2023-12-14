﻿using System.ComponentModel.DataAnnotations;

namespace Property.API.Models.RoomDtos
{
    public class RoomForCreationDto
    {
        [Required]
        public int NumberOfBeds { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public bool hasBathroom { get; set; }
    }
}

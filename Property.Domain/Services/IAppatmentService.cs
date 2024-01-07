
using Property.Domain.Models.AppatmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Services
{
    public  interface IAppatmentService
    {
        Task<AppartmentDto> CreateAppartment(AppartmentForCreationDto appartmentForCreationDto);
        Task<AppartmentDto?> DeleteAppartment(int id);
        Task<AppartmentDto?> GetAppartmentById(int id);
        Task<AppartmentDto?> UpdateAppartment(int id,  AppartmentForUpdateDto appartmentForUpdateDto);
    }
}

﻿using Property.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task<PropertyEntity?> AddPropertyEntity(PropertyEntity propertyEntity);

    }
}

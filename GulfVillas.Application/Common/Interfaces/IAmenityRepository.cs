﻿using GulfVillas.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfVillas.Application.Common.Interfaces
{
    public interface IAmenityRepository:IRepository<Amenity>
    {


        void Update(Amenity entity);

    }
}

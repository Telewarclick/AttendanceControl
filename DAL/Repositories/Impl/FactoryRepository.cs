﻿using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl
{
    public class FactoryRepository : BaseRepository<Factory>, IFactoryRepository
    {
        public FactoryRepository(DbContext context) : base(context)
        {

        }
    }

}

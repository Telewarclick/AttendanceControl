using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl
{
    public class ActualTimeRepository : BaseRepository<ActualTime>, IActualTimeRepository
    {
        public ActualTimeRepository(DbContext context) : base(context)
        {

        }
    }

}

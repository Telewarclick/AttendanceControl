using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl
{
    public class EntTaskRepository : BaseRepository<EntTask>, IEntTaskRepository
    {
        public EntTaskRepository(DbContext context) : base(context)
        {

        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using XinRevolution.Entity.Context;

namespace XinRevolution.Repository.Repository
{
    public abstract class BaseRepository
    {
        protected readonly XinRevolutionDbContext _context;

        protected BaseRepository(XinRevolutionDbContext context)
        {
            _context = context;
        }
    }
}

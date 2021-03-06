﻿using ApplicationCore;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class BoardRepository : EFRepository<Board>
    {
        public BoardRepository(MWDBContext context) : base(context)
        {
        }
    }
}

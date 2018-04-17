﻿using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    interface ISectionListRepository : IRepository<SectionList>
    {
        IList<SectionList> GetAllIncludeReferences();
        IList<SectionList> GetAllIncludeReferences(int pageNumber, int pageSize);
        SectionList GetByIDIncludeReferences(int id);
    }
}
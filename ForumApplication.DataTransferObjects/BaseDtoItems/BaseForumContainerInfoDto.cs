﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.BaseDtoItems
{
    public class BaseForumContainerInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<NestedContainerElementsInfoDto> NestedItemListInfo { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}

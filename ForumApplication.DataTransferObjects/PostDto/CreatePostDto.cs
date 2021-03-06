﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.PostDto
{
    public class CreatePostDto
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string UserId { get; set; }
        public string MessageStringContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}

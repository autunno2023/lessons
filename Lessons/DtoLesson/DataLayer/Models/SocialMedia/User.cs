﻿using System.Collections.Generic;

namespace DataLayer.Models.SocialMedia
{
    internal class User
    {
        public string UserId { get; set; }
        public List<Post> Posts { get; set; }

    }
}
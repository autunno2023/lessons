using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Dto
{
    internal class SocialMediaDtoFree
    {

        public string User { get; set; }
        public int Posts { get; set; }


        public SocialMediaDtoFree(User user)
        {
            User = user.UserId;
            Posts = user.Posts.Count;

        }
    }
    internal class SocialMediaDtoPay
    {

        public string User { get; set; }
        public List<Post> Posts { get; set; }


        public SocialMediaDtoPay(User user)
        {
            User = user.UserId;
            Posts = user.Posts;

        }
    }
}

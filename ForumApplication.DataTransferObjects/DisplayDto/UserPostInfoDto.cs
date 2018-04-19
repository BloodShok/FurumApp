using System;

namespace ForumApplication.DataTransferObjects
{
    public class UserPostInfoDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string AttachedPicture { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriProject
{
    internal class Post
    {
        // Fields
        private string postId;
        private string postText;
        private byte[] picture;
        private byte[] video;
        private DateTime dateTime;

        // Constructor
        public Post(string postId, string postText, byte[] picture, byte[] video, DateTime dateTime)
        {
            this.PostId = postId;
            this.PostText = postText;
            this.Picture = picture;
            this.Video = video;
            this.DateTime = dateTime;
        }

        // Properties
        public string PostId
        {
            get { return postId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("PostId cannot be null or empty.");
                postId = value;
            }
        }

        public string PostText
        {
            get { return postText; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("PostText cannot be null or empty.");
                postText = value;
            }
        }

        public byte[] Picture
        {
            get { return picture; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("Picture cannot be null or empty.");
                picture = value;
            }
        }

        public byte[] Video
        {
            get { return video; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("Video cannot be null or empty.");
                video = value;
            }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (value == default)
                    throw new ArgumentException("DateTime must be a valid date and time.");
                dateTime = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stream.Models
{
    public class StreamEnums
    {
        public enum FileTypes {
            Text,
            Image,
            Video
        }

        public static explicit operator StreamEnums(int v)
        {
            throw new NotImplementedException();
        }
    }
}
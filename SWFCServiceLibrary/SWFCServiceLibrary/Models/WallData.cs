using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SWFCServiceLibrary
{
    [DataContract]
    public class WallData
    {
        [Key]
        [DataMember]
        public int MessageId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public DateTime MessagePosted { get; set; }

        [DataMember]
        public string MessageContent { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace SWFCServiceLibrary.Models
{
    [DataContract]
    public class Chat
    {
        [Key]
        [DataMember]
        public int MessageId { get; set; }

        [DataMember]        
        public string Name { get; set; }

        [DataMember]
        public string SendTo { get; set; }

        [DataMember]
        public string MessagePosted { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}

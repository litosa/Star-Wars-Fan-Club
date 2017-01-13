using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SWFCServiceLibrary
{
    [DataContract]
    public class Product
    {
        [Key]
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double Price { get; set; }
        
    }
}

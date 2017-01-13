using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace SWFCServiceLibrary
{
    //No DataMember cause otherwise problem with Serialization

    [DataContract]
    public class OrderProduct
    {
        [Key]
        [DataMember]
        public int OrderProductId { get; set; }

        [DataMember]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [DataMember]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [DataMember]
        public double Price { get; set; }

        //[DataMember]
        //public double TotalPrice { get; set; }
    }
}

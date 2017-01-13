using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace SWFCServiceLibrary
{
    [DataContract]
    public class Order
    {
        [Key]
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public double TotalPrice { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }


        [DataMember]
        public IList<OrderProduct> OrderProduct { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Server.Models
{
    public class Requestline
    {
        public int Id { get; set; }


        public int Quantity { get; set; }


        public int RequestId { get; set; }


        public int ProductsId { get; set; }

        public Requestline()
        {

        }
    }

}

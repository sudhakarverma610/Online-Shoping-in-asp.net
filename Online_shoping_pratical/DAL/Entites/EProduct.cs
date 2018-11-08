using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entites
{
    public class EProduct
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public float ProdPrice { get; set; }
        public string ProdDecription { get; set; }
        public string ProdImagePath { get; set; }
        public int CategoryId { get; set; }
    }
}

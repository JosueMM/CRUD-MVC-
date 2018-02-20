using System;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Models
{
    public class CarModel
    {
        public int id { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int cylinders { get; set; }
        public virtual MakeModel Make { get; set; }
        public int  MakeId { get; set; }

      
    }
   
}
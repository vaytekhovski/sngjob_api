using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SNGJOB.Models.UserModels;

namespace SNGJOB.Models.ItemModels
{
    public class Item
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}

using SNGJOB.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNGJOB.Models.TaskModels
{
    public class Task
    {
        public int Id { get; set; }
        public User TaskOwner { get; set; }
        public string Name { get; set; }
    }
}

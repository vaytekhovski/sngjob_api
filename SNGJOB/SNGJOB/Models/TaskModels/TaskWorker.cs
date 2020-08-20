using SNGJOB.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNGJOB.Models.TaskModels
{
    public class TaskWorker
    {
        public int Id { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

using System.Collections.Generic;

namespace TOFELTimer
{
    class TaskManager
    {
        public IEnumerable<Task> GetTasks()
        {
            var tasks = new[]
                               {
                                   new Task {Name = "1 and 2", PreparedSeconds = 15, ResponseSeconds = 45},
                                   new Task {Name = "3 and 4", PreparedSeconds = 30, ResponseSeconds = 60},
                                   new Task {Name = "5 and 6", PreparedSeconds = 20, ResponseSeconds = 60}
                               };
            return tasks;
        }
    }
}

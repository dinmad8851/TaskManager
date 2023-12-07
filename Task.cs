using System;
using System.Data.SQLite;

public class Task
{
    public int TaskID { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDescription { get; set; }
    public string DueDate { get; set; }
    public string PriorityLevel { get; set; }

    public Task(int taskID, string taskTitle, string taskDescription, string dueDate, string priorityLevel)
    {
        TaskID = taskID;
        TaskTitle = taskTitle;
        TaskDescription = taskDescription;
        DueDate = dueDate;
        PriorityLevel = priorityLevel;
    }

    public Task(string taskTitle, string taskDescription, string dueDate, string priorityLevel)
    {
        TaskTitle = taskTitle;
        TaskDescription = taskDescription;
        DueDate = dueDate;
        PriorityLevel = priorityLevel;
    }
}

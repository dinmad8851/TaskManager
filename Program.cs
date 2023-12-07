using System;
using System.Data.SQLite;
using System.Collections.Generic;

public class TaskManager
{
    public static void Main(string[] args)
    {
        const string dbName = "Dinesh.db";
        Console.WriteLine("\nDinesh Maddirala, CIS317 Project - Task Manager\n");

        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

        if (conn != null)
        {
            TaskDB.CreateTable(conn);

            // Create
            TaskDB.AddTask(conn, new Task("Complete Assignment", "All the assignments in CIS317 Subject", "08-Dec-2023", "High"));
            TaskDB.AddTask(conn, new Task("Complete Project", "Project implementation in CIS317 Subject", "08-Dec-2023", "High"));
            TaskDB.AddTask(conn, new Task("Complete Guided Practice", "Guided Practices in CIS317 Subject", "08-Dec-2023", "Medium"));
            TaskDB.AddTask(conn, new Task("Complete Survey", "End of Term Survey for CIS317 Subject", "08-Dec-2023", "Medium"));

            // Read
            Console.WriteLine("\nAll Tasks in the Task Manager Database");
            PrintTasks(TaskDB.GetAllTasks(conn));

            Console.WriteLine("\nGet a Task Using an Invalid Task ID");
            PrintTask(TaskDB.GetTask(conn, -1));

            // Update
            Task taskToUpdate = new Task(3, "Complete Guided Practice", "Week 5 Guided Practices in CIS317 Subject", "08-Dec-2023", "Medium");
            TaskDB.UpdateTask(conn, taskToUpdate);
            Task updatedTask = TaskDB.GetTask(conn, taskToUpdate.TaskID);
            Console.WriteLine("\nUpdated Task");
            PrintTask(updatedTask);

            // Delete
            TaskDB.DeleteTask(conn, taskToUpdate.TaskID);
            Console.WriteLine("\nAll the Other Remaining Tasks in the Database");
            PrintTasks(TaskDB.GetAllTasks(conn));
        }
    }

    private static void PrintTasks(List<Task> tasks)
    {
        foreach (Task t in tasks)
        {
            PrintTask(t);
        }
    }

    private static void PrintTask(Task t)
    {
        Console.WriteLine($"Task ID: {t.TaskID}");
        Console.WriteLine($"Task Title: {t.TaskTitle}");
        Console.WriteLine($"Task Description: {t.TaskDescription}");
        Console.WriteLine($"Due Date: {t.DueDate}");
        Console.WriteLine($"Priority Level: {t.PriorityLevel}\n");
    }
}


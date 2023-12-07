using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class TaskDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        string sql =
            "CREATE TABLE IF NOT EXISTS Tasks (\n" +
            " TaskID INTEGER PRIMARY KEY AUTOINCREMENT,\n" +
            " TaskTitle VARCHAR(255),\n" +
            " TaskDescription TEXT,\n" +
            " DueDate DATE,\n" +
            " PriorityLevel VARCHAR(10)\n" +
            ");";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddTask(SQLiteConnection conn, Task task)
    {
        string sql = string.Format(
            "INSERT INTO Tasks(TaskTitle, TaskDescription, DueDate, PriorityLevel) " +
            "VALUES('{0}', '{1}', '{2}', '{3}')",
            task.TaskTitle, task.TaskDescription, task.DueDate, task.PriorityLevel);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static Task GetTask(SQLiteConnection conn, int taskID)
    {
        string sql = $"SELECT * FROM Tasks WHERE TaskID = {taskID}";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            return new Task(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetString(3),
                rdr.GetString(4)
            );
        }
        else
        {
            return new Task(-1, string.Empty, string.Empty, string.Empty, string.Empty);; // Handling invalid Task ID appropriately
        }
    }

    public static List<Task> GetAllTasks(SQLiteConnection conn)
    {
        List<Task> tasks = new List<Task>();
        string sql = "SELECT * FROM Tasks";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            tasks.Add(new Task(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetString(3),
                rdr.GetString(4)
            ));
        }
        return tasks;
    }

    public static void UpdateTask(SQLiteConnection conn, Task task)
    {
        string sql = string.Format(
            "UPDATE Tasks SET TaskTitle='{0}', TaskDescription='{1}', DueDate='{2}', PriorityLevel='{3}'" +
            " WHERE TaskID={4}",
            task.TaskTitle, task.TaskDescription, task.DueDate, task.PriorityLevel, task.TaskID);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void DeleteTask(SQLiteConnection conn, int taskID)
    {
        string sql = string.Format("DELETE FROM Tasks WHERE TaskID={0}", taskID);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}
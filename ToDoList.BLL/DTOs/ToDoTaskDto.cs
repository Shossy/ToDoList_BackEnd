using ToDoList.DAL.Enums;

namespace ToDoList.BLL.DTOs;

public class ToDoTaskDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string? Description { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime DueDateTime { get; set; }

    public Priority Priority { get; set; }

    public Status Status { get; set; }
}
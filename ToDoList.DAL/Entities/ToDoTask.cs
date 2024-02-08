using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.DAL.Enums;

namespace ToDoList.DAL.Entities;

public class ToDoTask
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    
    [MaxLength(length: 50)] 
    public string Title { get; set; }
    
    [MaxLength(length: 255)] 
    public string? Description { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime DueDateTime { get; set; }

    public Priority Priority { get; set; }

    public Status Status { get; set; }

}
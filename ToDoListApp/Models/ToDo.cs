using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string MyWish { get; set; }
    }
}

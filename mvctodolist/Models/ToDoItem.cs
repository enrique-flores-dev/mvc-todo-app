using System.ComponentModel.DataAnnotations;

namespace mvctodolist.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; } = "";

        public bool IsComplete { get; set; }

        public string UserId { get; set; } = "";
    }
}


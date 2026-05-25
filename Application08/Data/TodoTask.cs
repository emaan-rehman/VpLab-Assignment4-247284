using System;
using System.ComponentModel.DataAnnotations;

namespace VpLabAssignment.Data
{
    public class TodoTask
    {
        [Key] // Configures auto-incrementing Primary Key
        public int Id { get; set; }

        [Required(ErrorMessage = "Task parameters cannot be blank.")]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
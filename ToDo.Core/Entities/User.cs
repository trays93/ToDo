using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoCore.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<ToDo> ToDos { get; set; }
            = new List<ToDo>();
    }
}

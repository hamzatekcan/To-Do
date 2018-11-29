using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HuaweiProject.Models
{
    public class ToDoList
    {
        
        public Guid ID { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public string Description { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public string Name { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public DateTime Deadline { get; set; }
        public bool Status { get; set; }
        public string UserID { get; set; }

    }
}
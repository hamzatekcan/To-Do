using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HuaweiProject.Models
{
    public class ToDo
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public string Message { get; set; }
        public bool Status { get; set; }
        public string ToDoListID { get; set; }

    }
}
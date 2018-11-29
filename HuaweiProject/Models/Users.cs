using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HuaweiProject.Models
{
    public class Users
    {
     
        public Guid ID { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public string Name { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public string Surname { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public string UserName { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public string Password { get; set; }
        [Required(ErrorMessage = ("Boş Bırakılamaz"))]
        public string ConfirmPassword { get; set; }

        public List<ToDoList> toDoLists { get; set; }

    }
}
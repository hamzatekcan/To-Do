using HuaweiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuaweiProject.Controllers
{
    public class HomeController : Controller
    {
        static List<ToDo> toDos = new List<ToDo>();
        static bool defaultHome = false;
        static List<ToDoList> toDoLists = new List<ToDoList>();
        // GET: Home
        public ActionResult Index()
        {
            if (defaultHome==false)
            {
                toDoLists.Add(new ToDoList { Name = "This area is for To-Do List name.", Description = "This area is for To-Do List description.", Deadline = DateTime.Now, Status = true, UserID = "4323asf" });
                defaultHome = true;
            }
            //toDoLists.Add(new ToDoList { Name = "This area is for naming.", Description = "This area is for naming.", Deadline = DateTime.Now, Status = true, UserID = "4323asf" });
          
            if (Session["ID"] == null)
            {
                return View(toDoLists);
            }
            else
            {
                int totalToDo=0;
                int statusToDo = 0;
                for (int i = 0; i < toDoLists.Count; i++)
                {
                    bool nullcontroller = false;
                    for (int k = 0; k < toDos.Count; k++)
                    {
                        if (toDoLists[i].ID.ToString() == toDos[k].ToDoListID.ToString())
                        {
                            nullcontroller = true;
                            if (toDos[k].Status==true)
                            {
                                statusToDo++;
                                totalToDo++;

                            }
                            else
                            {
                                totalToDo++;
                            }
                                                        
                        }
                       
                    }
                    if (totalToDo == statusToDo)
                    {
                        if (nullcontroller == true)
                        {
                            toDoLists[i].Status = true;
                        }
                       
                    }
                    else
                    {
                        toDoLists[i].Status = false;
                    }
                }
                return View(toDoLists.Where(c => c.UserID == Session["ID"].ToString()));
            }
        }


        //ToDo Lists
        public ActionResult AddToDoList()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddToDoList(ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                ToDoList toDo = new ToDoList();
                toDo.ID = Guid.NewGuid();
                toDo.Description = toDoList.Description;
                toDo.Name = toDoList.Name;
                toDo.Deadline = toDoList.Deadline;
                toDo.Status = false;
                toDo.UserID = Session["ID"].ToString();
                toDoLists.Add(toDo);
                return RedirectToAction("Index");
            }
            else
            {
                return View(toDoList);
            }
        }


        public ActionResult Edit(Guid id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var result = toDoLists.Find(w => w.ID == id);

                return View(result);
            }
        }
        [HttpPost]
        public ActionResult Edit(ToDoList toDoList)
        {

            if (ModelState.IsValid)
            {
                var result = toDoLists.Find(w => w.ID == toDoList.ID);
                result.Description = toDoList.Description;
                result.Name = toDoList.Name;
                result.Deadline = toDoList.Deadline;
                result.Status = toDoList.Status;
                result.UserID = Session["ID"].ToString();
                return RedirectToAction("Index");
            }
            else
            {
                return View(toDoList);
            }

        }



        public ActionResult Preview(Guid id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var result = toDoLists.Find(w => w.ID == id);

                return View(result);
            }
        }

        public ActionResult Delete(Guid id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var result = toDoLists.Find(w => w.ID == id);
                toDoLists.Remove(result);
                return RedirectToAction("Index");
            }
        }











        //Todo
        public ActionResult AddToDo(Guid id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult AddToDo(Guid id, ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                ToDo to = new ToDo();
                to.ID = Guid.NewGuid();
                to.Message = toDo.Message;
                to.Status = false;
                to.ToDoListID = id.ToString();
                toDos.Add(to);
                return RedirectToAction("Index");
            }
            else
            {
                return View(toDo);
            }
        }


        public ActionResult TodoList(Guid id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                // toDoLists.Where(c => c.UserID == Session["ID"].ToString())
                return View(toDos.Where(c => c.ToDoListID == id.ToString()));
            }
        }

        public ActionResult ToDoDelete(Guid id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var result = toDos.Find(w => w.ID == id);
                toDos.Remove(result);
                return RedirectToAction("Index");
            }
        }


        public ActionResult ToDoEdit(Guid id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var result = toDos.Find(w => w.ID == id);

                return View(result);
            }
        }


        [HttpPost]
        public ActionResult ToDoEdit(ToDo toDo)
        {

            if (ModelState.IsValid)
            {
                var result = toDos.Find(w => w.ID == toDo.ID);
          
                result.Message = toDo.Message;
               
                result.Status = toDo.Status;

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }



    }
}
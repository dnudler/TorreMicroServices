using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Torre.Web.Api;
using Torre.Web.Models;
using Torre.Web.ViewModels;
using Task = Torre.Web.Models.Task;

namespace Torre.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApiManager _api;

        public TasksController(ApiManager api)
        {
            _api = api;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Description, State, UserId")] Task task)
        {
            if (ModelState.IsValid)
            {
                _api.AddTask(task.UserId, task.Description, task.State);
                return RedirectToAction("Index", "Tasks", new { userId = task.UserId });
            }

            return View(task);
        }

        public IActionResult Create(int userId)
        {
            Task t = new Task(userId);
            t.UserId = userId;
            return View(t);
        }

        public IActionResult Edit(int userId, int id)
        {
            Task t = _api.GetTaskById(userId, id);
            return View(t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Description, State, UserId")] Task task)
        {
            if (ModelState.IsValid)
            {
                _api.UpdateTask(task.UserId, task);
                return RedirectToAction("Index", "Tasks", new {userId = task.UserId});
            }

            return View(task);
        }

        public IActionResult Delete(int userId, int id)
        {

            var task = _api.GetTaskById(userId, id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int userId, int id)
        {
            if (_api.DeleteTask(userId, id))
            {
                return RedirectToAction("Index", "Tasks", new { userId = userId });
            }

            Task t = _api.GetTaskById(userId, id);
            ModelState.AddModelError(string.Empty, "Task couldn't be deleted");
            return View(t);
        }
        public IActionResult Index(int userId)
        {
            var tasks = _api.GetTasks(userId); 
            TasksViewModel vm = new TasksViewModel(userId);
            vm.User = _api.GetUserById(userId);
            vm.Tasks = _api.GetTasks(userId);
            return View(vm);
        }
    }
}
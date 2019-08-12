using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Torre.Web.Api;
using Torre.Web.Models;

namespace Torre.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApiManager _api;

        public UsersController(ApiManager api)
        {
            _api = api;
        }

        
        public IActionResult Index()
        {
            var users = _api.GetUsers();
            return View(users);
        }

        

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                _api.AddUser(user.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _api.GetUserById(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _api.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _api.GetUserById(id.Value);

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_api.DeleteUser(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                User u = _api.GetUserById(id);
                ModelState.AddModelError(string.Empty, "User couldn't be deleted");
                return View(u);
            }
        }

    }
}

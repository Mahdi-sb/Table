using Create_Table.Repository.CreateTable;
using Create_Table.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers
{
    public class AddTableController : Controller
    {

        private readonly ICreate _create;
        public AddTableController(ICreate create)
        {
            _create = create;
        }
        /// <summary>
        /// Add Table Name , type of fields and Name of Fields in Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddNewTable()
        {
            TableView employeeViewModel = new TableView();
            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult AddNewTable(TableView model)
        {
            if (ModelState.IsValid)
            {

               string error= _create.AddInformationTodatabase(model);
                if(error!=null)
                {
                    ViewData["ErrorMessage"] =error;
                    return View("AddNewTable", model);
                }
                return RedirectToAction("Index", "Home");
            }
            return View("AddNewTable",model);
        }
    }
}

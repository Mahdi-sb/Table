using System.Linq;
using Create_Table.Models.DBcontext;
using Create_Table.Service.Add_Table;
using Create_Table.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers
{
    public class AddTableController : Controller
    {
        private readonly AppDBcontext _dBcontext;
        private readonly Service.Service _Service=new Service.Service();
        private readonly Check _Check =new Check();
        public AddTableController(AppDBcontext dBcontext )
        {
            _dBcontext = dBcontext;
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
                
                if (_Check.CheckInput(_dBcontext, model) != null)
                {
                    ViewData["ErrorMessage"] = _Check.CheckInput(_dBcontext, model);
                    return View("AddNewTable", model);
                }
                _Service.AddTo_Tables(_dBcontext,model);
                var id = _dBcontext.Tables.Where(x => x.TableName == model.TableName).ToList()[0].Id;////get table id 
                _Service.AddTo_Type(_dBcontext, model,id);
                _Service.AddTo_Time(_dBcontext, id);
                return RedirectToAction("Index", "Home");
            }
            return View("AddNewTable",model);
        }





    }
}

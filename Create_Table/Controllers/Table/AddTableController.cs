using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Create_Table.Models.DBcontext;
using Create_Table.Repository;
using Create_Table.Service;
using Create_Table.Service.Add_Table;
using Create_Table.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers
{
    public class AddTableController : Controller
    {
        private readonly AppDBcontext _dBcontext;
         Service.Service Service=new Service.Service();
        Check Check=new Check();
        public AddTableController(AppDBcontext dBcontext )
        {
            _dBcontext = dBcontext;
        }

       

        /// <summary>
        /// Add Table Name , type of fields and Name of Fields in Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add_NewTable()
        {
            TableView employeeViewModel = new TableView();
            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult Add_NewTable(TableView model)
        {
            if (ModelState.IsValid)
            {
                var checkInput= Check.Check_Input(_dBcontext, model);
                if (checkInput != null)
                {
                    ViewData["ErrorMessage"] = checkInput;
                    return View("Add_NewTable", model);
                }
                Service.AddTo_Tables(_dBcontext,model);
                var id = _dBcontext.Tables.Where(x => x.TableName == model.TableName).ToList()[0].Id;////get table id 
                Service.AddTo_Type(_dBcontext, model,id);
                Service.AddTo_Time(_dBcontext, id);
                return RedirectToAction("Index", "Home");
            }
            return View("Add_NewTable",model);
        }





    }
}

using Create_Table.Service;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers.Table
{


    public class ShowController : Controller
    {
        private readonly Ishow _show;
        public ShowController(Ishow show)
        {
            _show = show;
        }

        /// <summary>
        /// show data of table 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ShowData(int id)
        {
            ViewData["column"] = _show.AllType(id);
            return View(_show.ValueOfTable(id));
        }
    }
}

using Create_Table.Repository.ShowData;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers.Table
{


    public class ShowController : Controller
    {
        private readonly IShow _show;
        public ShowController(IShow show)
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

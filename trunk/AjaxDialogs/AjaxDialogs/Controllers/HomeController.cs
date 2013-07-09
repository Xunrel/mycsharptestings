using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxDialogs.Models;

namespace AjaxDialogs.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 5;

        private readonly IEnumerable<string> _valuesRepository = new List<string>
                                                                     {
                                                                         "value 01",
                                                                         "value 02",
                                                                         "value 03",
                                                                         "value 04",
                                                                         "value 05",
                                                                         "value 06",
                                                                         "value 07",
                                                                         "value 08",
                                                                         "value 09",
                                                                         "value 10",
                                                                         "value 11",
                                                                         "value 12",
                                                                         "value 13",
                                                                         "value 14",
                                                                         "value 15",
                                                                         "value 16",
                                                                         "value 17",
                                                                         "value 02",
                                                                         "value 03",
                                                                         "value 04",
                                                                         "value 05",
                                                                         "value 06",
                                                                         "value 07",
                                                                         "value 08",
                                                                         "value 09",
                                                                         "value 10",
                                                                         "value 11",
                                                                         "value 12",
                                                                         "value 13",
                                                                         "value 14",
                                                                         "value 15",
                                                                         "value 16",
                                                                         "value 17",
                                                                         "value 02",
                                                                         "value 03",
                                                                         "value 04",
                                                                         "value 05",
                                                                         "value 06",
                                                                         "value 07",
                                                                         "value 08",
                                                                         "value 09",
                                                                         "value 10",
                                                                         "value 11",
                                                                         "value 12",
                                                                         "value 13",
                                                                         "value 14",
                                                                         "value 15",
                                                                         "value 16",
                                                                         "value 17",
                                                                         "value 02",
                                                                         "value 03",
                                                                         "value 04",
                                                                         "value 05",
                                                                         "value 06",
                                                                         "value 07",
                                                                         "value 08",
                                                                         "value 09",
                                                                         "value 10",
                                                                         "value 11",
                                                                         "value 12",
                                                                         "value 13",
                                                                         "value 14",
                                                                         "value 15",
                                                                         "value 16",
                                                                         "value 17"
                                                                     };

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetValues()
        {
            return PartialView("_MyStringValues", _valuesRepository.ToList());
        }

        public PartialViewResult GetValue(int id = 0)
        {
            var model = _valuesRepository.Where(v => v.Contains(id.ToString(CultureInfo.InvariantCulture)));
            return PartialView("_MyStringValues", model);
        }

        public ActionResult List(int page = 1)
        {
            var model = new ValueListViewModel
                            {
                                Values = _valuesRepository
                                            .OrderBy(v => v)
                                            .Skip((page - 1) * PageSize)
                                            .Take(PageSize),
                                PagingInfo = new PagingInfo
                                                 {
                                                     CurrentPage = page,
                                                     ItemsPerPage = PageSize,
                                                     TotalItems = _valuesRepository.Count()
                                                 }
                            };

            return View(model);
        }

        public ActionResult AjaxList(int page = 1)
        {
            return PartialView("_ValueList", _valuesRepository
                                                 .OrderBy(v => v)
                                                 .Skip((page - 1)*PageSize)
                                                 .Take(PageSize));
        }
    }
}

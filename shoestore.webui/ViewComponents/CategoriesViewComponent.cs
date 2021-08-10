using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace shoestore.webui.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke() // default.cshtml'i getirir
        {

            //return View(CategoryRepository.Categories);
            return View();
            
        }
    }
}
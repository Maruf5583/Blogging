using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blooging.Models.ViewModels
{
    public class PostviewModel
    {
        public Post post { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } 
            
          public IFormFile FeaturesImage { get; set; }  
    }
}

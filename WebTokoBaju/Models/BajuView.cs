using Microsoft.AspNetCore.Mvc.Rendering;
using WebTokoBaju.Data;

namespace WebTokoBaju.Models
{
    public class BajuView
    {
        public Baju Baju { get; set; }
        public int IdJenisBaju { get; set; }
        public int IdMerk { get; set; }

        
    }
}

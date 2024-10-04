using Shop.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.HomePage
{
    public class Slider:BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text { get; set; }
        public bool Display { get; set; } 
        public int ClickCount { get; set; }
    }
}

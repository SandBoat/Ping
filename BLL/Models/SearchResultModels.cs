using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SearchResultModels
    {
        public string StartAdress { get; set; }
        public double StartPoint_x { get; set; }
        public double StartPoint_y { get; set; }
        public string EndAdress { get; set; }
        public double EndPoint_x { get; set; }
        public double EndPoint_y { get; set; }
        public double Distance { get; set; }
    }
}

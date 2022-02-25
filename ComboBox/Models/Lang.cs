using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBox
{
    public class Lang
    {
        public string Name { get; set; }
        public string DataName { get; set; }
        public Lang(string Name, string DataName)
        {
            this.Name = Name;
            this.DataName = DataName;
        }
    }
}

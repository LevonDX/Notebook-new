using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Shared.Models
{
    public class Record
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string? Phone { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Phone: {Phone}";
        }
    }
}

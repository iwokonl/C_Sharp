using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;

namespace Zadanko_Ewelina
{
    public class Model
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public static string FirstName2 = "";
        public static string LastName2 = "";
        public static string? IdLocal = "-1";
        public static BindingList<Model> Users = new BindingList<Model>();
        public static List<Model> Div = new List<Model>();
    }
}

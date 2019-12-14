using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class ViewAllDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class ViewDatabaseList
    {
        public List<ViewAllDatabase> DatabaseList { get; set; }
    }
}
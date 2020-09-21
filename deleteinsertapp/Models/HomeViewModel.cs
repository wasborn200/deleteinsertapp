using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deleteinsertapp.Models
{
    public class HomeViewModel
    {
        public int AccountId { get; set; }
        public string License { get; set; }
        public string MM { get; set; }
        public int Count { get; set; }
        public string LIC1 { get; set; }
        public string MM1 { get; set; }
        public string LIC2 { get; set; }
        public string MM2 { get; set; }
        public string LIC3 { get; set; }
        public string MM3 { get; set; }
        public string LIC4 { get; set; }
        public string MM4 { get; set; }

        public List<HomeViewModel> AutocompleteList { get; set; }

        public string Code { get; set; }
        public string LicenseName { get; set; }
    }
}
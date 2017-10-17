using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stream.Models
{
    public class LanguageViewModel
    {
        
            public int Id { get; set; }
            public string Language { get; set; }
            public string WelcomeMessage { get; set; }
            public string Video { get; set; }
            public string Audio { get; set; }
            public string Images { get; set; }
    }
}
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreApp.Data.DatabaseModel
{
    public partial class SlideImages
    {
        public int SlideId { get; set; }
        public string SlideTitle { get; set; }
        public string SlideDescription { get; set; }
        public string SlideImage { get; set; }
    }
}

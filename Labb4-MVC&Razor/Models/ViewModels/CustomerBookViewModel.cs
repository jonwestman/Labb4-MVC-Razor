using System.ComponentModel;

namespace Labb4_MVC_Razor.Models.ViewModels
{
    public class CustomerBookViewModel
    {
        [DisplayName("Name")]
        public string Fullname { get; set; }
        [DisplayName("Title")]
        public string BookTitle { get; set; }
    }
}

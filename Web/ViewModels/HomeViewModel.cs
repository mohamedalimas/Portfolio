using Core.Models;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public Owner? Owner { get; set; }
        public IList<PortItem>? PortItems { get; set; }
    }
}

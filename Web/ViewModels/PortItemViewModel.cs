namespace Web.ViewModels
{
    public class PortItemViewModel
    {
        public Guid PortId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? ImgUrl { get; set; }
        public IFormFile? file { get; set; }
    }
}

using Microsoft.AspNetCore.Http;

namespace SenaiRH_G1.ViewModel
{
    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}

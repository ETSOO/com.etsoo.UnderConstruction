using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.etsoo.UnderConstruction.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            ViewData["ClientName"] = _configuration["AppSettings:ClientName"];
        }
    }
}
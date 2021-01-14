using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veilig.Services;

namespace Veilig.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IVeiligRepository _veiligRepository;

        public bool IsFirstLoad { get; set; } = true;
        public bool IsDecrypt { get; set; }
        public string TitleText { get; set; } = "Veilig - Encrypted Pastes";

        [BindProperty]
        public string PlainText { get; set; }
        
        [BindProperty]
        public string Key { get; set; }
        public IndexModel(IVeiligRepository veiligRepository)
        {
            _veiligRepository = veiligRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var hostDomain = HttpContext.Request.Host;
            var slug = RouteData.Values["slug"];

            if (slug == null )
            {
                return Page();
            }

            if (!await _veiligRepository.PasteExistsAsync(slug.ToString()))
            {
                return Redirect($"http://{hostDomain}");
            }

            IsDecrypt = true;

            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var userGivenSlug = RouteData.Values["slug"];
            
            if (userGivenSlug != null)
            {
                var decryptResult = await _veiligRepository.GetBySlugAsync(userGivenSlug.ToString(), Key);

                if (decryptResult.Key)
                {
                    return new ContentResult
                    {
                        Content = decryptResult.Value,
                        ContentType = "text/plain",
                        StatusCode = 200
                    };
                }

                ModelState.Clear();
                Key = string.Empty;
                IsDecrypt = true;
                
                return Page();
            }

            var hostDomain = HttpContext.Request.Host;
            var slug = await _veiligRepository.CreatePasteAsync(PlainText, Key);

            ModelState.Clear();

            TitleText = $"https://{hostDomain}/{slug}";
            IsFirstLoad = false;
            
            return Page();
        }
    }
}
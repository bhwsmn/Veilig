using System.Collections.Generic;
using System.Threading.Tasks;

namespace Veilig.Services
{
    public interface IVeiligRepository
    {
        Task<string> CreatePasteAsync(string text, string key);
        Task<bool> PasteExistsAsync(string slug);
        Task<KeyValuePair<bool, string>> GetBySlugAsync(string slug, string key);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veilig.DbContexts;
using Veilig.Entities;
using Veilig.Helpers;

namespace Veilig.Services
{
    public class VeiligRepository : IVeiligRepository
    {
        private readonly VeiligContext _context;
        private readonly ICipherService _cipherService;

        public VeiligRepository(VeiligContext context, ICipherService cipherService)
        {
            _context = context;
            _cipherService = cipherService;
        }
        
        public async Task<string> CreatePasteAsync(string text, string key)
        {
            var encryptedText = _cipherService.Encrypt(text, key);
            
            var slug = string.Empty;
            for (var length = 2; length < 100; length++)
            {
                slug = SlugGenerator.Generate(length);
                if (! await _context.Pastes.AnyAsync(s => s.Slug == slug))
                {
                    break;
                }
            }

            await _context.Pastes.AddAsync(new Paste
            {
                Slug = slug,
                EncryptedText = encryptedText
            });
            await _context.SaveChangesAsync();

            return slug;
        }
        
        public async Task<bool> PasteExistsAsync(string slug)
        {
            var pasteExists = await _context.Pastes.AnyAsync(p => p.Slug == slug);

            return pasteExists;
        }

        public async Task<KeyValuePair<bool, string>> GetBySlugAsync(string slug, string key)
        {
            var paste = await _context.Pastes.FirstOrDefaultAsync(p => p.Slug == slug);

            try
            {
                var decryptedText = _cipherService.Decrypt(paste.EncryptedText, key);
                
                _context.Pastes.Remove(paste);
                await _context.SaveChangesAsync();

                return new KeyValuePair<bool, string>(true, decryptedText);
            }
            catch
            {
                return new KeyValuePair<bool, string>(false, string.Empty);
            }
        }
    }
}
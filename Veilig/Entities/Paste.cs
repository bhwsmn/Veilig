using System;

namespace Veilig.Entities
{
    public class Paste
    {
        public Guid Id { get; set; }
        public string EncryptedText { get; set; }
        public string Slug { get; set; }
    }
}
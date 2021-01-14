namespace Veilig.Services
{
    public interface ICipherService
    {
        public string Encrypt(string input, string key);
        public string Decrypt(string cipherText, string key);
    }
}
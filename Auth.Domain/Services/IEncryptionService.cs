namespace Auth.Domain.Services
{
    public interface IEncryptionService
    {
        public string Encrypt(string source);
        public string Decrypt(string source);
    }
}

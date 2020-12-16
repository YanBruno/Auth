using Auth.Domain.Services;
using Auth.Domain.Shared;
using Auth.Domain.ValueObjects;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Domain.Infra.Services
{
    public class EncryptionService : IEncryptionService
    {
        private byte[] chave = { };
        private readonly byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        public string Decrypt(string source)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs;
            byte[] sai;
            des = new DESCryptoServiceProvider();
            ms = new MemoryStream();
            sai = new byte[source.Length];
            sai = Convert.FromBase64String(source.Replace(" ", "+"));
            chave = Encoding.UTF8.GetBytes(Settings.SecretToken.Substring(0, 8));
            cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
            cs.Write(sai, 0, sai.Length);
            cs.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        public string Encrypt(string source)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs;
            byte[] ent;
            des = new DESCryptoServiceProvider();
            ms = new MemoryStream();
            ent = Encoding.UTF8.GetBytes(source);
            chave = Encoding.UTF8.GetBytes(Settings.SecretToken.Substring(0, 8));
            cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
            cs.Write(ent, 0, ent.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}

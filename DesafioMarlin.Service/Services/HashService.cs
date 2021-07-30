using DesafioMarlin.Service.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace DesafioMarlin.Service.Services
{
    public class HashService : IHashService
    {

        private HashAlgorithm hash = SHA512.Create();

        public string CriptografarSenha(string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = hash.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

    }
}

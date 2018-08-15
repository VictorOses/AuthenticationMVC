using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace AutenticacaoUsuarios.Utils
{
    public class Hash
    {
        public static string GerarHash(string texto)
        {
            SHA256 sha256 = SHA256Managed.Create();
            //CONVERSÃO DO TEXTO PARA BYTES
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            //GERANDO O HASH E O ARRAY DE BYTES
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();

            //PERCORRENDO O ARRAY DE BYTES PARA GERAR A STRING, CONVERTENDO O BYTE PARA ALGRARISMO ALFANUMÉRICO
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();
        }
    }
}


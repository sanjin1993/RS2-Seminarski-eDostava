using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Util
{
   public class UIHelper
    {
        
        public static string GenerateSalt()
        {

            var buf = WinRTCrypto.CryptographicBuffer.GenerateRandom(16);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string lozinka, string salt)
        {
            byte[] byteLozinka;
            byte[] byteSalt;
            byte[] forHashing;
            try
            {
                byteLozinka = Encoding.Unicode.GetBytes(lozinka);
                byteSalt = Convert.FromBase64String(salt);
                forHashing = new byte[byteLozinka.Length + byteSalt.Length];
            }
            catch (Exception e)
            {
                return "hashinvalid";
            }
            
            System.Buffer.BlockCopy(byteLozinka, 0, forHashing, 0, byteLozinka.Length);
            System.Buffer.BlockCopy(byteSalt, 0, forHashing, byteLozinka.Length, byteSalt.Length);
            
            var alg = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);

            return Convert.ToBase64String(alg.HashData(forHashing));
        }
    }
}

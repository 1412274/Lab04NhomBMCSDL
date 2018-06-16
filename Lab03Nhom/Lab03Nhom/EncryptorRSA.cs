using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Lab03Nhom
{
    class EncryptorRSA
    {
        public static String createKeyPair(String privateKey)//return public key
        {
            CspParameters cspParams1 = new CspParameters();
            cspParams1.KeyContainerName = privateKey;
            cspParams1.Flags = CspProviderFlags.UseMachineKeyStore;
            String publicKeyWithSize = null;
            using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider(512, cspParams1))
            {
                var pubKey = provider.ToXmlString(false);

                publicKeyWithSize = IncludeKeyInEncryptionString(pubKey, 512);
            }
            return publicKeyWithSize;

        }

        private static string IncludeKeyInEncryptionString(string publicKey, int keySize)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(keySize.ToString() + "!" + publicKey));
        }

        private static void GetKeyFromEncryptionString(string rawkey, out int keySize, out string xmlKey)
        {
            keySize = 0;
            xmlKey = "";

            if (rawkey != null && rawkey.Length > 0)
            {
                byte[] keyBytes = Convert.FromBase64String(rawkey);
                var stringKey = Encoding.UTF8.GetString(keyBytes);

                if (stringKey.Contains("!"))
                {
                    var splittedValues = stringKey.Split(new char[] { '!' }, 2);

                    try
                    {
                        keySize = int.Parse(splittedValues[0]);
                        xmlKey = splittedValues[1];
                    }
                    catch (Exception e) { }
                }
            }
        }

        public static byte[] RSAencrypt(String plainTextData, String pubKey)
        {
            //for encryption, always handle bytes...
            byte[] bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);
            RSACryptoServiceProvider csp2 = new RSACryptoServiceProvider(512);
            int keySize = 0;
            string publicKeyXml = "";

            GetKeyFromEncryptionString(pubKey, out keySize, out publicKeyXml);
            csp2.FromXmlString(publicKeyXml);
            //apply pkcs#1.5 padding and encrypt our data 
            byte[] bytesCypherText = csp2.Encrypt(bytesPlainTextData, false);
            return bytesCypherText;

            //we might want a string representation of our cypher text... base64 will do
            //var cypherText = Convert.ToBase64String(bytesCypherText);

        }

        public static String RSAdecrypt(byte[] cypherTextData, String privateKey)
        {
            try
            {
                //we want to decrypt, therefore we need a csp and load our private key
                CspParameters cspParams2 = new CspParameters();
                cspParams2.KeyContainerName = privateKey;
                cspParams2.Flags = CspProviderFlags.UseMachineKeyStore;
                RSACryptoServiceProvider csp3 = new RSACryptoServiceProvider(512, cspParams2);

                byte[] bytesPlainTextData = csp3.Decrypt(cypherTextData, false);

                //get our original plainText back...
                String plainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

                return plainTextData;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

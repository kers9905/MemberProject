namespace MemberProject.Utils
{
    public class EncryptUtil
    {
        private const string defaultKey = "1234567890123456";
        private const string defaultIv = "1234567890123456";
        public static string EncryptAES(string text)
        {
            return EncryptAES(text, defaultKey, defaultIv);
        }
        public static string EncryptAES(string text,string key,string iv)
        {
            string result = "";
            if (string.IsNullOrEmpty(text))
                result = "";
            else
            {
                var sourceBytes = System.Text.Encoding.UTF8.GetBytes(text);
                var aes = System.Security.Cryptography.Aes.Create();
                aes.Mode = System.Security.Cryptography.CipherMode.CBC;
                aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
                aes.IV = System.Text.Encoding.UTF8.GetBytes(iv);
                var transform = aes.CreateEncryptor();
                result = System.Convert.ToBase64String(transform.TransformFinalBlock(sourceBytes, 0, sourceBytes.Length));
            }
            return result;
        }

        public static string DescrtptAES(string text)
        {
            return DescrtptAES(text, defaultKey, defaultIv);
        }
        public static string DescrtptAES(string text, string key, string iv)
        {
            string result = "";
            if (string.IsNullOrEmpty(text))
                result = "";
            else
            {
                var encryptedBytes = Convert.FromBase64String(text);
                var aes = System.Security.Cryptography.Aes.Create();
                aes.Mode = System.Security.Cryptography.CipherMode.CBC;
                aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
                aes.IV = System.Text.Encoding.UTF8.GetBytes(iv);
                var transform = aes.CreateDecryptor();
                var decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                result = System.Text.Encoding.UTF8.GetString(decryptedBytes);
            }
            return result;
        }
    }
}

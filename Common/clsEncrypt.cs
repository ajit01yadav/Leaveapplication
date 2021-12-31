using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsEncrypt
{
    public static string Encrypt(string inputValue)
    {
        var zBase32 = new System.Text.ZBase32Encoder();
        // Convert the passed string to a byte array.
        byte[] toEncrypt = new ASCIIEncoding().GetBytes(inputValue);
        return zBase32.Encode(toEncrypt);
    }

    public static string Decrypt(string inputValue)
    {
        var zBase32 = new System.Text.ZBase32Encoder();
        return new UTF8Encoding().GetString(zBase32.Decode(inputValue));
    }
}
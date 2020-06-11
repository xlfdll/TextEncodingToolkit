using System;
using System.ComponentModel;
using System.Text;

namespace TextEncodingToolkit
{
    public static class DataHelper
    {
        public static String ToHexString(this Byte[] bytes, Boolean addSpace)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Byte b in bytes)
            {
                sb.Append(b.ToString("X2"));

                if (addSpace)
                {
                    sb.Append(' ');
                }
            }

            if (addSpace && sb.Length > 0)
            {
                // Remove last space
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }

        public static String ToBinaryString(this Byte[] bytes, Boolean addSpace)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Byte b in bytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));

                if (addSpace)
                {
                    sb.Append(' ');
                }
            }

            if (addSpace && sb.Length > 0)
            {
                // Remove last space
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }

        public static String ToHexString(this String text, Encoding encoding, Boolean addSpace)
        {
            return encoding.GetBytes(text).ToHexString(addSpace);
        }

        public static String ToBinaryString(this String text, Encoding encoding, Boolean addSpace)
        {
            return encoding.GetBytes(text).ToBinaryString(addSpace);
        }

        public static String ConvertHexToString(String hex, Encoding encoding)
        {
            hex = hex.Replace(" ", String.Empty);

            Byte[] bytes = new Byte[hex.Length / 2];

            try
            {
                for (Int32 i = 0; i < hex.Length; i += 2)
                {
                    Byte b = Convert.ToByte($"0x{hex.Substring(i, 2)}", 16);

                    bytes[i / 2] = b;
                }

                return encoding.GetString(bytes);
            }
            catch
            {
                return String.Empty;
            }
        }

        public static String ConvertHexToBinaryString(String hex, Boolean addSpace)
        {
            hex = hex.Replace(" ", String.Empty);

            StringBuilder sb = new StringBuilder();

            try
            {
                for (Int32 i = 0; i < hex.Length; i += 2)
                {
                    Byte b = Convert.ToByte($"0x{hex.Substring(i, 2)}", 16);
                    String s = Convert.ToString(b, 2).PadLeft(8, '0');

                    sb.Append(s);

                    if (addSpace)
                    {
                        sb.Append(' ');
                    }
                }

                if (addSpace && sb.Length > 0)
                {
                    // Remove last space
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            catch { }

            return sb.ToString();
        }
    }
}
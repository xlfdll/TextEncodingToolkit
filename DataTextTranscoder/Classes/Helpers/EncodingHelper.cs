using System;
using System.Collections.Generic;
using System.Text;

namespace DataTextTranscoder
{
    internal static class EncodingHelper
    {
        private static EncodingInfo[] _encodingInfoList = Encoding.GetEncodings();

        internal static EncodingInfo[] EncodingInfoList
        {
            get { return _encodingInfoList; }
        }

        internal static String ConvertBytesToHexString(Byte[] bytes, Boolean isSpaceExists)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Byte b in bytes)
            {
                sb.Append(b.ToString("X2"));

                if (isSpaceExists)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        internal static String ConvertBytesToBinString(Byte[] bytes, Boolean isSpaceExists)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Byte b in bytes)
            {
                sb.Append(isSpaceExists ? Convert.ToString(b, 2).PadLeft(8, '0') : Convert.ToString(b, 2));

                if (isSpaceExists)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        internal static String ConvertStringToHexString(String source, Encoding encoding, Boolean isSpaceExists)
        {
            return ConvertBytesToHexString(encoding.GetBytes(source), isSpaceExists);
        }

        internal static String ConvertStringToBinString(String source, Encoding encoding, Boolean isSpaceExists)
        {
            return ConvertBytesToBinString(encoding.GetBytes(source), isSpaceExists);
        }

        internal static String ConvertHexStringToBinString(String source, Boolean isSpaceExists)
        {
            source = source.Replace(" ", String.Empty);

            StringBuilder sb = new StringBuilder();

            try
            {
                for (Int32 i = 0; i < source.Length; i += 2)
                {
                    Int32 byteValue = Convert.ToInt32(String.Format("0x{0}", source.Substring(i, 2)), 16);
                    String byteString = isSpaceExists ? Convert.ToString(byteValue, 2).PadLeft(8, '0') : Convert.ToString(byteValue, 2);

                    sb.Append(byteString);

                    if (isSpaceExists)
                    {
                        sb.Append(" ");
                    }
                }
            }
            catch (Exception) { }

            return sb.ToString();
        }

        internal static String ConvertHexStringToString(String source, Encoding encoding)
        {
            source = source.Replace(" ", String.Empty);

            Byte[] binData = new Byte[source.Length / 2];

            try
            {
                for (Int32 i = 0, j = 0; i < source.Length; i += 2)
                {
                    Int32 byteValue = Convert.ToInt32(String.Format("0x{0}", source.Substring(i, 2)), 16);

                    binData[j++] = Convert.ToByte(byteValue);
                }

                return encoding.GetString(binData);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}
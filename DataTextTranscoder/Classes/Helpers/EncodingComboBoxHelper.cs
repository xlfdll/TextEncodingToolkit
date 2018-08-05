using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataTextTranscoder
{
    internal static class EncodingComboBoxHelper
    {
        internal static void FillEncodingComboBox(params ComboBox[] comboBoxes)
        {
            foreach (EncodingInfo encodingInfo in EncodingHelper.EncodingInfoList)
            {
                foreach (ComboBox comboBox in comboBoxes)
                {
                    comboBox.Items.Add(String.Format("{0} {1} [{2}]", encodingInfo.CodePage.ToString(), encodingInfo.DisplayName, encodingInfo.Name));
                }
            }
        }

        internal static Encoding GetEncodingByDescription(String description)
        {
            return Encoding.GetEncoding(Int32.Parse(description.Substring(0, description.IndexOf(" "))));
        }
    }
}
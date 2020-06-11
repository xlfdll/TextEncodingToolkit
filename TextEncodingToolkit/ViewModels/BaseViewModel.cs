using System.Collections.ObjectModel;
using System.Text;

using Xlfdll;

namespace TextEncodingToolkit
{
    public abstract class BaseViewModel : ObservableObject
    {
        public ObservableCollection<EncodingInfo> Encodings
            => new ObservableCollection<EncodingInfo>(Encoding.GetEncodings());
    }
}
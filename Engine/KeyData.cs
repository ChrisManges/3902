using System.Collections.Generic;
using System.Text;

namespace Homerchu.Engine
{
    class KeyData
    {
        public KeyData(ushort key, KeyFlags flags)
        {
            Key = key;
            Flags = flags;
        }

        public ushort Key { get; set; }

        public KeyFlags Flags { get; set; }
    }
}

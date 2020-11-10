using System.Collections.Generic;

namespace ComPortSettings
{
    public class ComSettingWriter
    {
        public List<ComConfig> comConfigs = new List<ComConfig>();

        public int[] cannelNum = new[] {1, 2, 3, 4};
        public int[] baudRate = new[] {2400, 9600};
        public int[] parityBit = new[] {0, 1};
        public int[] stopBits = new[] {0, 1};
        public bool DTR;

        public void DefaultConfCom()
        {

        }

        void Writer(int[] arr, int index)
        {

        }
    }
}
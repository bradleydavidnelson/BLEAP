using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEAP
{
    public class BTDevice
    {
        public byte[] address { get; set; }
        public byte addrType { get; set; }
        public byte connection { get; set; }
        public bool hasService { get; set; }
        public bool isConnected { get; set; }
        public bool isListed { get; set; }
        public bool isAwake { get; set; }
        public bool linkLost { get; set; }
        public string name { get; set; }
        public Stopwatch timer { get; set; }
        public string filePath { get; set; }


        // Variables
        public double temp { get; set; }
        public double rail { get; set; }
        public double currTime { get; set; }
        public double prevTime { get; set; }

        // Handles
        public UInt16 attServiceStart { get; set; }
        public UInt16 attServiceEnd { get; set; }
        public UInt16 attHandleData { get; set; }
        public UInt16 attHandleDualData { get; set; }
        public UInt16 attHandlePH { get; set; }
        public UInt16 attHandlePHCal { get; set; }
        public UInt16 attHandleControl { get; set; }
        public UInt16 attHandlePot { get; set; }
        public UInt16 attHandleTemp { get; set; }
        public UInt16 attHandleTemp2 { get; set; }
        public UInt16 attHandleRail { get; set; }
        public Queue<UInt16> attHandleCCC { get; set; }

        // Form Controls
        //public Collection<Control> Controls { get; }
        public List<Label> labels { get; set; }
        public int tableRow { get; set; }
        public Label nameLabel { get; set; }
        public Label ADC0Label { get; set; }
        public Label ADC1Label { get; set; }
        public Label phLabel { get; set; }
        public Label railLabel { get; set; }
        public Label tempLabel { get; set; }
        public Label temp2Label { get; set; }
        public Label uptimeLabel { get; set; }
        public Button sleepButton { get; set; }

        // Discovery Window Components
        public Label discoveryLabel { get; set; }
        public Button connectButton { get; set; }
    }
}

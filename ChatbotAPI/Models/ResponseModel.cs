using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatbotAPI
{
    public class ResponseModel
    {
        public bool lightsOpen { get; set; }
        public bool fridgeOpen { get; set; }
        public bool tvOpen { get; set; }
        public bool doorOpen { get; set; }

        public ResponseModel(bool lightsOpen, bool fridgeOpen, bool tvOpen, bool doorOpen)
        {
            this.lightsOpen = lightsOpen;
            this.fridgeOpen = fridgeOpen;
            this.tvOpen = tvOpen;
            this.doorOpen = doorOpen;
        }
    }
}

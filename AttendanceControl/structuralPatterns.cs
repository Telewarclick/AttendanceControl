using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class Pass
    {
        public virtual void ScreenSay()
        {
            Console.WriteLine("Hello worker-slaver");
        }
    }

    public class VipPass
    {
        public void ScreenSpecialPhrase()
        {
            Console.WriteLine("FBI, open up!");
        }
    }

    public class Adapter : Pass
    {
        private VipPass vipPass = new VipPass();

        public override void ScreenSay()
        {
            vipPass.ScreenSpecialPhrase();
        }
    }
}
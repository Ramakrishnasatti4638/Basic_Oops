using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inside
{
    public class First
    {
        public int publicNumber=10;

        private int PrivateNumber=20;

        protected int ProtectedNumber=30;
        public int PrivateOut { get {return PrivateNumber;} }

        internal int InternalNumber=40;
    }

    public class Second:First
    {
        public void SecondMethond()
        {
            First one=new First();
            System.Console.WriteLine(one.publicNumber);
            //System.Console.WriteLine(one.privateNumber);
            System.Console.WriteLine(ProtectedNumber);
            System.Console.WriteLine(InternalNumber);
        }
    }
}
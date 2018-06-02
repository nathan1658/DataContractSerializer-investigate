using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceTest
{

    public class ClassA
    {

        private int _int1;
        public int Int1
        {
            get
            {

                return _int1;
            }
            set
            {

                _int1 = value;
            }
        }

        public string ClassAString = "String from class A.";

        public ClassC ClassCInClassA;

        public ClassB ClassBInClassA;


    }
}
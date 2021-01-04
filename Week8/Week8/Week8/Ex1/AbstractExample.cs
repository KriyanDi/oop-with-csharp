using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Base
    {
        public virtual void Method()
        { }
    }
    class C : Base
    {
        public override void Method()
        { }
        public virtual void NewMethod()
        { }
    }

    abstract class B : C
    {
        public abstract override void Method();
        public abstract override void NewMethod();
    }

    class AbstractExample
    {
    }
}

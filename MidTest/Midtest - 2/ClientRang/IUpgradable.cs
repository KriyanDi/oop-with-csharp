using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientRang
{
    public interface IUpgradable
    {
        void Upgrade(Action<IUpgradable> action);
    }
}
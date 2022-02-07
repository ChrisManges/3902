using Homerchu.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario
{
    abstract class AvatarState : IState
    {
        public abstract void Handle(object context);
    }
}

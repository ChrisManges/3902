using Homerchu.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario
{
    abstract class AvatarState : IState<Avatar>
    {
        public abstract void Handle(Avatar context);
    }
}

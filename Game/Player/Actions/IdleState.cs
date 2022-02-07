using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario.Actions
{
    class IdleState : AvatarState
    {
        public override void Handle(object context)
        {
            Avatar avatar = (Avatar)context;
            avatar.sprite.SetAnimationRange(1 + avatar.rowSel * 14, 2 + avatar.rowSel * 14);
        }
    }
}

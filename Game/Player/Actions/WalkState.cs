using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario.Actions
{
    class WalkState : AvatarState
    {
        public override void Handle(object context)
        {
            Avatar avatar = (Avatar)context;
            avatar.sprite.SetAnimationRange(2 + avatar.rowSel * 14, 6 + avatar.rowSel * 14);
        }
    }
}

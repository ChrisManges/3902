using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario.Actions
{
    class IdleState : AvatarState
    {
        public override void Handle(Avatar context)
        {
            Avatar avatar = (Avatar)context;
            var row = avatar.rowSel * 15;
            avatar.sprite.SetAnimationRange(1 + row, 2 + row);
        }
    }
}

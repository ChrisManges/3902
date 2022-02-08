using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario.Actions
{
    class WalkState : AvatarState
    {
        public override void Handle(Avatar context)
        {
            Avatar avatar = (Avatar)context;
            var row = avatar.rowSel * 15;
            avatar.sprite.SetAnimationRange(2 + row, 6 + row);
        }
    }
}

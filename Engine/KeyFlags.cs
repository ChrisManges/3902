using System;

namespace Homerchu.Engine
{
    /// <summary>
    /// Explanation of the Key Flags
    /// 
    /// eNone => Never triggers a command.
    /// ePress => Triggers a command on Press.
    /// eHeld => Triggers a command on Hold.
    /// eReleased => Triggers a command when transitioning state to unpress/hold.
    /// eUntouched => Triggers a command while not pressed / held
    /// </summary>
    [Flags]
    enum KeyFlags
    {
        eNone       = 0x00,
        ePress      = 0x01,
        eHeld       = 0x02,
        eReleased   = 0x04,
        eUntouched  = 0x08
    }
}

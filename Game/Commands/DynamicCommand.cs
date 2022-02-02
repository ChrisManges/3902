using Homerchu.Engine;
using Microsoft.Xna.Framework;

namespace Homerchu.Mario
{
    class DynamicCommand : Command<MarioGame>
    {
        public DynamicCommand(MarioGame game) : base(game) { }
        public override void Execute() => _receiver.SetDynamic();
    }
}

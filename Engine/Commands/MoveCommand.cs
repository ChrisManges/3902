using Microsoft.Xna.Framework;

namespace Homerchu.Engine
{
    class MoveCommand : Command<Game1>
    {
        public MoveCommand(Game1 game) : base(game) { }
        public override void Execute() => _receiver.SetMove();
    }
}

using Microsoft.Xna.Framework;

namespace Homerchu.Engine
{
    class QuitCommand : Command<Game>
    {
        public QuitCommand(Game game) : base(game) { }
        public override void Execute() => _receiver.Exit();
    }
}

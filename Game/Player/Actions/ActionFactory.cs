using Homerchu.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario
{
    enum ActionStates
    {
        eIdle = 0,
        eWalk = 1,
        eCrouch = 2,
        eJump = 3,
        eFall = 4,
        eDying = 5
    };

    sealed class ActionFactory : IFactory<AvatarState>
    {
        private static ActionFactory instance = null;

        private ActionFactory() { }
        public static ActionFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new ActionFactory();

                return instance;
            }
        }


        public AvatarState MakeObject(int type)
        {
            var cast = (ActionStates)type;

            switch (cast)
            {
                case ActionStates.eIdle:
                    return new Actions.IdleState();

                case ActionStates.eWalk:
                    return new Actions.WalkState();

                case ActionStates.eCrouch:
                    throw new NotImplementedException();

                case ActionStates.eJump:
                    throw new NotImplementedException();

                case ActionStates.eFall:
                    throw new NotImplementedException();

                case ActionStates.eDying:
                    throw new NotImplementedException();
            }

            //Should never get here!
            throw new InvalidOperationException();
        }
    }
}

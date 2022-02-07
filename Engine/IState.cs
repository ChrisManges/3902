using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Engine
{

    /// <summary>
    /// IState is the interface for a State object with a single method, Handle.
    /// </summary>
    interface IState
    {
        /// <summary>
        /// Handle client context
        /// </summary>
        /// <param name="context"></param>
        void Handle(Object context);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Engine
{
    /// <summary>
    /// Factory Class Definition
    /// </summary>
    interface IFactory<T>
    {
        /// <summary>
        /// Makes the target object of a base type
        /// </summary>
        /// <param name="type">Integer to use as a switch</param>
        /// <returns></returns>
        T MakeObject(int type);
    }
}

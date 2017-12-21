using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class IAStrategy
    {

        /// <summary>
        /// L'IA joue une action, qui peut être de passer son tour
        /// </summary>
        public Action PlayOneAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
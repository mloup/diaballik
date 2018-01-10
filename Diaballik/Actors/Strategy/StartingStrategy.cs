using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Diaballik.Engine;

namespace Diaballik.Actors.Strategy
{
    public class StartingStrategy : IAStrategy
    {
        public StartingStrategy()
        {
            throw new System.NotImplementedException();
        }

        ~StartingStrategy()
        {
            throw new System.NotImplementedException();
        }

        public override void PlayOneAction(Game g)
        {
            
        }

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_doActionStartingStrategy(IntPtr algoPtr, int[,] tiles, int sizeArray, EnumCommand[] returnedMove, int[] returnedAttr);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algoPtr);
    }
}
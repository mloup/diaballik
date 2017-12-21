using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Diaballik
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

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_doActionStartingStrategy(IntPtr algoPtr, int[][] tiles, Action returnedMove, int[] returnedAttr);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algoPtr);
    }
}
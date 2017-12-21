using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Diaballik
{
    public class ProgressiveStrategy : IAStrategy
    {
        //private int nbtour;

        public ProgressiveStrategy()
        {
            throw new System.NotImplementedException();
        }

        ~ProgressiveStrategy()
        {
            throw new System.NotImplementedException();
        }

        public int nbTour
        {
            get => default(int);
            set
            {
            }
        }

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_doActionProgressiveStrategy(IntPtr algoPtr, int[][] tiles, Action returnedMove, int[] returnedAttr);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algoPtr);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Diaballik.Engine;


namespace Diaballik
{
    public class ProgressiveStrategy : IAStrategy
    {
        public int TurnCount { get; set; }

        public ProgressiveStrategy()
        {
            throw new System.NotImplementedException();
        }

        ~ProgressiveStrategy()
        {
            throw new System.NotImplementedException();
        }

        public override void PlayOneAction(Game g)
        {
            
        }

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_doActionProgressiveStrategy(IntPtr algoPtr, int[,] tiles, int sizeArray, EnumCommand[] returnedMove, int[] returnedAttr);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algoPtr);
    }
}
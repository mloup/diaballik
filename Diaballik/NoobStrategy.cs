using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Diaballik
{
    public class NoobStrategy : IAStrategy
    {
        IntPtr algoPtr;

        public NoobStrategy()
        {
            throw new System.NotImplementedException();
        }

        ~NoobStrategy()
        {
            throw new System.NotImplementedException();
        }



        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_DoActionNoobStrategy(IntPtr algoPtr, int[] piecesPlayer0, int[] piecesPlayer1, int[] ballCoord);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algoPtr);
    }
}
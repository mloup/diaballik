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
        bool disposed = false ;

        public NoobStrategy()
        {
            algoPtr = Algo_new();
        }

        ~NoobStrategy()
        {
            Dispose(true);
            Algo_delete(algoPtr);
        }

        new public Action PlayOneAction()
        {
            try
            {
                Piece[] pieces0, pieces1;
                int nbPiece;
                Console.WriteLine("zone1");
                pieces0 = Game.INSTANCE.Players[0].Pieces;
                nbPiece = pieces0.Length;
                pieces1 = Game.INSTANCE.Players[1].Pieces;
                Console.WriteLine("zone2");
                int[] piecesPlayer0 = new int[pieces0.Length * 2];
                int[] piecesPlayer1 = new int[pieces1.Length * 2];

                int[] ballPlayer0 = new int[2];
                int[] ballPlayer1 = new int[2];
                Console.WriteLine("zone3");
                Action[] returnedMove = new Action[1];
                int[] returnedAttr = new int[4];
                Console.WriteLine("zone4");

                for (int i = 0; i < pieces0.Length * 2; i += 2)
                {
                    piecesPlayer0[i] = pieces0[i / 2].coordX;
                    piecesPlayer0[i + 1] = pieces0[i / 2].coordY;
                    piecesPlayer1[i] = pieces1[i / 2].coordX;
                    piecesPlayer1[i + 1] = pieces1[i / 2].coordY;

                    if (pieces0[i / 2].carryBall)
                    {
                        ballPlayer0[0] = pieces0[i / 2].coordX;
                        ballPlayer0[1] = pieces0[i / 2].coordY;
                    }

                    if (pieces1[i / 2].carryBall)
                    {
                        ballPlayer1[0] = pieces1[i / 2].coordX;
                        ballPlayer1[1] = pieces1[i / 2].coordY;
                    }
                }
                Console.WriteLine("zone5");
                Algo_doActionNoobStrategy(algoPtr, piecesPlayer0, piecesPlayer1, ballPlayer0, ballPlayer1, returnedMove, returnedAttr);
                return returnedMove[0];
            } catch (System.NullReferenceException e)
            {
                Console.WriteLine("exception1 !");
                return Action.DoNothing;
            } catch (System.TypeInitializationException e)
            {
                Console.WriteLine("exception2 !");
                return Action.DoNothing;
            }
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                Algo_delete(algoPtr);
            }
            disposed = true;
        }



        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_doActionNoobStrategy(IntPtr algoPtr, int[] piecesPlayer0, int[] piecesPlayer1, int[] ballPlayer0, int[] ballPlayer1, IAStrategy.Action[] returnedMove, int[] returnedAttr);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algoPtr);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Diaballik
{
    public class NoobStrategy : IAStrategy, IDisposable
    {
        public NoobStrategy()
        {
            AlgoPtr = Algo_new();
        }

        ~NoobStrategy()
        {
            Dispose(true);
            Algo_delete(AlgoPtr);
        }

        public override void PlayOneAction(Game g)
        {
            var returnedMove = new EnumCommand[1];
            int[] prevX = new int[1];
            int[] prevY = new int[1];
            int[] nextX = new int[1];
            int[] nextY = new int[1];

            //Convert MutliDim Enum Array to MultiDim Int Array
            Tiles[,] enumArray = g.Board.Tiles;
            int sizeArray = enumArray.GetLength(0);
            var intArray = new int[sizeArray, sizeArray];
            Array.Copy(enumArray, intArray, enumArray.Length);

            Algo_doActionNoobStrategy(AlgoPtr, intArray , sizeArray, returnedMove, prevX, prevY, nextX, nextY);

            switch (returnedMove[0])
            {
                case EnumCommand.MovePiece:
                    Command movePieceCmd = new MovePiece(prevX[0], prevY[0], nextX[0], nextY[0]);
                    Console.Write("test MovePiece\n");
                    movePieceCmd.Do(g);
                    break;
                case EnumCommand.MoveBall:
                    Command moveBallCmd = new MoveBall(prevX[0], prevY[0], nextX[0], nextY[0]);
                    Console.Write("test MoveBall\n");
                    moveBallCmd.Do(g);
                    break;
                case EnumCommand.EndTurn:
                    Command endTurnCmd = new EndTurn(prevX[0]);
                    Console.Write("test EndTurn\n");
                    endTurnCmd.Do(g);
                    break;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;
            if (disposing)
            {
                Algo_delete(AlgoPtr);
            }
            Disposed = true;
        }



        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_doActionNoobStrategy(IntPtr algoPtr, int[,] tiles, int sizeArray, EnumCommand[] returnedMove, int[] prevX, int[] prevY, int[] nextX, int[] nextY);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algoPtr);
    }
}
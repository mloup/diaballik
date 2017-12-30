using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

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
            var returnedMove = new EnumCommand[1];
            var returnedAttr = new int[4];

            //Convert MutliDim Enum Array to MultiDim Int Array
            Tiles[,] enumArray = g.Board.Tiles;
            int sizeArray = enumArray.GetLength(0);
            var intArray = new int[sizeArray, sizeArray];
            Array.Copy(enumArray, intArray, enumArray.Length);

            Algo_doActionProgressiveStrategy(AlgoPtr, intArray, sizeArray, returnedMove, returnedAttr);

            switch (returnedMove[0])
            {
                case EnumCommand.MovePiece:
                    Command movePieceCmd = new MovePiece(returnedAttr[0], returnedAttr[1], returnedAttr[2], returnedAttr[3]);
                    movePieceCmd.Do(g);
                    break;
                case EnumCommand.MoveBall:
                    Command moveBallCmd = new MoveBall(returnedAttr[0], returnedAttr[1], returnedAttr[2], returnedAttr[3]);
                    moveBallCmd.Do(g);
                    break;
                case EnumCommand.EndTurn:
                    Command endTurnCmd = new EndTurn(returnedAttr[0]);
                    endTurnCmd.Do(g);
                    break;
            }
        }

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_doActionProgressiveStrategy(IntPtr algoPtr, int[,] tiles, int sizeArray, EnumCommand[] returnedMove, int[] returnedAttr);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algoPtr);
    }
}
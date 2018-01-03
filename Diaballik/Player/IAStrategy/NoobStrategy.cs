using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Diaballik
{
    public class NoobStrategy : IAStrategy
    {
        public override void PlayOneAction(Game g)
        {
            int prevX = 1, prevY = -1, nextX = -1, nextY = -1;
            bool isActionValid = false;

            //Convert MutliDim Enum Array to 1-Dim Int Array
            int[] intArray = GetIntArray(g.Board.Tiles);
            int nbTiles = g.Board.Tiles.Length;

            while (!isActionValid)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 3);
                switch (randomNumber)
                {
                    case 0: // MovePiece
                        if (g.MovePieceCount < 2)
                        {
                            IntPtr actionMovePiecePtr = Algo_MovePieceNoobStrategy(intArray, nbTiles);
                            prevX = (int)Marshal.ReadIntPtr(actionMovePiecePtr);
                            prevY = (int)Marshal.ReadIntPtr(actionMovePiecePtr + 4);
                            nextX = (int)Marshal.ReadIntPtr(actionMovePiecePtr + 8);
                            nextY = (int)Marshal.ReadIntPtr(actionMovePiecePtr + 12);

                            Command movePieceCmd = new MovePiece(prevX, prevY, nextX, nextY);
                            Console.Write("IA NoobStrategy moves a piece from (" + prevX + "," + prevY + ") to (" + nextX + "," + nextY + ")\n");
                            movePieceCmd.Do(g);
                            isActionValid = true;
                        }
                        break;

                    case 1: // MoveBall
                        if(g.MoveBallCount == 0)
                        {
                            IntPtr actionMoveBallPtr = Algo_MoveBallNoobStrategy(intArray, nbTiles);
                            prevX = (int)Marshal.ReadIntPtr(actionMoveBallPtr);
                            prevY = (int)Marshal.ReadIntPtr(actionMoveBallPtr + 4);
                            nextX = (int)Marshal.ReadIntPtr(actionMoveBallPtr + 8);
                            nextY = (int)Marshal.ReadIntPtr(actionMoveBallPtr + 12);

                            Command moveBallCmd = new MoveBall(prevX, prevY, nextX, nextY);
                            if (nextX != -1 && nextY != -1)
                            {
                                Console.Write("IA NoobStrategy moves his ball from (" + prevX+","+prevY+") to ("+nextX+","+nextY+")\n");
                                moveBallCmd.Do(g);
                                isActionValid = true;
                            }
                        }
                        break;

                    case 2: // EndTurn
                        Command endTurnCmd = new EndTurn(prevX);
                        Console.Write("IA NoobStrategy EndTurn\n");
                        endTurnCmd.Do(g);
                        break;
                }
            }
        }



        private int[] GetIntArray(Tiles[,] tiles)
        {
            int i = 0;
            int nbTiles = tiles.Length;
            int[] intArray = new int[nbTiles];
            for (int k = 0; k < Math.Sqrt(nbTiles); k++)
            {
                for (int j = 0; j < Math.Sqrt(nbTiles); j++)
                {
                    intArray[i] = (int) tiles[k, j];
                    i++;
                }
            }
            return intArray;
        }

        [DllImport("libCPP.dll", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr Algo_MovePieceNoobStrategy(int[] tiles, int size);

        [DllImport("libCPP.dll", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr Algo_MoveBallNoobStrategy(int[] tiles, int size);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Diaballik.Engine;
using Diaballik.Actions;

namespace Diaballik.Actors.Strategy
{
    public class NoobStrategy : IAStrategy
    {
        private static Random random = new Random();

        public override void PlayOneAction(Game g)
        {
            if (g.CurrentPlayer == 1)
            {
                int prevX = 1, prevY = -1, nextX = -1, nextY = -1;
                bool isActionValid = false;

                //Convert MutliDim Enum Array to 1-Dim Int Array
                int[] intArray = GetIntArray(g.Board.Tiles);
                int nbTiles = g.Board.Tiles.Length;

                while (!isActionValid)
                {
                    int randomNumber = random.Next(0, 100);
                    switch (randomNumber)
                    {
                        case int x when x <=40: // MovePiece
                            if (g.MovePieceCount < 2)
                            {
                                IntPtr actionMovePiecePtr = Algo_MovePieceNoobStrategy(intArray, nbTiles);
                                prevX = (int)Marshal.ReadIntPtr(actionMovePiecePtr);
                                prevY = (int)Marshal.ReadIntPtr(actionMovePiecePtr + 4);
                                nextX = (int)Marshal.ReadIntPtr(actionMovePiecePtr + 8);
                                nextY = (int)Marshal.ReadIntPtr(actionMovePiecePtr + 12);

                                Console.Write("IA NoobStrategy moves a piece from (" + prevX + "," + prevY + ") to (" + nextX + "," + nextY + ")\n");
                                MovePiece mp = new MovePiece(prevX, prevY, nextX, nextY);
                                g.Update(mp);
                                isActionValid = true;
                            }
                            break;

                        case int x when x <= 80: // MoveBall
                            if (g.MoveBallCount == 0)
                            {
                                IntPtr actionMoveBallPtr = Algo_MoveBallNoobStrategy(intArray, nbTiles);
                                prevX = (int)Marshal.ReadIntPtr(actionMoveBallPtr);
                                prevY = (int)Marshal.ReadIntPtr(actionMoveBallPtr + 4);
                                nextX = (int)Marshal.ReadIntPtr(actionMoveBallPtr + 8);
                                nextY = (int)Marshal.ReadIntPtr(actionMoveBallPtr + 12);


                                if (nextX != -1 && nextY != -1)
                                {
                                    Console.Write("IA NoobStrategy moves his ball from (" + prevX + "," + prevY + ") to (" + nextX + "," + nextY + ")\n");
                                    MoveBall mb = new MoveBall(prevX, prevY, nextX, nextY);
                                    g.Update(mb);
                                    isActionValid = true;
                                }
                            }
                            break;

                        default: // EndTurn
                            Command endTurnCmd = new EndTurn();
                            //Console.Write("IA NoobStrategy EndTurn\n");
                            g.Update(endTurnCmd);
                            break;
                    }
                }
            }
            else throw new InvalidOperationException("L'IA n'est plus le joueur courant !");
        }



        private int[] GetIntArray(TileTypes[,] tiles)
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
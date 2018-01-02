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
            EnumCommand actionType;
            int prevX, prevY, nextX , nextY;


            //Convert MutliDim Enum Array to 1-Dim Int Array
            var intArray = GetIntArray(g.Board.Tiles);
            int nbTiles = g.Board.Tiles.Length;

            IntPtr actionPtr = Algo_doActionNoobStrategy(intArray, nbTiles);
            actionType = (EnumCommand) Marshal.ReadIntPtr(actionPtr);
            prevX = (int) Marshal.ReadIntPtr(actionPtr+4);
            prevY = (int) Marshal.ReadIntPtr(actionPtr+8);
            nextX = (int) Marshal.ReadIntPtr(actionPtr+12);
            nextY = (int) Marshal.ReadIntPtr(actionPtr+16);

            Console.WriteLine("Voici le résultat du test = " + actionType + " " + prevX + " " + prevY + " " + nextX + " " + nextY); // YAAATAAAAA !
            Console.Read();

            switch (actionType)
            {
                case EnumCommand.MovePiece:
                    Command movePieceCmd = new MovePiece(prevX, prevY, nextX, nextY);
                    Console.Write("MovePiece\n");
                    movePieceCmd.Do(g);
                    break;
                case EnumCommand.MoveBall:
                    Command moveBallCmd = new MoveBall(prevX, prevY, nextX, nextY);
                    Console.Write("MoveBall\n");
                    moveBallCmd.Do(g);
                    break;
                case EnumCommand.EndTurn:
                    Command endTurnCmd = new EndTurn(prevX);
                    Console.Write("EndTurn\n");
                    endTurnCmd.Do(g);
                    break;
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


        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr Algo_doActionNoobStrategy(int[] tiles, int size);
    }
}
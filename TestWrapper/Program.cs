using System;
using System.Threading;
using Diaballik;
using Diaballik.Actions;
using Diaballik.Actors;
using Diaballik.Actors.Strategy;
using Diaballik.Engine;
using Diaballik.Engine.Builder;

namespace TestWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu diaballik (entrer le numéro de l'action) :");
            Console.WriteLine("\t 1 : Nouvelle Partie (standard)");
            Console.WriteLine("\t 2 : Charger une partie (standard)");
            Console.WriteLine("\t 3 : exit");
            bool validation = true;
            while (validation) {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        Console.WriteLine("Le nom du joueur 1:");
                        string nom1 = Console.ReadLine();
                        Console.WriteLine("La couleur du joueur 1:");
                        string color1 = Console.ReadLine();
                        Console.WriteLine("Le nom du joueur 2:");
                        string nom2 = Console.ReadLine();
                        Console.WriteLine("La couleur du joueur 2:");
                        string color2 = Console.ReadLine();

                        Console.WriteLine("Type de Board souhaiter (standard/ballrandom/enemyamongus):");
                        BoardStrategy strat;
                        string boardStrat = Console.ReadLine();
                        switch (boardStrat)
                        {
                            case "standrard":
                                strat = BoardStrategy.Standard;
                                break;
                            case "ballrandom":
                                strat = BoardStrategy.BallRandom;
                                break;
                            case "enemyamongus":
                                strat = BoardStrategy.EnemyAmongUs;
                                break;
                            default:
                                strat = BoardStrategy.Standard;
                                break;
                        }

                        Console.WriteLine("Taille de Board souhaiter (entrer un entier impair):");
                        int size;
                        while ((size = int.Parse(Console.ReadLine())) % 2 != 1)
                        {
                            Console.WriteLine("Veuillez entrer un entier impair:");
                        }


                        GameBuilder gb = new GameBuilder().SetPlayer0(nom1, color1).SetPlayer1(nom2, color2).SetBoard(size, strat);
                        Game g = gb.Build();

                        bool valid = true;
                        while (valid)
                        {
                            Console.WriteLine(g.ToString());
                            Console.WriteLine("Nombre de déplacement de pièce restant :" + (2 - g.MovePieceCount));
                            Console.WriteLine("Nombre de déplacement de pièce restant :" + (1 - g.MoveBallCount));
                            Console.WriteLine("Choississez votre action :");
                            Console.WriteLine("1: Déplacer Pièce");
                            Console.WriteLine("2: Déplacer Ball");
                            Console.WriteLine("3: Fin du tour");
                            Console.WriteLine("4: Undo");
                            Console.WriteLine("5: Redo");
                            Console.WriteLine("6: Exit");
                            string rep = Console.ReadLine();
                            switch (rep)
                            {
                                case "1": // Move Piece
                                    Console.WriteLine("which piece ? (x)");
                                    string repx = Console.ReadLine();
                                    Console.WriteLine("which piece ? (y)");
                                    string repy = Console.ReadLine();
                                    Console.WriteLine("where to ? (x)");
                                    string wherex = Console.ReadLine();
                                    Console.WriteLine("where to ? (y)");
                                    string wherey = Console.ReadLine();
                                    g.Update(new MovePiece(int.Parse(repx), int.Parse(repy), int.Parse(wherex), int.Parse(wherey)));
                                    break;
                                case "2": // Move Ball
                                    Console.WriteLine("which piece ? (x)");
                                    string pbx = Console.ReadLine();
                                    Console.WriteLine("which piece ? (y)");
                                    string pby = Console.ReadLine();
                                    Console.WriteLine("where to ? (x)");
                                    string nbx = Console.ReadLine();
                                    Console.WriteLine("where to ? (y)");
                                    string nby = Console.ReadLine();
                                    g.Update(new MoveBall(int.Parse(pbx), int.Parse(pby), int.Parse(nbx), int.Parse(nby)));
                                    break;
                                case "3": // End Turn
                                    g.Update(new EndTurn());
                                    break;
                                case "4": //Undo
                                    g.UndoLastCommand();
                                    break;
                                case "5": //Redo
                                    g.RedoLastCommand();
                                    break;
                                case "6":
                                    return;
                            }
                            if (g.IsWin())
                            {
                                valid = false;
                                Console.WriteLine("Le jeu est fini. Le joueur victorieux est :");
                                Console.WriteLine(g.VictoriousPlayer.ToString());
                            }
                        }



                        break;
                    case "2": // Charger une partie
                        string filename = Console.ReadLine();
                        filename = @"C:\Temp\diaballik_loadgamebuildertest.save";
                        Game g2 = GameSaveManager.Load(filename);
                        bool valid1 = true;
                        while (valid1)
                        {
                            Console.WriteLine(g2.ToString());
                            Console.WriteLine("Nombre de déplacement de pièce restant :" + (2 - g2.MovePieceCount));
                            Console.WriteLine("Nombre de déplacement de pièce restant :" + (1 - g2.MoveBallCount));
                            Console.WriteLine("Choississez votre action :");
                            Console.WriteLine("1: move piece");
                            Console.WriteLine("2: move ball");
                            Console.WriteLine("3: end turn");
                            Console.WriteLine("4: exit");
                            string rep = Console.ReadLine();
                            switch (rep)
                            {
                                case "1":
                                    Console.WriteLine("which piece ? (x)");
                                    string repx = Console.ReadLine();
                                    Console.WriteLine("which piece ? (y)");
                                    string repy = Console.ReadLine();
                                    Console.WriteLine("where to ? (x)");
                                    string wherex = Console.ReadLine();
                                    Console.WriteLine("where to ? (y)");
                                    string wherey = Console.ReadLine();
                                    g2.Update(new MovePiece(int.Parse(repx), int.Parse(repy), int.Parse(wherex), int.Parse(wherey)));
                                    break;
                                case "2":
                                    Console.WriteLine("which piece ? (x)");
                                    string pbx = Console.ReadLine();
                                    Console.WriteLine("which piece ? (y)");
                                    string pby = Console.ReadLine();
                                    Console.WriteLine("where to ? (x)");
                                    string nbx = Console.ReadLine();
                                    Console.WriteLine("where to ? (y)");
                                    string nby = Console.ReadLine();
                                    g2.Update(new MoveBall(int.Parse(pbx), int.Parse(pby), int.Parse(nbx), int.Parse(nby)));
                                    break;
                                case "3":
                                    g2.Update(new EndTurn());
                                    break;
                                case "4":
                                    return;
                            }
                            if (g2.IsWin())
                            {
                                valid = false;
                                Console.WriteLine("Le jeu est fini. Le joueur victorieux est :");
                                Console.WriteLine(g2.VictoriousPlayer.ToString());
                            }
                        }
                        break;
                    case "3":
                        break;
                }
            }

            return;
        }
    }
}

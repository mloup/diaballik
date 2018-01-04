using Diaballik.Actors;
using System;
using System.Collections.Generic;

namespace Diaballik.Engine.Builder
{
    public abstract class GameBuilder
    {
        public Game MyGameToBuild { get; set; }

        public GameBuilder()
        {
            MyGameToBuild = new Game();
        }

        public GameBuilder SetPlayer0(Player p)
        {
            if (!(p is IAPlayer))
            {
                MyGameToBuild.Players[0] = p;
                return this;
            }
            else
            {
                throw new ArgumentException("L'IA doit etre mise sur le joueur 1");
            }

        }

        public GameBuilder SetPlayer1(Player p)
        {
            MyGameToBuild.GameHasIA = (p is IAPlayer) ? true : false;
            MyGameToBuild.Players[1] = p;
            return this;
        }


        public GameBuilder SetBoard(int size)
        {
            if (size%2 == 1)
            {
                MyGameToBuild.Board = new Board(size);
                FillBoard();
                return this;
            }
            else
            {
                // lever une exception pour taille de board incorrect
                throw new ArgumentException("La taille du Board doit être impaire");
            }      
        }

        public virtual Game Build()
        {
            return MyGameToBuild;
        }

        protected abstract void FillBoard();
    }
}
#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <stdio.h>
#include <time.h>
#include <math.h>
#include <cstdlib>


using namespace std;

namespace Strategy {
	int&  Algo_doActionNoobStrategy(Tiles* tiles, int size)
	{
		int* actionResult = new int[5];
		//actionResult[0] = (rand() % 3);
		actionResult[0] = (EnumCommand) 0;
		//actionResult[1] = 0;
		//actionResult[2] = 0;
		//actionResult[3] = 1;


		switch ((EnumCommand)actionResult[0])
		{
		case MovePiece:
			MovePieceNoobStrategy(tiles, size, actionResult);
			break;

		case MoveBall:
			break;

		case EndTurn:
			break;

		Default :
			printf("Problème !");
		}

		return *actionResult;
	}



	void MovePieceNoobStrategy(Tiles* tiles, int nbTiles, int*(& actionResult)) {
		srand(time(NULL));									// Positionnement de random() au nombre de secondes écoulées depuis 1970
		
		int sideSize = (int) sqrt(nbTiles);
		int randomPieceToSelect = (rand() % (sideSize - 1));	// Selection aléatoire d'une des (sideSize - 1) pièces (ne portant pas la balle) de l'IA

		int count = 0;
		int oldIndex;
		int prevX, prevY, nextX, nextY;						// Paramètre de la commande à executer
		
		//printf("%i \n", nbTiles);
		printf("RandomPieceToSelect = %i \n", randomPieceToSelect);


		for (int i = 0; i < nbTiles; i++) {
			// printf("%i \n", (int)tiles[i]);
			if (tiles[i] == (int)PiecePlayer1) {
				if (count == randomPieceToSelect) {
					oldIndex = i;
					break;
				}
				count++;
			}
		}


		prevX = (int) oldIndex / sideSize;
		prevY = oldIndex % sideSize;

		printf("Selection de la piece : X = %i  et  Y = %i \n", prevX, prevY);

		int newIndex = GetRandomMoveAmongPossible(tiles, sideSize, oldIndex);

		nextX = (int) newIndex / sideSize;
		nextY = newIndex % sideSize;

		/*
		randomDirection = (rand() % 4);
		switch (randomDirection)
		{
		case 0: // move up
			nextX = prevX;
			nextY = (prevY - 1 < 0) ? prevY + 1 : prevY - 1;
			break;

		case 1: // move down
			nextX = prevX;
			nextY = (prevY + 1 >= sideSize) ? prevY - 1 : prevY + 1;
			break;

		case 2: // move right
			nextX = (prevX + 1 >= sideSize) ? prevX - 1 : prevX + 1;
			nextY = prevY;
			break;

		case 3: // move left
			nextX = (prevX - 1 < 0) ? prevX + 1 : prevX - 1;
			nextY = prevY;
			break;
		}
		*/
		actionResult[1] = prevX;
		actionResult[2] = prevY;
		actionResult[3] = nextX;
		actionResult[4] = nextY;
	}

	int GetRandomMoveAmongPossible(Tiles*(& tiles), int& sideSize, int& const oldIndex) {
		int moveUp = (oldIndex%sideSize != 0 && tiles[oldIndex - 1] == DefTiles) ? 1 : 0;
		int moveDown = (oldIndex%sideSize != (sideSize -1) && tiles[oldIndex + 1] == DefTiles) ? 1 : 0;
		int moveLeft = (oldIndex-sideSize >= 0 && tiles[oldIndex - sideSize] == DefTiles) ? 1 : 0;
		int moveRight = (oldIndex+sideSize <= sideSize && tiles[oldIndex + sideSize] == DefTiles) ? 1 : 0;

		int nbPossibleMoves = moveUp + moveDown + moveLeft + moveRight;
		int randomMoveAmongPossible = (rand() % (nbPossibleMoves+1));

		//TODO
		return 0;
	}







	void doActionStartingStrategy(Tiles** tiles, int size, EnumCommand returnedMove[], int prevX[], int prevY[], int nextX[], int nextY[])
	{
		//returnedMove = (EnumCommand)(rand() % 3); mis commentaire pour effectuer les tests
		returnedMove[0] = MovePiece;
		switch (returnedMove[0])
		{
		case MovePiece:
			break;

		case MoveBall:
			break;

		case EndTurn:
			break;
		}
	}

	void doActionProgressiveStrategy(Tiles** tiles, int size, EnumCommand returnedMove[], int prevX[], int prevY[], int nextX[], int nextY[])
	{
		//returnedMove = (EnumCommand)(rand() % 3); mis commentaire pour effectuer les tests
		returnedMove[0] = MovePiece;
		switch (returnedMove[0])
		{
		case MovePiece:
			break;

		case MoveBall:
			break;

		case EndTurn:
			break;
		}
	}
}
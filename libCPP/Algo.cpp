#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <stdio.h>
#include <time.h>
#include <math.h>
#include <cstdlib>


using namespace std;

namespace Strategy {
	int&  Algo_doActionNoobStrategy(const Tiles* tiles, const int nbTiles)
	{
		srand((unsigned int) time(NULL));  // Positionnement de random() au nombre de secondes écoulées depuis 1970
		int* actionResult = new int[5];
		actionResult[0] = (rand() % 3);

		switch ((EnumCommand)actionResult[0])
		{
		case MovePiece:
			MovePieceNoobStrategy(tiles, nbTiles, actionResult);
			break;

		case MoveBall:
			actionResult[1] = 2;
			actionResult[2] = 1;
			actionResult[3] = 1;
			actionResult[4] = 1;
			//MoveBallNoobStrategy(tiles, nbTiles, actionResult);
			break;

		case EndTurn:
			actionResult[1] = -1;
			actionResult[2] = -1;
			actionResult[3] = -1;
			actionResult[4] = -1;
			break;

		Default :
			printf("Problème !");
		}

		return *actionResult;
	}



	void MovePieceNoobStrategy(const Tiles*& tiles, const int& nbTiles, int*& actionResult){
		int sideSize = (int) sqrt(nbTiles);
		int randomPieceToSelect = (rand() % (sideSize - 1));	// Selection aléatoire d'une des (sideSize - 1) pièces (ne portant pas la balle) de l'IA

		int count = 0;
		int oldIndex;
		int prevX, prevY, nextX, nextY;						// Paramètre de la commande à executer
		
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

		//printf("Selection de la piece : X = %i  et  Y = %i \n", prevX, prevY);

		int newIndex = GetRandomMoveAmongPossible(tiles, sideSize, oldIndex);

		nextX = (int) newIndex / sideSize;
		nextY = newIndex % sideSize;

		actionResult[1] = prevX;
		actionResult[2] = prevY;
		actionResult[3] = nextX;
		actionResult[4] = nextY;
	}

	int GetRandomMoveAmongPossible(const Tiles*(&tiles), const int& sideSize, int& const oldIndex) {
		int* moveArray = new int[4];

		moveArray[0] = (oldIndex%sideSize != 0 && tiles[oldIndex - 1] == DefTiles) ? 1 : 0; // up
		moveArray[1] = (oldIndex%sideSize != (sideSize - 1) && tiles[oldIndex + 1] == DefTiles) ? 1 : 0; // down
		moveArray[2] = (oldIndex - sideSize >= 0 && tiles[oldIndex - sideSize] == DefTiles) ? 1 : 0; // left
		moveArray[3] = (oldIndex + sideSize <= sideSize && tiles[oldIndex + sideSize] == DefTiles) ? 1 : 0; // right

		int randomMoveAmongPossible = (rand() % 4);
		while (moveArray[randomMoveAmongPossible] != 1)
		{
			randomMoveAmongPossible = (rand() % 4);
		}

		switch(randomMoveAmongPossible) {
		case 0:
			return oldIndex - 1;
		case 1:
			return oldIndex + 1;
		case 2:
			return oldIndex - sideSize;
		case 3:
			return oldIndex + sideSize;
		}
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
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
			MoveBallNoobStrategy(tiles, nbTiles, actionResult);
			break;

		case EndTurn:
			actionResult[1] = -1;
			actionResult[2] = -1;
			actionResult[3] = -1;
			actionResult[4] = -1;
			break;

		Default :
			throw exception("L'action doit être de type EndTurn ou MoveBall ou MovePiece");
		}

		return *actionResult;
	}



	void MovePieceNoobStrategy(const Tiles*& tiles, const int& nbTiles, int*& actionResult){
		int sideSize = (int) sqrt(nbTiles);						// sideSize = nb Tiles par côté du Board
		int randomPieceToSelect = (rand() % (sideSize - 1));	// Selection aléatoire d'une des (sideSize - 1) pièces (ne portant pas la balle) de l'IA

		int pieceIndex = GetPieceIndex(tiles, nbTiles, randomPieceToSelect);
		
		//printf("RandomPieceToSelect = %i \n", randomPieceToSelect);

		
		//printf("Selection de la piece : X = %i  et  Y = %i \n", prevX, prevY);
		int newIndex = GetRandomMoveAmongPossible(tiles, sideSize, pieceIndex);

		actionResult[1] = (int)pieceIndex / sideSize;		// prevX
		actionResult[2] = pieceIndex % sideSize;			// prevY
		actionResult[3] = (int)newIndex / sideSize;			// nextX
		actionResult[4] = newIndex % sideSize;				// nextY
	}

	void MoveBallNoobStrategy(const Tiles*& tiles, const int& nbTiles, int*& actionResult) {
		int sideSize = (int)sqrt(nbTiles);	 // sideSize = nb Tiles par côté du Board
		int ballIndex = GetBallIndex(tiles, nbTiles);
		if (ballIndex == -1) throw exception("Index de la balle non valide !");

		int newBallIndex = GetRandomMoveAmongPossible(tiles, sideSize, ballIndex);

		actionResult[1] = (int)ballIndex / sideSize;		// prevX
		actionResult[2] = ballIndex % sideSize;			// prevY
		actionResult[3] = (int)newBallIndex / sideSize;		// nextX
		actionResult[4] = newBallIndex % sideSize;			// nextY

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
		case 0: // MoveUp
			return oldIndex - 1;
		case 1: // MoveDown
			return oldIndex + 1;
		case 2: // MoveLeft
			return oldIndex - sideSize;
		case 3: // MoveRight
			return oldIndex + sideSize;
		}
	}

	int GetBallIndex(const Tiles*& tiles, const int& nbTiles) {
		int res = -1;
		for (int i = 0; i < nbTiles; i++) {
			if (tiles[i] == BallPlayer1) {
				res = i;
				break;
			}
		}
		return res;
	}

	int GetPieceIndex(const Tiles*& tiles, const int& nbTiles, const int& pieceID) {
		int pieceCount = 0 , res;
		for (int i = 0; i < nbTiles; i++) {
			if (tiles[i] == (int)PiecePlayer1) {
				if (pieceCount == pieceID) {
					res = i;
					break;
				}
				pieceCount++;
			}
		}
		return res;
	}

}
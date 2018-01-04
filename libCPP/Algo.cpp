#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <stdio.h>
#include <time.h>
#include <math.h>
#include <cstdlib>
#include <vector>


using namespace std;

namespace Strategy {

	int& Algo_MovePieceNoobStrategy(const Tiles* tiles, const int nbTiles){
		int* actionResult = new int[4];

		int sideSize = (int) sqrt(nbTiles);						// sideSize = nb Tiles par côté du Board
		int randomPieceToSelect = (rand() % (sideSize - 1));	// Selection aléatoire d'une des (sideSize - 1) pièces (ne portant pas la balle) de l'IA

		int pieceIndex = GetPieceIndex(tiles, nbTiles, randomPieceToSelect);
		
		//printf("RandomPieceToSelect = %i \n", randomPieceToSelect);

		
		//printf("Selection de la piece : X = %i  et  Y = %i \n", prevX, prevY);
		int newIndex = GetRandomMovePieceAmongPossible(tiles, sideSize, pieceIndex);

		actionResult[0] = (int)pieceIndex / sideSize;		// prevX
		actionResult[1] = pieceIndex % sideSize;			// prevY
		actionResult[2] = (int)newIndex / sideSize;			// nextX
		actionResult[3] = newIndex % sideSize;				// nextY

		return *actionResult;
	}

	int& Algo_MoveBallNoobStrategy(const Tiles* tiles, const int nbTiles) {
		int* actionResult = new int[4];
		int sideSize = (int)sqrt(nbTiles);	 // sideSize = nb Tiles par côté du Board
		int ballIndex = GetBallIndex(tiles, nbTiles);

		//printf("current Ball index is : %i \n", ballIndex);

		int newBallIndex = GetRandomMoveBallAmongPossible(tiles, sideSize, ballIndex);

		if (newBallIndex == -1) { // Dans le cas où il est impossible de déplacer la balle
			actionResult[0] = -1;		// prevX
			actionResult[1] = -1;		// prevY
			actionResult[2] = -1;		// nextX
			actionResult[3] = -1;		// nextY
		}
		else {
			actionResult[0] = (int)ballIndex / sideSize;		// prevX
			actionResult[1] = ballIndex % sideSize;				// prevY
			actionResult[2] = (int)newBallIndex / sideSize;		// nextX
			actionResult[3] = newBallIndex % sideSize;			// nextY
		}
		//printf("Algo_MoveBallNoobStrategy want to MoveBall from (%i , %i) --> (%i ,  %i) \n", actionResult[0], actionResult[1], actionResult[2], actionResult[3]);
		return *actionResult;
	}

	int GetRandomMovePieceAmongPossible(const Tiles*(&tiles), const int& sideSize, const int& oldIndex) {
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

		switch (randomMoveAmongPossible) {
		case 0: // MoveUp
			return oldIndex - 1;
		case 1: // MoveDown
			return oldIndex + 1;
		case 2: // MoveLeft
			return oldIndex - sideSize;
		case 3: // MoveRight
			return oldIndex + sideSize;
		default:
			return -10;
		}
	}

	int GetRandomMoveBallAmongPossible(const Tiles*(&tiles), const int& sideSize, const int& oldBallIndex) {
		int* indexOfAllPieces = GetAllPieceIndex(tiles, sideSize*sideSize);

		/*
		printf("Index des pieces de l'IA : \n");
		for (int i = 0; i < sideSize - 1; i++) {
			printf("%i\n", indexOfAllPieces[i]);
		}
		*/
		vector<int> indexOfPossibleMoves;

		for (int i = 0; i < (sideSize - 1); i++) {
			bool validation = true;
			int indexDifference = indexOfAllPieces[i] - oldBallIndex;

			//printf("Sur la même colonne ? %i et %i", indexOfAllPieces[i] / sideSize, oldBallIndex / sideSize);
			
			// Si la piece i est sur la même colonne que la balle
			if (indexOfAllPieces[i]/sideSize == oldBallIndex/sideSize) {
				//printf("Colonne :\n");

				// Si la piece i est en dessous de la balle
				if (indexDifference > 0) {
					//printf("\ten dessous :\n");
					for (int j = oldBallIndex+1; j != indexOfAllPieces[i]; j++) {
						if (tiles[j] != (int)DefTiles) {
							validation = false;
							break;
						}
					}
				}

				// Si la piece i est au dessus de la balle
				if (indexDifference < 0) { 
					//printf("\tau dessus :\n");
					for (int j = oldBallIndex - 1; j != indexOfAllPieces[i]; j--) {
						if (tiles[j] != (int)DefTiles) {
							validation = false;
							break;
						}
					}
				}
			}

			// Si la piece i est sur la même ligne que la balle
			else if (indexOfAllPieces[i] % sideSize == oldBallIndex % sideSize) {
				//printf("Ligne :\n");

				// Si la piece i est à droite de la balle
				if (indexDifference > 0) {
					//printf("\tà droite :\n");
					for (int j = oldBallIndex + sideSize; j != indexOfAllPieces[i]; j = j - sideSize) {
						if (tiles[j] != (int)DefTiles) {
							validation = false;
							break;
						}
					}
				}

				// Si la piece i est à gauche de la balle
				if (indexDifference < 0) {
					//printf("\tà gauche :\n");
					for (int j = oldBallIndex - sideSize ; j != indexOfAllPieces[i]; j = j - sideSize) {
						if (tiles[j] != (int)DefTiles) {
							validation = false;
							break;
						}
					}
				}
			}

			// Si la piece i est sur la diagonale HautGauche -> BasDroit
			else if (indexOfAllPieces[i] % (sideSize + 1) == oldBallIndex % (sideSize + 1)) {
				//printf("Diagonale HautGauche - BasDroit :\n");

				// Si la piece i est sur en bas a droite de la balle
				if (indexDifference > 0) {
					//printf("\tDiagonale BasDroit :\n");
					for (int j = oldBallIndex + sideSize + 1; j != indexOfAllPieces[i]; j = j + sideSize + 1) {
						if (tiles[j] != (int)DefTiles) {
							validation = false;
							break;
						}
					}
				}

				// Si la piece i est en haut à gauche de la balle
				if (indexDifference < 0) {
					//printf("\tDiagonale HautGauche :\n");
					for (int j = oldBallIndex - sideSize - 1; j != indexOfAllPieces[i]; j = j - sideSize - 1) {
						if (tiles[j] != (int)DefTiles) {
							validation = false;
							break;
						}
					}
				}
			}

			// Si la piece i est sur la diagonale BasGauche -> HautDroit
			else if (indexOfAllPieces[i] % (sideSize - 1) == oldBallIndex % (sideSize - 1)) {
				//printf("Diagonale BasGauche - HautDroit :\n");
				// Si la piece i est sur en haut a droite de la balle
				if (indexDifference > 0) {
					//printf("\tDiagonale HautDroit :\n");
					for (int j = oldBallIndex + sideSize - 1; j != indexOfAllPieces[i]; j = j + sideSize - 1) {
						if (tiles[j] != (int)DefTiles) {
							validation = false;
							break;
						}
					}
				}

				// Si la piece i est en bas à gauche de la balle
				if (indexDifference < 0) {
					//printf("\tDiagonale BasGauche\n");
					for (int j = oldBallIndex - sideSize + 1; j != indexOfAllPieces[i]; j = j - sideSize + 1) {
						if (tiles[j] != (int)DefTiles) {
							validation = false;
							break;
						}
					}
				}
			}

			if (validation == true) {
				indexOfPossibleMoves.push_back(indexOfAllPieces[i]);
			}
		}

		/*printf("Liste des MoveBall possible :\n");
		for (int i : indexOfPossibleMoves) {
			printf("\t (%i, %i) --> (%i, %i) \n", (int)oldBallIndex / sideSize, oldBallIndex % sideSize, i / sideSize, i % sideSize);
		}*/

		if (indexOfPossibleMoves.size() == 0) return -1; // Dans le cas où il est impossible de déplacer la balle
		
		int randomSelection = (rand() % (int) indexOfPossibleMoves.size()); // Selection Random du nouvel index de la balle parmi les possibles
		return indexOfPossibleMoves[randomSelection];
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

	int* GetAllPieceIndex(const Tiles*& tiles, const int& nbTiles) {
		int* res = new int[(int) sqrt(nbTiles) -1];
		int count = 0;
		for (int i = 0; i < nbTiles; i++) {
			if (tiles[i] == (int) PiecePlayer1) {
				res[count] = i;
				count++;
			}
		}
		return res;
	}

	int GetPieceIndex(const Tiles*& tiles, const int& nbTiles, const int& pieceID) {
		int pieceCount = 0 , res;
		for (int i = 0; i < nbTiles; i++) {
			if (tiles[i] == (int) PiecePlayer1) {
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
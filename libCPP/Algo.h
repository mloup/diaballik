#pragma once

#define EXPORTCDECL extern "C" __declspec(dllexport)

enum EnumCommand
{
	MovePiece = 0,
	MoveBall = 1,
	EndTurn = 2
};

enum Tiles
{
	DefTiles = 0,
	PiecePlayer0 = 1,
	BallPlayer0 = 2,
	PiecePlayer1 = 3,
	BallPlayer1 = 4,
};

using namespace std;
namespace Strategy {

	EXPORTCDECL int&  Algo_doActionNoobStrategy(const Tiles* tiles, const int  nbTiles);
	//EXPORTCDECL void doActionStartingStrategy(Tiles* tiles, int size, EnumCommand returnedMove[], int prevX[], int prevY[], int nextX[], int nextY[]);
	//EXPORTCDECL void doActionProgressiveStrategy(Tiles** tiles, int size, EnumCommand returnedMove[], int prevX[], int prevY[], int nextX[], int nextY[]);

	void MovePieceNoobStrategy(const Tiles*& tiles, const int& nbTiles, int*& actionResult);
	void MoveBallNoobStrategy(const Tiles*& tiles, const int& nbTiles, int*& actionResult);

	int GetRandomMoveAmongPossible(const Tiles*(&tiles), const int& sideSize, int& const indexOfPieceToMove);
	int GetBallIndex(const Tiles*& tiles, const int& nbTiles);
	int GetPieceIndex(const Tiles*& tiles, const int& nbTiles, const int& pieceID);
};

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

	EXPORTCDECL int&  Algo_doActionNoobStrategy(Tiles* tiles, int size);
	EXPORTCDECL void doActionStartingStrategy(Tiles* tiles, int size, EnumCommand returnedMove[], int prevX[], int prevY[], int nextX[], int nextY[]);
	EXPORTCDECL void doActionProgressiveStrategy(Tiles** tiles, int size, EnumCommand returnedMove[], int prevX[], int prevY[], int nextX[], int nextY[]);

	void MovePieceNoobStrategy(Tiles* tiles, int size, int*& tab);
	int GetRandomMoveAmongPossible(Tiles*(&tiles), int& sideSize, int& const indexOfMyPieceToMove);
};

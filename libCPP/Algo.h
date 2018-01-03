#pragma once

#define EXPORTCDECL extern "C" __declspec(dllexport)

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

	EXPORTCDECL int&  Algo_MovePieceNoobStrategy(const Tiles* tiles, const int nbTiles);
	EXPORTCDECL int&  Algo_MoveBallNoobStrategy(const Tiles* tiles, const int nbTiles);

	int GetRandomMovePieceAmongPossible(const Tiles*(&tiles), const int& sideSize, const int& indexOfPieceToMove);
	int GetRandomMoveBallAmongPossible(const Tiles*(&tiles), const int& sideSize, const int& indexOfPieceToMove);
	int GetBallIndex(const Tiles*& tiles, const int& nbTiles);
	int GetPieceIndex(const Tiles*& tiles, const int& nbTiles, const int& pieceID);
	int* GetAllPieceIndex(const Tiles*& tiles, const int& nbTiles);
};

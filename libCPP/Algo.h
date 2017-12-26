#pragma once

enum Command
{
	Default = 0,
	MovePiece = 1,
	MoveBall = 2,
	DoNothing = 3
};

enum Tiles
{
	DefTiles = 0,
	PiecePlayer0 = 1,
	BallPlayer0 = 2,
	PiecePlayer1 = 3,
	BallPlayer1 = 4,
};

class Algo {

public:
	Algo() {}
	~Algo() {}

	// You can change the return type and the parameters according to your needs.
	void Algo::doActionNoobStrategy(Tiles** tiles, int size, Command returnedMove[], int returnedAttr[]);
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algo_doActionNoobStrategy(Algo* algo, Tiles** tiles, int size,  Command returnedMove[], int returnedAttr[]) {
	return algo->doActionNoobStrategy(tiles, size, returnedMove, returnedAttr);
}

EXPORTCDECL Algo* Algo_new() {
	return new Algo();
}

EXPORTCDECL void Algo_delete(Algo* algo) {
	delete algo;
}

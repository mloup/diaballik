#pragma once

enum Action {
	MovePiece = 0,
	MoveBall = 1,
	DoNothing = 2
};

class Algo {

public:
	Algo() {}
	~Algo() {}

	// You can change the return type and the parameters according to your needs.
	void Algo::doActionNoobStrategy(int piecesPlayer0[], int piecesPlayer1[], int ballPlayer0[], int ballPlayer1[], Action returnedMove[], int returnedAttr[]);
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algo_doActionNoobStrategy(Algo* algo, int piecesPlayer0[], int piecesPlayer1[], int ballPlayer0[], int ballPlayer1[], Action returnedMove[], int returnedAttr[]) {
	return algo->doActionNoobStrategy(piecesPlayer0, piecesPlayer1, ballPlayer0, ballPlayer1, returnedMove, returnedAttr);
}

EXPORTCDECL Algo* Algo_new() {
	return new Algo();
}

EXPORTCDECL void Algo_delete(Algo* algo) {
	delete algo;
}

#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <stdio.h>


using namespace std;



void Algo::doActionNoobStrategy(Tiles** tiles, int size, Command* returnedMove, int* returnedAttr)
{
	// analyze some stuff
	// TODO
	printf("test1\n");

	//printf("%i\n", tiles[0][0]);
	/*
	for (int i = 0; i < size ; i++) {
		for (int j = 0; j < size; j++) {
			printf("%i\n", tiles[i][j]);
		}
	}*/
	printf("test2\n");
	// Paramètre de retour
	returnedMove[0] = MovePiece;
	returnedAttr[0] = 1;
	returnedAttr[1] = 1;
	returnedAttr[2] = 1;
	returnedAttr[3] = 1;
}
#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <stdio.h>
#include <time.h>
#include <math.h> 


using namespace std;



void Algo::doActionNoobStrategy(Tiles** tiles, int size, EnumCommand returnedMove[], int prevX[], int prevY[], int nextX[], int nextY[])
{
	returnedMove[0] = MovePiece;
	prevX[0] = 0;
	prevY[1] = 0;
	nextX[2] = 0;
	nextY[3] = 1;
}
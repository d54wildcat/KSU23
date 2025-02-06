//YOU DO THIS

//define the prototypes for the queue functions
//use a ifndef/define structure
#ifndef QUEUE_H
#define QUEUE_H

#include "types.h"

void enqueue(WORD* word, NODE** headptr, NODE** tailptr);

WORD* dequeue(NODE** headptr, NODE** tailptr);

#endif
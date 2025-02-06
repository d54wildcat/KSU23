#include <stdlib.h>
#include "types.h"
#include "queue.h"


void enqueue(WORD* w, NODE** headptr, NODE** tailptr)
{
    //YOU DO THIS
    //allocate memory for a new NODE that holds w
    //add it to the end of your queue, updating
    //*headptr and *tailptr
    NODE* newNode = (NODE*)malloc(sizeof(NODE));
    newNode->data = w;
    newNode->next = NULL;
    if (*headptr == NULL) {
        *headptr = newNode;
        *tailptr = newNode;
    }
    else {
        (*tailptr)->next = newNode;
        *tailptr = newNode;
    }

}

//The dequeue function is done
WORD* dequeue(NODE** headptr, NODE** tailptr)
{
    NODE* temp = *headptr;
    WORD* data = temp->data;
    *headptr = temp->next;
    free(temp);

    if (*headptr == NULL) {
        *tailptr = NULL;
    }
    return data;
}
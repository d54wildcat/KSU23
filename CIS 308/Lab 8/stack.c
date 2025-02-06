#include <stdlib.h>
#include "stack.h"


//YOU DO THIS
//Implement the push and pop functions
//(given the prototypes in stack.h)
void push(char c, struct node** topPtr){
    struct node* temp = malloc(sizeof(struct node));
    temp->letter = c;
    temp->next = *topPtr;
    *topPtr = temp;
}

char pop(struct node** topPtr){
    struct node* temp = *topPtr;
    char c = temp->letter;
    *topPtr = temp->next;
    free(temp);
    return c;
}

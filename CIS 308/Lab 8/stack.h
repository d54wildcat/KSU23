#ifndef STACK_H
#define STACK_H

//represents one node on the stack
struct node {
    char letter;        //the data in the current node
    struct node* next;  //a pointer to the next node on the stack
};

//push c onto the top of the stack
//update topPtr to be the new top
void push(char c, struct node** topPtr);

//pop the top character off the stack and return it
//update topPtr to be the new top
char pop(struct node** topPtr);

#endif

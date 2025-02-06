/*
* Name: Dacey Wieland
* Lab: Tuesday
* Assignment: Project 4 – expression trees
*
* This creates the functions for stacks tree and char
*/
#include <stdlib.h>
#include "stack.h"
#include "types.h"

/*
 * initializes and creates and returns a new stack object that can hold trees
 *
 * returns: the new stack object
 */
STACK* init_treestack(void) {
    STACK* s = malloc(sizeof(STACK));
    s->top = NULL;
    s->datatype = treetype;

    return s;
}
/*
 * initializes and creates and returns a new stack object that can hold chars
 *
 * returns: the new stack object
 */
STACK* init_charstack(void) {
    STACK* s = malloc(sizeof(STACK));
    s->top = NULL;
    s->datatype = chartype;

    return s;
}
/*
 * adds a value to the top of the given stack
 *
 * s: the stack to push onto
 * d: the data (a TREE) to push
 */
void push_tree(STACK* s, TNODE* d) {
    SNODE* newnode = malloc(sizeof(SNODE));
    newnode->data.treedata = d;
    newnode->next = s->top;
    s->top = newnode;
}
/*
 * adds a value to the top of the given stack
 *
 * s: the stack to push onto
 * c: the data (a char) to push
 */
void push_char(STACK* s, char c) {
    SNODE* newnode = malloc(sizeof(SNODE));
    newnode->data.chardata = c;
    newnode->next = s->top;
    s->top = newnode;
}
/*
 * removes and returns the top value (tree) on the given stack. assuming the
 * stack has at least one node.
 *
 * s: the stack to pop
 * returns: the TREE that was on the top of stack s
 */
TNODE* pop_tree(STACK* s) {
    SNODE* temp = s->top;
    TNODE* data = temp->data.treedata;
    s->top = temp->next;
    free(temp);

    return data;
}
/*
 * removes and returns the top value (char) on the given stack. assuming the
 * stack has at least one node.
 *
 * s: the stack to pop
 * returns: the char that was on the top of stack s
 */
char pop_char(STACK* s) {
    SNODE* temp = s->top;
    char data = temp->data.chardata;
    s->top = temp->next;
    free(temp);

    return data;
}
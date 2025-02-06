
#ifndef STACK_H
#define STACK_H

#include "types.h"

/*
 * init_treestack creates and returns a new stack object that can hold trees
 *
 * returns: the new stack object
 */
STACK* init_treestack(void);

/*
 * init_charstack creates and returns a new stack object that can hold chars
 *
 * returns: the new stack object
 */
STACK* init_charstack(void);

/*
 * Push adds a value to the top of the given stack
 *
 * s: the stack to push onto
 * d: the data (a TREE) to push
 */
void push_tree(STACK* s, TNODE* d);

/*
 * Push adds a value to the top of the given stack
 *
 * s: the stack to push onto
 * c: the data (a char) to push
 */
void push_char(STACK* s, char c);

/*
 * Pop removes and returns the top value (tree) on the given stack. It assumes the 
 * stack has at least one node.
 *
 * s: the stack to pop
 * returns: the TREE that was on the top of stack s
 */
TNODE* pop_tree(STACK* s);

/*
 * Pop removes and returns the top value (char) on the given stack. It assumes the 
 * stack has at least one node.
 *
 * s: the stack to pop
 * returns: the char that was on the top of stack s
 */
char pop_char(STACK* s);

//shouldn't need a free function for our purposes -
//all nodes will be popped off our stack (and pop frees them)

#endif 
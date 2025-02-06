
//THIS FILE IS COMPLETE

#ifndef LIST_H
#define LIST_H

#include "types.h"

/*
 * init_list creates and returns a new LIST object.
 *
 * returns: the new list object
 */
LIST* init_list(void);

/*
 * Add adds a new OPERAND with the given name to the list 
 * if it isn't already there
 *
 * list: the list to add to
 * n: the name of the variable ("x", "y", etc.)
 * 
 * returns: a OPERAND with "n" as its name field
 *      If "n" is already the name of a variable in the list,
 *      this function returns the existing OPERAND with that name and does NOT add to the list.
 *      If "n" is NOT the name of an existing variable in the list,
 *      this function creates and returns a VAR with that name (and also adds it
 *      to the end of the list).
 */
OPERAND* add(LIST* list, char n);

/*
 * set_variables initializes the values for each variable name in
 * list, based on user input
 * 
 * list: the list of variables
 */
void set_variables(LIST* list);

#endif
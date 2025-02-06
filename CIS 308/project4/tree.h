
//THIS FILE IS COMPLETE

#ifndef TREE_H
#define TREE_H

#include "types.h"
#include "list.h"


/*
 * parse_expr creates and returns a new expression tree out of the
 * given arithmetic expression
*/
EXPR_TREE* parse_expr(char* expr);

/*
 * inorder does an inorder traversal on the given tree, using the
 * numerical value for each variable,
 * and writes the traversal in the given buffer.
 * 
 * tree: the expression tree to traverse
 * buffer: where the traversal will be written
 */
void inorder(EXPR_TREE* tree, char* buffer);

/*
 * create_singleton creates a new singleton (no children) TNODE
 * to hold a VAR
 * 
 * v: the VAR (variable)
 * returns: a new TNODE object holding v (with no children)
 */
TNODE* create_singleton(OPERAND* v);

/*
 * build_tree creates a non-leaf tree with the given
 * operator and left/right subtrees
 * 
 * oper: the operator to be stored as the data for the new tree
 * l: the left subtree for the new tree
 * r: the right subtree for the new tree
 * returns: the newly created TNODE object holding oper, l, and r
 */
TNODE* build_tree(OPERATOR oper, TNODE* l, TNODE* r);

/*
 * evaluate returns the evaluation of the expression
 * represented by the given expression tree (using the current
 * values for each variable OPERAND)
 * 
 * tree: the expression tree to evalute
 * returns: the evaluation of tree
 */
int evaluate(EXPR_TREE* tree);

/*
 * free_tnode releases all the memory allocated
 * for the given tree node (including recursively freeing
 * its children)
 * 
 * t: the expression tree node to free
 */
void free_tnode(TNODE* t);

/*
 * free_tree releases all the memory allocated
 * for the given tree.
 * 
 * t: the expression tree to free
 */
void free_tree(EXPR_TREE* t);

#endif
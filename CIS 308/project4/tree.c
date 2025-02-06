/*
* Name: Dacey Wieland
* Lab: Tuesday
* Assignment: Project 4 – expression trees
*
* This file implements all of the tree functions.
*/
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "types.h"
#include "tree.h"
#include "list.h"
#include "stack.h"

//You are encouraged to add extra helper functions here, such
//as turning a char into an OP (and vice versa),
//seeing if a char is an operator, finding the priority
//of an operator, and applying an operator to two values

/*
 * this function checks to see if a character is an operator
 *
 * returns: true if the character is an operator
 */
BOOL is_operator(char c){
    if(c=='+' || c=='-' || c=='*' || c=='/'){
        return true;
    }
    else{
        return false;
    }
}
/*
 * returns a number associated with the priority of the oeprator
 *
 * returns: the priority int of the operator
 */
int operator_priority(char c){
    if(c=='(') return 0;
    else if(c=='+' || c=='-') return 1;
    else if(c=='*' || c=='/') return 2;
    else return 3;
}
/*
 * This returns the operator based on the char
 *
 * returns: the char's operator
 */
OPERATOR find_op(char c){
    if(c=='+') return PLUS;
    else if(c=='-') return MINUS;
    else if(c=='*') return TIMES;
    else return DIVIDE;

}
/*
 * This function creates and returns a new expression tree out of the
 * user inputted arithmetic expression
*/
EXPR_TREE* parse_expr(char* expr) {
    //YOU DO THIS

    //Finish the implementation of the algorithm
    //to construct an expression tree from a expression

    //list of operands seen in the expression
    LIST* operands = init_list();

    //stack of temporary trees
    STACK* treestack = init_treestack();

    //stack of characters that still needs to be processed
    STACK* charstack = init_charstack();

    //get the first token
    char* piece = strtok(expr, " ");

    //while there are more tokens in the expression
    while (piece != NULL) {
        //process piece -- it will be either (, ), +, -, *, /, or an operand

        //update treestack and/or charstack as needed

        //update operands (the list of operands) as needed
        if(*piece=='('){
            push_char(charstack, *piece);
        }
        else if (is_operator(*piece)==true){
            while(charstack->top!=NULL && (operator_priority(charstack->top->data.chardata)>=operator_priority(*piece))){
                char op = pop_char(charstack);
                TNODE* tree1 = pop_tree(treestack);
                TNODE* tree2 = pop_tree(treestack);
                TNODE* newTree = malloc(sizeof(TNODE));
                newTree->data.operator=(find_op(op));
                newTree->right = tree1;
                newTree->left = tree2;
                newTree->isleaf=false;
                push_tree(treestack, newTree);
            }
            push_char(charstack, *piece);

        }
    
        else if (*piece == ')'){
            while(charstack->top!=NULL && (charstack->top->data.chardata!='(')){
                char op = pop_char(charstack);
                TNODE* tree1 = pop_tree(treestack);
                TNODE* tree2 = pop_tree(treestack);
                TNODE* newTree = malloc(sizeof(TNODE));
                newTree->right = tree1;
                newTree->left = tree2;
                newTree->isleaf=false;

                newTree->data.operator=(find_op(op));
                push_tree(treestack, newTree);
            }
            if(charstack->top!=NULL && charstack->top->data.chardata=='('){
                pop_char(charstack);
            }
        }

        else{
            OPERAND* newOp = malloc(sizeof(OPERAND));
            if(('a'<=(*piece)&&'z'>=(*piece))||('A'<=(*piece)&&'Z'>=(*piece))){
                newOp->isvar=true;
                newOp->name = *piece;
                newOp = add(operands, *piece);
            }
            else{
                newOp->isvar = false;
                newOp->value = atoi(piece);
            }
            TNODE* singleTree = create_singleton(newOp);
            push_tree(treestack, singleTree);
        }
        piece = strtok(NULL, " ");
    }
    //process the remaining items on the stacks as described in the project writeup
        while(charstack->top!=NULL && (charstack->top->data.chardata!='(')){
                char op = pop_char(charstack);
                TNODE* tree1 = pop_tree(treestack);
                TNODE* tree2 = pop_tree(treestack);
                TNODE* newTree = malloc(sizeof(TNODE));
                newTree->right = tree1;
                newTree->left = tree2;
                newTree->isleaf=false;

                newTree->data.operator=(find_op(op));
                push_tree(treestack, newTree);
        }

    //the last tree on treestack should be the overall tree

    //allocate memory for a new EXPR_TREE
    EXPR_TREE* exTree = malloc(sizeof(EXPR_TREE));
    //set its root to your "overall" tree (the last tree on treestack)
    exTree->root = pop_tree(treestack);
    //set its all_operands field to be your list of operands (operands)
    exTree->all_operands = operands;
    //return your EXPR_TREE
    return exTree;
}
/*
 * This creates a new singleton (no children) TNODE to hold a VAR
 *
 * v: the VAR (variable)
 * returns: a new TNODE object holding v (with no children)
 */
TNODE* create_singleton(OPERAND* v) {
    //YOU DO THIS

    //Create and return a new TNODE representing a leaf node
    //containing an operand (its data will be "v")
    TNODE* leaf = malloc(sizeof(TNODE));
    leaf->left=NULL;
    leaf->right=NULL;
    leaf->isleaf=true;
    leaf->data.var=v;
    return leaf;
}
/*
 * This creates a non-leaf tree with the given operator 
 * and left/right subtrees
 *
 * oper: the operator to be stored as the data for the new tree
 * l: the left subtree for the new tree
 * r: the right subtree for the new tree
 * returns: the newly created TNODE object holding oper, l, and r
 */
TNODE* build_tree(OPERATOR oper, TNODE* l, TNODE* r) {
    //YOU DO THIS

    TNODE* nonLeaf = malloc(sizeof(TNODE));
    nonLeaf->left=l;
    nonLeaf->right=r;
    nonLeaf->isleaf=false;
    nonLeaf->data.operator=oper;

    return nonLeaf;
}
/*
 * This function takes in a tree and evaluates the equation
 *
 * t: takes the pointer to the tree
 * returns: returns int of the evaluation
 */
int eval_expr(TNODE* t) {
    //YOU DO THIS

    if(t->isleaf==true){
        return t->data.var->value;
    }
    else{
        int right = eval_expr(t->right);
        int left = eval_expr(t->left);
        if(t->data.operator==PLUS){
            return left + right;
        }
        else if(t->data.operator==MINUS){
            return left - right;
        }
        else if(t->data.operator==TIMES){
            return left * right;
        }
        else{
            return left/right;
        }
    }
}
    
/*
 * This returns the evaluation of the expression
 * represented by the given expression tree (using the current
 * values for each variable OPERAND)
 *
 * tree: the expression tree to evalute
 * returns: the evaluation of tree
 */
int evaluate(EXPR_TREE* tree) {
    //THIS FUNCTION IS COMPLETE
    //(but it won't work until you write eval_expr)

    //calls the recursive evaluation function on the overall tree
    return eval_expr(tree->root);
}
/*
 * Function to traverses the node
 *
 * t: pointer to the tree node
 * buffer: pointer to a char for the buffer
 */
void inorder_tnode(TNODE* t, char* buffer) {
    //YOU DO THIS
    if(t->isleaf){
            int add = t->data.var->value;
            char string[20];
            sprintf(string, "%d", add);
            strcat(buffer, string);
       return;
    }
    else{
        //inorder traversal is left to right
        strcat(buffer, "(");
        inorder_tnode(t->left, buffer);
       if(t->data.operator==PLUS)strcat(buffer, "+");
           else if(t->data.operator==MINUS)strcat(buffer, "-");
       else if(t->data.operator==TIMES)strcat(buffer, "*");
       else if(t->data.operator==DIVIDE)strcat(buffer, "/");

        inorder_tnode(t->right, buffer);
        strcat(buffer, ")");

    }
}
/*
 * inorder does an inorder traversal on the given tree, using the
 * numerical value for each variable,
 * and writes the traversal in the given buffer.
 *
 * tree: the expression tree to traverse
 * buffer: where the traversal will be written
 */
void inorder(EXPR_TREE* tree, char* buffer) {
    //THIS FUNCTION IS COMPLETE
    //(but it won't work until you write inorder_tnode)

    buffer[0] = '\0';
    //calls the recursive inorder traversal function on the overall tree
    inorder_tnode(tree->root, buffer);
}
/*
 * frees the given tnode pointer
 *
 * t: the tree to free
 */
void free_tnode(TNODE* t) {
    //YOU DO THIS
    while(t->right !=NULL){
    free_tnode(t->right);
    }
    while(t->left!=NULL){
    free_tnode(t->left);
    }
    free(t);
    //Recursively free all the subtrees in t,
    //as well as t itself
}
/*
 * frees the given tree
 *
 * t: the tree to free
 */
void free_tree(EXPR_TREE* t) {
    //THIS FUNCTION IS COMPLETE
    //(but you will need to finish free_tnode for it to work)

    if (t->root != NULL) {
        free_tnode(t->root);
    }
    free(t);
}
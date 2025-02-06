
//THIS FILE IS COMPLETE


#ifndef TYPES_H
#define TYPES_H

/*
* BOOL defines a boolean (true/false) type
*/
typedef enum {false, true} BOOL;

/*
* OP defines a type for arithmetic operators
*/
typedef enum {PLUS, MINUS, TIMES, DIVIDE} OPERATOR;

/*
* OPERAND represents an operand (including
* its integer value, name and whether this operand
* is a variable [the isvar field])
*/
typedef struct {
    BOOL isvar;
    int value;
    char name;
} OPERAND;

/*
* LNODE represents a node in a list. The data field is type OPERAND.
*/
typedef struct lnode {
    OPERAND* data;
    struct lnode* next;
} LNODE;

/*
* LIST represents a list of type OPERAND. head and tail
* are the first and last nodes in the list, respectively. 
*/
typedef struct {
    LNODE* head;
    LNODE* tail;
} LIST;

/*
* TNODE represents a node in an expression tree. Each TNODE
* can either be a leaf node (which holds a OPERAND)
* or a non-leaf node (which holds an operator).
*
* NOTE: This is the type you'll be using to do all recursive processing
* on a tree. The following type, EXPR_TREE, is just to wrap together a 
* recursively defined tree (TNODE* root) with its list of operands.
*/
typedef struct tnode {
    union {
        OPERAND* var;
        OPERATOR operator;
    } data;
    BOOL isleaf;
    struct tnode* left;
    struct tnode* right;
} TNODE;

/*
* EXPR_TREE represents a parse tree, including its
* top-level node and a list of its operands
*/
typedef struct {
    TNODE* root;
    LIST* all_operands;
} EXPR_TREE;

/*
* SNODE represents a node in a stack. The data field is type TREE 
* (defined in tree.h).
*/
typedef struct snode {
    union {
        TNODE* treedata;
        char chardata;
    } data;

    struct snode* next;
} SNODE;

/*
* STACK represents a stack of type TREE. top is the first NODE
* (defined above) in the stack, and datatype is the type of data stored
* (either tree or char)
*/
typedef struct {
    SNODE* top;
    enum {treetype, chartype} datatype;
} STACK;

#endif
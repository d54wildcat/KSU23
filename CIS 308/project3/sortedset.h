/*
* Name: Dacey Wieland
* Lab: Tuesday
* Assignment: Project 3 – Set operations on a sorted doubly-linked list
*
* This is the header file for the sorted set. and contains the structs and functions for the sorted set.
*/
#ifndef SET_H
#define SET_H

/*
* Defines a node in a linked structure
*/
struct node {
    int data;
    struct node* next;
    struct node* prev;
};

/*
 * Defines a sorted set
*/
struct sortedset {
    struct node* head;
    struct node* tail;
};

/*
* Creates an empty, newly allocated, sorted set
* 
* Returns a dynamically allocated sorted set 
* (whose head and tail are NULL)
*/
struct sortedset* new_set(void);

/*
* Adds a new element to a sorted set. The new
* element is added in sorted order, and is NOT
* added if it already exists in the set.
*
* set: a sorted set
* item: an element to add
*/
void add(struct sortedset* set, int item);

/*
* Prints a sorted set in forward order
* (smallest to biggest)
*
* set: the sorted set to print
*/
void print_forward(struct sortedset* set);

/*
 * Prints a sorted set in backward order
 *
 * set: the sorted set to print
 * 
*/
void print_backward(struct sortedset* set);

/*
* Returns whether an element exists in a sorted set
*
* set: a sorted set
* item: the number to search for in the set
* 
* Returns 1 if elem exists in set, and returns 0 otherwise.
*/
int exists(struct sortedset* set, int item);

/*
* Finds the union between two sorted sets
*
* set1: the first sorted set
* set2: the second sorted set
* 
* Returns the (dynamically allocated) union of set1 and set2, 
* also as a sorted set.
*/
struct sortedset* find_union(struct sortedset* set1, struct sortedset* set2);

/*
* Finds the intersection between two sorted sets
*
* set1: the first sorted set
* set2: the second sorted set
* 
* Returns the (dynamically allocated) intersection of set1 and set2, 
* also as a sorted set.
*/
struct sortedset* find_inter(struct sortedset* set1, struct sortedset* set2);

/*
* Finds the difference between two sorted sets
*
* set1: the first sorted set
* set2: the second sorted set
* 
* Returns the (dynamically allocated) difference set1 - set2, 
* also as a sorted set.
*/
struct sortedset* find_diff(struct sortedset* set1, struct sortedset* set2);

/*
* Releases all memory for a sorted set (the individual
* nodes and the set itself).
*
* set: the set to free
*/
void free_set(struct sortedset* set);

#endif
/*
* Name: Dacey Wieland
* Lab: Tuesday
* Assignment: Project 3 – Set operations on a sorted doubly-linked list
*
* This has the implementation of the sortedset.h file. It has the functions for the sorted set.
*/
#include <stdio.h>
#include <stdlib.h>
#include "sortedset.h"

/*
* Creates an empty, newly allocated, sorted set
* 
* Returns a dynamically allocated sorted set 
* (whose head and tail are NULL)
*/
struct sortedset* new_set(void){
    struct sortedset* set = malloc(sizeof(struct sortedset));
    set->head = NULL;
    set->tail = NULL;
    return set;
}
/*
* Adds a new element to a sorted set. The new
* element is added in sorted order, and is NOT
* added if it already exists in the set.
*
* set: a sorted set
* item: an element to add
*/
void add(struct sortedset* set, int item){
    // Check if set is empty
    if (set->head == NULL) {
        struct node* new_node = malloc(sizeof(struct node));
        new_node->data = item;
        new_node->prev = NULL;
        new_node->next = NULL;
        set->head = new_node;
        set->tail = new_node;
        return;
    }

    // Traverse the set to find the correct position to insert the new element
    struct node* current_node = set->head;
    while (current_node != NULL) {
        if (item < current_node->data) {
            // Create a new node to hold the new element
            struct node* new_node = malloc(sizeof(struct node));
            new_node->data = item;
            new_node->prev = current_node->prev;
            new_node->next = current_node;
            
            if (current_node->prev != NULL) {
                current_node->prev->next = new_node;
            } else {
                set->head = new_node;
            }
            current_node->prev = new_node;
            return;
        } else if (item == current_node->data) {
            // Element already exists in the set, do not add it again
            return;
        }
        current_node = current_node->next;
    }

    // If the element is not found, add it to the end of the set
    struct node* new_node = malloc(sizeof(struct node));
    new_node->data = item;
    new_node->prev = set->tail;
    new_node->next = NULL;
    set->tail->next = new_node;
    set->tail = new_node;
}
/*
* Prints a sorted set in forward order
* (smallest to biggest)
*
* set: the sorted set to print
*/
void print_forward(struct sortedset* set){
    struct node* temp = set->head;
    while(temp != NULL){
        printf("%d ", temp->data);
        temp = temp->next;
    }
    printf("\n");
}
/*
 * Prints a sorted set in backward order
 *
 * set: the sorted set to print
 * 
*/
void print_backward(struct sortedset* set){
    struct node* temp = set->tail;
    while(temp != NULL){
        printf("%d ", temp->data);
        temp = temp->prev;
    }
    printf("\n");
}
/*
* Returns whether an element exists in a sorted set
*
* set: a sorted set
* item: the number to search for in the set
* 
* Returns 1 if elem exists in set, and returns 0 otherwise.
*/
int exists(struct sortedset* set, int item){
    struct node* temp = set->head;
    while(temp != NULL){
        if(temp->data == item){
            return 1;
        }
        temp = temp->next;
    }
    return 0;
}
/*
* Finds the union between two sorted sets
*
* set1: the first sorted set
* set2: the second sorted set
* 
* Returns the (dynamically allocated) union of set1 and set2, 
* also as a sorted set.
*/
struct sortedset* find_union(struct sortedset* set1, struct sortedset* set2){
    struct sortedset* set3 = new_set();
    struct node* temp1 = set1->head;
    struct node* temp2 = set2->head;
    while(temp1 != NULL){
        add(set3, temp1->data);
        temp1 = temp1->next;
    }
    while(temp2 != NULL){
        add(set3, temp2->data);
        temp2 = temp2->next;
    }
    return set3;
}
/*
* Finds the intersection between two sorted sets
*
* set1: the first sorted set
* set2: the second sorted set
* 
* Returns the (dynamically allocated) intersection of set1 and set2, 
* also as a sorted set.
*/
struct sortedset* find_inter(struct sortedset* set1, struct sortedset* set2){
    struct sortedset* set3 = new_set();
    struct node* temp1 = set1->head;
    while(temp1 != NULL){
        if(exists(set2, temp1->data)){
            add(set3, temp1->data);
        }
        temp1 = temp1->next;
    }
    return set3;
}
/*
* Finds the difference between two sorted sets
*
* set1: the first sorted set
* set2: the second sorted set
* 
* Returns the (dynamically allocated) difference set1 - set2, 
* also as a sorted set.
*/
struct sortedset* find_diff(struct sortedset* set1, struct sortedset* set2){
    struct sortedset* set3 = new_set();
    struct node* temp1 = set1->head;
    while(temp1 != NULL){
        if(!exists(set2, temp1->data)){
            add(set3, temp1->data);
        }
        temp1 = temp1->next;
    }
    return set3;
}
/*
* Releases all memory for a sorted set (the individual
* nodes and the set itself).
*
* set: the set to free
*/
void free_set(struct sortedset* set){
    struct node* temp = set->head;
    while(temp != NULL){
        struct node* temp2 = temp->next;
        free(temp);
        temp = temp2;
    }
    free(set);
}

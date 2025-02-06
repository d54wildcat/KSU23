#include <stdio.h>
#include <stdlib.h>
#include "linkedlist.h"

LIST* create_list(print_fn ptr, BOOL to_free) {
    //YOU DO THIS
    //Create and return a new LIST
    LIST* newlist = malloc(sizeof(LIST));
    
    //Initialize fields using the parameters
    //The head and tail should be set to NULL
    newlist->head = NULL;
    newlist->tail = NULL;
    newlist->fn = ptr;
    newlist->free_data = to_free;

    return newlist;
}

void add_to_end(LIST* list, void* elem) {
    //YOU DO THIS

    //Create a new node
    NODE* newnode = malloc(sizeof(NODE));
    //Set the new node's data and next (NULL)
    newnode->data = elem;
    newnode->next = NULL;
    //Update list->head and list->tail to add the new
    //node to the end of the list
    //if the list was empty (check its head), update the head and tail
        //to be the new node
    //otherwise, add the new node after the tail
        //and update the tail to be the new node
    if (list->head == NULL) {
        list->head = newnode;
        list->tail = newnode;
    } else {
        list->tail->next = newnode;
        list->tail = newnode;
    }
}

void free_list(LIST* list) {
    NODE* cur = list->head;
    while (cur != NULL) {
        NODE* after = cur->next;
        if (list->free_data) {
            free(cur->data);
        }
        free(cur);
        cur = after;
    }

    free(list);
}

void print_list(LIST* list) {
    //YOU DO THIS
    
    //suppose temp is a node and you want to print its data
    //list->fn(temp->data);
    
    
    //loop with a temp node to print the data
    //of every node in the list (use the list's fn field,
    //which is a pointer to the correct print function)
    NODE* temp = list->head;
    while (temp != NULL) {
        list->fn(temp->data);
        temp = temp->next;
    }
    printf("\n");
}

void print_int(void* i) {
    int elem = *((int*) i);
    printf("%d ", elem);
}

void print_string(void* s) {
    char* elem = (char*) s;
    printf("%s ", elem);
}

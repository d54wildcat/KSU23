#ifndef LINKEDLIST_H
#define LINKEDLIST_H

#include "type.h"
#include <stddef.h>

typedef void (*print_fn) (void*);

typedef struct node {
    void* data;
    struct node* next;
} NODE;

typedef struct {
    NODE* head;
    NODE* tail;
    print_fn fn;
    BOOL free_data;
} LIST;

LIST* create_list(print_fn ptr, BOOL to_free);

void add_to_end(LIST* list, void* elem);

void free_list(LIST* list);

void print_list(LIST* list);

void print_int(void* i);

void print_string(void* s);

#endif

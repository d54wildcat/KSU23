//This file is complete

#ifndef TYPES_H
#define TYPES_H

//WORD represents a string with up to 30 character
typedef struct {
    char str[30];
} WORD;

//NODE represents a node in a queue
//Its data is a WORD and not a char* so that the data will
    //maintain its memory location even after the node is freed. 
typedef struct node {
    WORD* data;
    struct node* next;
} NODE;


#endif
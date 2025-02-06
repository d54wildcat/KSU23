/*
* Name: Dacey
* Lab: Tuesday
* Assignment: Project 4 – expression trees
*
* This implements the functions for a linked list of operands
*/
#include "types.h"
#include "list.h"
#include <stdlib.h>
#include <string.h>
#include <stdio.h>

/*
* Sets an initial list of size list to null.
*
* Returns the list of null values.
*/
LIST* init_list(void) {
    //THIS FUNCTION IS COMPLETE

    LIST* list = malloc(sizeof(LIST));
    list->head = NULL;
    list->tail = NULL;

    return list;
}
/*
* Checks if the list has a node whose data is type Operand, and if not
* Adds the node to the end of the list. 
*
* list: the list that we are checking and adding to.
* n: the character to check to see if the list already has.

* Returns the new OPERAND that we either added, or didn't change
*/
OPERAND* add(LIST* list, char n) {
    //YOU DO THIS

    //If list already has a node whose data
    //is a OPERAND* with name n, return that OPERAND*
    //and do not change the list
    if (list->head != NULL) {
        LNODE* temp = list->head;
        while (temp != list->tail) {
            if (temp->data->name == n) {
                return temp->data;
            }
            temp = temp->next;
        }
        if(temp==list->tail){
            if(temp->data->name == n){
                return temp->data;
            }
        }
    }
    //Otherwise, add a new node to the end of list
    //whose data is a OPERAND* with name n (set the value
    //of the var to 0 -- it will get changed elsewhere). Be
    //sure to set the isvar field for the new OPERAND to true.
    //Return the new OPERAND* you added.


        LNODE* newNode = malloc(sizeof(LNODE));
        newNode->data = malloc(sizeof(OPERAND));
        newNode->data->value = 0;
        newNode->data->isvar = true;
        newNode->data->name = n;
        newNode->next = NULL;
        if (list->head != NULL) {
            list->tail->next = newNode;
            list->tail = newNode;
        }
        else {
            list->head = newNode;
            list->tail = newNode;
        }
        return newNode->data;
    //remove the following return statement after you write the function
}
/*
* initilizes the values in each variable name in the list
* based on user input
*
* list: the list that we are initializing.
*/
void set_variables(LIST* list) {
    //YOU DO THIS

    LNODE* temp = list->head;
    if(list->head==list->tail){
        if(list->head->data->isvar==true){
            int response;
            printf("Enter a value for variable %c: ", list->head->data->name);
            scanf("%d", &response);
            list->head->data->value = response;
            //printf("%d", response);
        }
    }
    else{
        while(temp!=NULL){
            if(temp->data->isvar==true){
                printf("Enter a value for variable %c: ", temp->data->name);
                int response;
                scanf("%d", &response);
                temp->data->value = response;
                //printf("%d!!", response);
                temp=temp->next;
            }
        }

    }
}
/*
* frees all of the memory in the list that is given
*
* list: the list that we are freeing.
*/

void free_list(LIST* list) {
    //THIS FUNCTION IS COMPLETE

    LNODE* temp = list->head;

    while (temp != NULL) {
        LNODE* after = temp->next;
        free(temp->data);
        free(temp);
        temp = after;
    }
    free(list);
}
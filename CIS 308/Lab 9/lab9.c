#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "types.h"
#include "queue.h"

int main() {
    //creates heads/tails for queues holding words
    //with lengths from 0-29
    //head_length[i] is the head node of the queue with words that have length i
    //tail_length[i] is the tail node of the queue with words that have length i

    //(we assume our input file doesn't have words longer than 29 characters)
    NODE* head_length[30];
    NODE* tail_length[30];
    for (int i = 0; i < 30; i++) {
        head_length[i] = NULL;
        tail_length[i] = NULL;
    }

    //read input file, (shortwords.txt to start, then change to words.txt)
    FILE* fin = fopen("shortwords.txt", "r");
    if (fin != NULL) {
        char buff[30];
        while (fgets(buff, 30, fin) != NULL) {
            buff[strcspn(buff, "\n")] = '\0';

            //YOU DO THIS
            //get the length of buff (use strlen)
            //create a new WORD* that holds the letters in buff
            //enqueue your WORD* into the queue that matches its string length

            int length = strlen(buff);
            WORD* newWord = (WORD*)malloc(sizeof(WORD));
            strcpy(newWord->str, buff);
            enqueue(newWord, &head_length[length], &tail_length[length]);

        }
        fclose(fin);
    }
    else {
        printf("Error reading input file.\n");
    }

    //now dequeue and print everything to output file
    FILE* fout = fopen("bylength.txt", "w");
    if (fout != NULL) {
        //YOU DO THIS
        //loop through each queue (you have 30 of them)
            //for each one, dequeue until it is empty
            //dequeue will return a WORD*
            //print the str in the WORD* to fout (use fprintf)
            //free the memory for the WORD*

        for (int i = 0; i < 30; i++) {
            while (head_length[i] != NULL) {
                WORD* temp = dequeue(&head_length[i], &tail_length[i]);
                fprintf(fout, "%s\n", temp->str);
                free(temp);
            }
        }   
        fclose(fout);
    }
    else {
        printf("Error writing to output file.\n");
    }

    return 0;
}
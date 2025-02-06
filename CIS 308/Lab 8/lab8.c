#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "stack.h"

int main() {
    //YOU DO THIS

    //Declare a top struct node of the stack (initialize it to NULL)
    struct node *top = NULL;

    //Get an input word from the user
    char word[100];
    printf("Enter a word: ");
    fgets(word, 100, stdin);
    printf("Reversed: ");
    //Push each letter onto a stack
    for(int i = 0; i < strlen(word); i++){
        push(word[i], &top);
    }
    //Pop each letter off (printing as you go)
        //--> the original word should print in reverse order
    for(int i = 0; i < strlen(word); i++){
        printf("%c", pop(&top));
    }
    return 0;
}

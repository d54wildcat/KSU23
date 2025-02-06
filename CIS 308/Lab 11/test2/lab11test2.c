//YOU DO THIS
//include any necessary files
#include <stdio.h>
#include <string.h>
#include "macros.h"


//YOU DO THIS
//Define the size of a character buffer (30)
#define SIZE 30

int main() {
    //YOU DO THIS

    //Use fgets to get 2 names from the user and store them
    //in 2 character buffers (use your defined size everywhere instead of "30")
    char name1[SIZE];
    char name2[SIZE];
    printf("Enter first name: ");
    fgets(name1, SIZE, stdin);
    printf("Enter second name: ");
    fgets(name2, SIZE, stdin);

    //Use the STRIP macro to remove the \n from each name
    STRIP(name1);
    STRIP(name2);
    //Print both names to the screen as shown in the lab instructions
    printf("You entered: %s and %s\n\n", name1, name2);
    //(They should print without a \n)

    //Use the ROUND macro to print the following values:
    printf("Rounding test: \n");
    //ROUND(2.2)
    printf("ROUND(2.2) = %d\n", ROUND(2.2));
    //ROUND(2.7)
    printf("ROUND(2.2) = %d\n", ROUND(2.7));
    //ROUND(-2.2)
    printf("ROUND(2.2) = %d\n", ROUND(-2.2));
    //ROUND(-2.7)
    printf("ROUND(2.2) = %d\n", ROUND(-2.7));
    //ROUND(2.2-0.5)
    printf("ROUND(2.2-0.5) = %d\n", ROUND(2.2-0.5));

    return 0;
}


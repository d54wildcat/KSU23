//YOU DO THIS
//include any necessary files
#include <stdio.h>
#include "macros.h"

//YOU DO THIS
//Define the size of your array (3)
#define SIZE 3

int main() {
    //YOU DO THIS

    //make a size 3 array of doubles
    double array[SIZE];

    //get 3 numbers from the user and put them in your array
    //(Use your defined size everywhere instead of "3")
    for (int i = 0; i < SIZE; i++) {
        printf("Enter a number: ");
        scanf("%lf", &array[i]);
    }

    //For each number in the array, print its cube and its absolute value
    //(Use the CUBE and ABS macros)
    for (int i = 0; i < SIZE; i++) {
        printf("%.2lf cubed: %.2lf\n", array[i], CUBE(array[i]));
        printf("%.2lf absolute value: %.2lf\n\n", array[i], ABS(array[i]));
    }
    return 0;
}


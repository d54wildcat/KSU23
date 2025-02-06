#include <stdio.h>
#include "fraction.h"

int main() {
    //YOU DO THIS
    //Declare an array that can hold 5 struct fractions
    struct fraction fractions[5];

    printf("Enter 5 fractions (e.g.: 3/4):\n");

    for (int i = 0; i < 5; i++) {
        printf("Enter fraction (%d): ", (i+1));

        //YOU DO THIS
        //Use scanf to read the numerator and denominator into the current
        //struct fraction
        scanf("%d/%d", &fractions[i].num, &fractions[i].denom);
        //you can use "%d/%d" as your control string in scanf
    }
    //YOU DO THIS
    //Loop, calling plus each time, to add together all the fractions
    //in your array
    struct fraction result = fractions[0];
    for (int i = 1; i < 5; i++) {
        result = plus(result, fractions[i]);
    }
    printf("\nAll fractions added together: ");
    //YOU DO THIS
    //Call reduce to get your result reduced to lowest terms
    //Call printfraction to print your reduced result
    printfraction(reduce(result));
    return 0;
}
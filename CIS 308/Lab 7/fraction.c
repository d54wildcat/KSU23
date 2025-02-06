#include "fraction.h"
#include <stdio.h>

//YOU DO THIS
//Implement the plus function
//that is defined in fraction.h
struct fraction plus(struct fraction f1, struct fraction f2 )
{
    struct fraction result;
    result.num = f1.num * f2.denom + f2.num * f1.denom;
    result.denom = f1.denom * f2.denom;
    return result;   
}

//YOU DO THIS
//Implement the printfraction function
//that is defined in fraction.h
void printfraction(struct fraction f)
{
    printf("%d/%d", f.num, f.denom);
}
//The reduce function is complete
struct fraction reduce(struct fraction f) {
    struct fraction result = f;
    for (int i = 2; i <= f.num; i++) {
        while (result.num % i == 0 && result.denom % i == 0) {
            result.num /= i;
            result.denom /= i;
        }
    }

    return result;
}
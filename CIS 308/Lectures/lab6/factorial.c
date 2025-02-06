#include <stdio.h>

int main() {
    int prod = 0;

    for (int i = 1; i < 5; i++) {
        prod = prod * i;
    }

    printf("Product is: %d\n", prod);

    return 0;
}
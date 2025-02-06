#include <stdio.h>
#include <stdlib.h>

void printarray(int* nums, int len);

int main() {
    int* test = malloc(5*sizeof(int));
    
    for (int i = 0; i < 5; i++) {
        test[i] = i+1;
    }

    printarray(test, sizeof(test));

    free(test);

    return 0;
}

void printarray(int* nums, int len) {
    int* ptr = &nums;
    while (ptr < nums + len) {
        printf("%d\n", ptr);
        ptr = *ptr + 1;
    }
}
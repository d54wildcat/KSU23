#include <stdio.h>

int sum_array(int arr[]) {
    int sum = 0;
    for (int i = 0; i < sizeof(arr)/sizeof(int); i++) {
        sum = sum + arr[i];
    }

    return sum;
}

int main() {
    int test[] = {1,2,3,4};
    printf("Array sum from function: %d\n", sum_array(test));

    return 0;
}
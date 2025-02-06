#include <stdio.h>

int power(int base, int pow);

int main() {
    int base;;
    printf("Enter base: ");
    scanf("%d", &base);

    int pow;
    printf("Enter pow: ");
    scanf("%d", &pow);

    if (base < 0 || pow < 0) {
        printf("Invalid input: Number must be positive\n");
    }
    else {
        int answer = power(pow, base);
        printf("%d^%d = %d", base, pow, answer);
    }
    return 0;
    
}

int power(int pow, int base) {
    int result = base;
    while (pow != 1) {
        result *= base;
        pow--;
    }
    return result;
}
#include <stdio.h>

double area(double);

int main() {
    double rad;
    printf("Enter radius: ");
    scanf("%lf", &rad);

    double answer = area(rad);
    printf("The area is %.2lf\n", answer);

    return 0;
}

double area(double r) {
    return 3.14 * r * r;
}
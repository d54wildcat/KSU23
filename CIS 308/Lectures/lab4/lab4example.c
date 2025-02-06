#include <stdio.h>

void swap(int*, int*);

void print_array(int*, int);

int main() {
    int x = 4;
    int y = 3;
    swap(&x, &y);

    printf("x = %d, y = %d\n", x, y);

    int nums[] = {1,2,3,4,5,6,7,8,9,10};

    //call swap to swap the 2 and the 4
    swap(nums+1, nums+3);


    //call print_array
    print_array(nums, 10);

    return 0;
}

//will this work?
void swap(int* a, int* b) {
	int temp = *a;
	*a = *b;
	*b = temp;
}

void print_array(int* nums, int len) {
    //print array values using pointer notation
    for (int* cur = nums; cur < nums+len; cur++) {
        printf("%d ", *cur);
    }
}

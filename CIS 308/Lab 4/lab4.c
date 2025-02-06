#include <stdio.h>

void print_array(int* nums, int len);

void add_to_min(int* nums, int len);

void swap_before_after(int* ptr);

int main() {
    int test[] = {5,4,1,3,9,10,2};
    printf("Before min update: ");

    //YOU DO THIS
    //call print_array to print the test array
    print_array(test, 7);
    
    //call add_to_min to add 100 to the min value in test
    add_to_min(test, 7);

    printf("After min update: ");

    //call print_array to print the updated test array
    print_array(test, 7);
    
    //call swap_before_after to swap the values just before and just after
    //the "9" in test (note that the "9" is at index 4 in test)
    swap_before_after(&test[4]);
    
    printf("After swapping elements before and after the 9: ");
    
    //call print_array to print the updated test array
    print_array(test, 7);

    return 0;
}

//nums is an integer array with len elements
void add_to_min(int* nums, int len) {
    //YOU DO THIS
    int* cur = nums;
    int* min = nums;
    while (cur < nums + len) {
        if (*cur < *min) {
            min = cur;
        }
        cur++;
    }
    *min += 100;
    //declaring ONLY int* variables, find the minimum
    //value in the nums array and add 100 to its value
}

//ptr holds the memory address of an int
void swap_before_after(int* ptr) {
    //YOU DO THIS   
    int* before = ptr - 1;
    int* after = ptr + 1;
    int temp = *before;
    *before = *after;
    *after = temp;
    //Swap the ints in the memory locations just before ptr
    //and just after ptr
    
    //There is no restriction on what types of variables you can declare here
}

//this function is done
//prints all elements in the nums array
//(which has len elements)
void print_array(int* nums, int len) {
    int* cur = nums;
    while (cur < nums + len) {
        printf("%d ", *cur);
        cur++;
    }
    printf("\n\n");
}

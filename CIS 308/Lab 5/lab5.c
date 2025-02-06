#include <stdio.h>
#include <stdlib.h>

void merge(int* nums, int len1, int len2);

void printarray(int* list, int len);

int main() {
    //This function is finished, but you can
    //try modifying arr and the call to merge
    //to help test.

    int arr[] = {3,8,10,12,1,2,4,11,12,20};
    printf("Original array: ");
    printarray(arr, 10);

    merge(arr, 4, 6);

    printf("After merging: ");
    printarray(arr, 10);

    return 0;
}

void merge(int* nums, int len1, int len2) {
    //YOU DO THIS
    //nums is an array with total length len1+len2
    //The first len1 elements are in sorted order,
    //and the next len2 elements are in sorted order (within that section).

    //For example, nums might be: {3,8,10,12,1,2,4,11,12,20}
    //len1 might be 4 (the first 4 elements are sorted)
    //and len2 might be 6 (the next 6 elements are sorted among themselves)

    //This function should update nums to merge together the sorted sections
    //so that the entire array is sorted.

    //In our example, the function should update nums to be {1,2,3,4,8,10,11,12,12,20}


    //Create a temporary array to hold your merged result (use malloc to allocate it)
    int* temp = malloc(sizeof(int) * (len1 + len2));


    //Create three int pointers:
        //1) ptr1: points to the current element in the first section
        //2) ptr2: points to the current element in the second section
        //3) copyPtr: points to the next available position in your temporary array
        int *ptr1 = nums;
        int *ptr2 = nums + len1;
        int *copyPtr = temp;
        
    //While there are more elements in both sections (i.e., ptr1 and ptr2 are still valid):
        //Put the smaller value at the next position in copyPtr (which puts it in the temp array)
        //Update your pointer variables as necessary
        while (ptr1 < nums + len1 && ptr2 < nums + len1 + len2) {
            if (*ptr1 < *ptr2) {
                *copyPtr = *ptr1;
                ptr1++;
                copyPtr++;
            }
            else {
                *copyPtr = *ptr2;
                ptr2++;
                copyPtr++;
            }
        }

    //Copy any remaining elements from either section into your temporary array
        //(only 1 section will still have any values left, and they are already sorted)
        while (ptr1 < nums + len1) {
            *copyPtr = *ptr1;
            ptr1++;
            copyPtr++;
        }
        while (ptr2 < nums + len1 + len2) {
            *copyPtr = *ptr2;
            ptr2++;
            copyPtr++;
        }
    //Copy the (now sorted) values from your temp array back to nums
        copyPtr = temp;
        for (int i = 0; i < len1 + len2; i++) {
            nums[i] = *copyPtr;
            copyPtr++;
        }

    //free your temp array
    free(temp);
}

void printarray(int* list, int len) {
    //This function is finished

    int* temp = list;
    printf("\n");
    while (temp < list + len) {
        printf("%d ", *temp);
        temp++;
    }
    printf("\n\n");
}
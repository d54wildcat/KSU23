/*
*Name: Dacey Wieland
*Lab: Tuesday
*Assignment: Project 2 - Set Operations
*
*This programs reads in a file of sets and performs set operations on the sets.
*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/* Function prototypes */
int set_contains(int* set, int length, int num);
void print_set(int* set, int length);
int* set_union(int* set1, int len1, int* set2, int len2, int* result_len);
int* set_intersection(int* set1, int len1, int* set2, int len2, int* result_len);
int* set_difference(int* set1, int len1, int* set2, int len2, int* result_len);
/*
* Main Function
*/
int main(int argc, char** argv) 
{
    if (argc < 2) {
        printf("Missing input file as command line argument\n");
        return 1;
    }

    char* filename = argv[1];
    FILE* fp = fopen(filename, "r");

    if (!fp) {
        printf("Failed to open file: %s\n", filename);
        return 1;
    }

    // determine the number of sets
    int num_sets = 0;
    char c;

    while ((c = fgetc(fp)) != EOF) {
        if (c == '\n') {
            num_sets++;
        }
    }

    rewind(fp);

    // allocate memory dynamically for the sets and their lengths
    int** sets = calloc(num_sets, sizeof(int*));
    int* set_lengths = calloc(num_sets, sizeof(int));

    int set_idx = 0;
    char line[1024];
    num_sets = 0;
    int num;
    /* Skip first line */
    fgets(line, sizeof(line), fp);

    while (fgets(line, sizeof(line), fp)) {
    char* token = strtok(line, " ");
    int* set = calloc(1024, sizeof(int));
    int length = 0;

    while (token != NULL) {
        num = atoi(token);

        if (!set_contains(set, length, num)) {
            set[length] = num;
            length++;
        }

        token = strtok(NULL, " ");
    }

    sets[set_idx] = set;
    set_lengths[set_idx] = length;
    set_idx++;
}
num_sets = set_idx; 

    // perform set operations based on user input
    int set1_idx, set2_idx;
    int* result_set;
    int result_len;
    fclose(fp);
    for (int i = 0; i < num_sets; i++) {
        printf("Set (%d): ", i);
        print_set(sets[i], set_lengths[i]);
    }

    printf("Enter the index of the first set (between 0 and %d): ", num_sets);
    scanf("%d", &set1_idx);

    printf("Enter the index of the second set (between 0 and %d): ", num_sets);
    scanf("%d", &set2_idx);

    // find the union of the two sets
    result_set = set_union(sets[set1_idx], set_lengths[set1_idx], sets[set2_idx], set_lengths[set2_idx], &result_len);
    printf("Union: ");
    print_set(result_set, result_len);
    free(result_set);

    // find the intersection of the two sets
    result_set = set_intersection(sets[set1_idx], set_lengths[set1_idx], sets[set2_idx], set_lengths[set2_idx], &result_len);
    printf("Intersection: ");
    print_set(result_set, result_len);
    free(result_set);

    // find the difference of the two sets
    result_set = set_difference(sets[set1_idx], set_lengths[set1_idx], sets[set2_idx], set_lengths[set2_idx], &result_len);
    printf("Difference: ");
    print_set(result_set, result_len);

    // free the dynamically allocated memory
    free(result_set);
    free(set_lengths);
}
/*
*This function determines if a set contains a number.
*
*set: the set to search
*length: the length of the set
*num: the number to search for
*/
int set_contains(int* set, int length, int num)
{
    for (int i = 0; i < length; i++) {
        if (set[i] == num) {
            return 1;
        }
    }

    return 0;
}

/*
* This function prints a set 
*
* set: the set to print
* length: the length of the set
*/
void print_set(int* set, int length) {
    for (int i = 0; i < length; i++) {
        printf("%d ", set[i]);
    }

    printf("\n");
}

/*
*This function computes the union of two sets.
*
*set1: the first set
*len1: the length of the first set
*set2: the second set
*len2: the length of the second set
*result_len: the length of the result set
*/
int* set_union(int* set1, int len1, int* set2, int len2, int* result_len) {
    int* result = calloc(len1 + len2, sizeof(int));
    int idx = 0;

    for (int i = 0; i < len1; i++) {
        result[idx] = set1[i];
        idx++;
    }

    for (int i = 0; i < len2; i++) {
        if (!set_contains(set1, len1, set2[i])) {
            result[idx] = set2[i];
            idx++;
        }
    }

    *result_len = idx;
    return result;
}

/* 
*Computes the intersection of two sets 
*
*set1: the first set
*len1: the length of the first set
*set2: the second set
*len2: the length of the second set
*result_len: the length of the result set
*/
int* set_intersection(int* set1, int len1, int* set2, int len2, int* result_len) {
    int* result = calloc(len1 + len2, sizeof(int));
    int idx = 0;

    for (int i = 0; i < len1; i++) {
        if (set_contains(set2, len2, set1[i])) {
            result[idx] = set1[i];
            idx++;
        }
    }

    *result_len = idx;
    return result;
}

/* 
*Compute the difference of two sets 
*set1: the first set
*len1: the length of the first set
*set2: the second set
*len2: the length of the second set
*result_len: the length of the result set
*/
int* set_difference(int* set1, int len1, int* set2, int len2, int* result_len) {
    int* result = calloc(len1, sizeof(int));
    int idx = 0;

    for (int i = 0; i < len1; i++) {
        if (!set_contains(set2, len2, set1[i])) {
            result[idx] = set1[i];
            idx++;
        }
    }

    *result_len = idx;
    return result;
}

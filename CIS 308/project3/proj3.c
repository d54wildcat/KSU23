/*
* Name: Dacey Wieland
* Lab: Tuesday
* Assignment: Project 3 – Set operations on a sorted doubly-linked list
*
* Thus is the main function for the project. It reads in the files, and opens them. It also creates the sets, as well as gets the users input for the index of the set.
*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "sortedset.h"

int main(int argc, char* argv[]) {
    if (argc != 2) {
        printf("Missing input file as command line argument\n");
        return 1;
    }

    FILE* fp = fopen(argv[1], "r");
    if (!fp) {
        printf("Failed to open input file\n");
        return 1;
    }

    struct sortedset* sets[100];
    int set_idx = 0;
    int num;
    char line[1024];
    int line_num=0;

    while (fgets(line, sizeof(line), fp)) {
        if (line_num > 0) { // Skip first line
            struct sortedset* set = new_set();
            char* token = strtok(line, " ");

            while (token != NULL) {
                num = atoi(token);
                add(set, num);
                token = strtok(NULL, " ");
            }

            sets[set_idx] = set;
            set_idx++;
        }

        line_num++;
    }

    fclose(fp);

    for (int i = 0; i < set_idx; i++) {
        printf("Set (%d) Forward: ", i);
        print_forward(sets[i]);
        printf("Set (%d) Backward: ", i);
        print_backward(sets[i]);
        printf("\n");
    }
    int first_set_idx, second_set_idx;
    printf("Enter index of first set: ");
    scanf("%d", &first_set_idx);

    printf("Enter index of second set: ");
    scanf("%d", &second_set_idx);
    printf("\n");

    struct sortedset* union_set = find_union(sets[first_set_idx], sets[second_set_idx]);
    struct sortedset* inter_set = find_inter(sets[first_set_idx], sets[second_set_idx]);
    struct sortedset* diff_set = find_diff(sets[first_set_idx], sets[second_set_idx]);

    printf("Union Forward: ");
    print_forward(union_set);
    printf("Union Backword: ");
    print_backward(union_set);
    printf("\n");

    printf("Intersection Forward: ");
    print_forward(inter_set);
    printf("Intersection Backward: ");
    print_backward(inter_set);
    printf("\n");

    printf("Difference forward: ");
    print_forward(diff_set);
    printf("Difference Backward: ");
    print_backward(diff_set);
    printf("\n");

    free_set(union_set);
    free_set(inter_set);
    free_set(diff_set);

    for (int i = 0; i < set_idx; i++) {
        free_set(sets[i]);
    }

    return 0;
}

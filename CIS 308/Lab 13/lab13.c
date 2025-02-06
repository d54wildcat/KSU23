#include "type.h"
#include "pet.h"
#include "linkedlist.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

#define STRIP1(str) str[strcspn(str, "\n")] = '\0'
#define STRIP2(str) str[strcspn(str, "\r")] = '\0'

#define FLUSH(stream) while (fgetc(stream) != '\n');

int main() {
    FILE* fp = fopen("petfile.txt", "r");

    int numpets;

    char type[20];      //for holding "cat" or "dog"
    char name[30];      //for holding name from file
    char empty[5];      //for an empty line
    int weight;         //for holding weight from file
    char breed_or_env[50];  //for holding the breed (if dog) or environment (if cat)
    char pure_or_hair[30];  //for holding pure/mix (if dog) or hair type (if cat)

    fscanf(fp, "%d", &numpets);
    fgets(empty, 5, fp);

    //YOU DO THIS
    //Call create_list to create a linked list that can hold PET pointers
    //You DO want this list to free the memory for its data
    //Name your new list "petlist"
    LIST* petlist = create_list(print_pet, true);

    for (int i = 0; i < numpets; i++) {
        fgets(empty, 5, fp);

        fgets(type, 20, fp);
        STRIP1(type);
        STRIP2(type);

        fgets(name, 30, fp);
        STRIP1(name);
        STRIP2(name);

        fscanf(fp, "%d", &weight);
        fgets(empty, 5, fp);

        fgets(breed_or_env, 50, fp);
        STRIP1(breed_or_env);
        STRIP2(breed_or_env);

        fgets(pure_or_hair, 30, fp);
        STRIP1(pure_or_hair);
        STRIP2(pure_or_hair);

        PET* cur;
        if (get_type(type) == iscat) {
            cur = init_cat(name, weight, get_hair(pure_or_hair), get_env(breed_or_env));
        }
        else {
            //assume type is dog
            cur = init_dog(name, weight, breed_or_env, get_pure(pure_or_hair));
        }

        //YOU DO THIS
        //Add cur to the end of petlist
        add_to_end(petlist, cur);
    }

    fclose(fp);

    //YOU DO THIS
    //Print petlist (call print_list)
    print_list(petlist);
    //Free everything in petlist (call free_list)
    free_list(petlist);

    int test[] = {1,2,3,4,5};
    //YOU DO THIS
    //Call create_list to create a linked list that can hold int pointers
    //You do NOT want this list to free the memory for its data
    //Name your new list "intlist"
    LIST* intlist = create_list(print_int, false);

    //YOU DO THIS
    //Add each element in test to intlist
    for (int i = 0; i < 5; i++) {
        add_to_end(intlist, &test[i]);
    }

    //YOU DO THIS
    //Print intlist (call print_list)
    print_list(intlist);
    //Free everything in intlist (call free_list)
    free_list(intlist);


    //YOU DO THIS
    //Call create_list to create a linked list that can hold strings
    //You do NOT want this list to free the memory for its data
    //Name your new list "strlist"
    LIST* strlist = create_list(print_string, false);

    //YOU DO THIS
    //Add the following items to strlist: "apple", "banana", "carrot", "dragonfuit", "eggplant"
    char* str1 = "apple";
    char* str2 = "banana";
    char* str3 = "carrot";
    char* str4 = "dragonfruit";
    char* str5 = "eggplant";
    add_to_end(strlist, str1);
    add_to_end(strlist, str2);
    add_to_end(strlist, str3);
    add_to_end(strlist, str4);
    add_to_end(strlist, str5);

    //YOU DO THIS
    //Print strlist (call print_list)
    print_list(strlist);
    //Free everything in strlist (call free_list)
    free_list(strlist);

    return 0;
}

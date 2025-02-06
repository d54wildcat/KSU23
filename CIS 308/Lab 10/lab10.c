#include "pet.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main() {
    PET* petlist[4];

    //YOU DO THIS
    //Use init_cat and init_dog to initialize the petlist array
    petlist[0] = init_cat("Sophie", shorthair, indoor);
    petlist[1] = init_dog("Daisy", "German Shepherd", false);
    petlist[2] = init_cat("Marty", longhair, outdoor);
    petlist[3] = init_dog("Kiwi", "Corgi", true);

    //You should create and store the following pets:
        //position 0: Cat, Sophie, shorthair, indooor
        //position 1: Dog, Daisy, German Shepherd, mixed breed
        //position 2: Cat, Marty, longhair, outdoor
        //position 3: Dog, Kiwi, Corgi, purebred

    //loop to print the information for each pet
    //in the array (use print_pet)
    for(int i = 0; i < 4; i++){
        print_pet(petlist[i]);
    }

    //loop to free the memory for each pet (use free_pet)
    for(int i = 0; i < 4; i++){
        free_pet(petlist[i]);
    }

    return 0;
}
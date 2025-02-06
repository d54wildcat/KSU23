#include "pet.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

PET* init_cat(char* n, CAT_HAIR h, CAT_ENV en) {
    //YOU DO THIS

    //allocate space for a new pet that is a cat (use malloc)
    //initialize its fields appropriately using the parameters
    PET* newPet = malloc(sizeof(PET));
    strcpy(newPet->name, n);
    newPet->pettype = iscat;
    newPet->petInfo.catInfo.hair = h;
    newPet->petInfo.catInfo.env = en;
    //return the new pet 
    return newPet;
    //remove the following line when you are done:
}

PET* init_dog(char* n, char* b, BOOL pure) {
    //YOU DO THIS
    //allocate space for a new pet that is a dog (use malloc)
    PET* newPet = malloc(sizeof(PET));
    //initialize its fields appropriately using the parameters
    strcpy(newPet->name, n);
    newPet->pettype = isdog;
    strcpy(newPet->petInfo.dogInfo.breed, b);
    newPet->petInfo.dogInfo.purebred = pure;
    //return the new pet 
    return newPet;
}

void print_pet(PET* p) {
    //YOU DO THIS
    //print information about the given pet object

    //For a cat, it should print something like:
        //Sophie
        //Shorthair cat (indoor only)
    if(p->pettype == iscat){
        printf("Name: %s\n", p->name);
        if(p->petInfo.catInfo.hair == shorthair){
            printf("Shorthair cat");
        }else{
            printf("Longhair cat");
        }
        if(p->petInfo.catInfo.env == indoor){
            printf(" (indoor only)\n\n");
        }else{
            printf(" (outdoor only)\n\n");
        }
    }else{
        printf("Name: %s\n", p->name);
        printf("Breed: %s", p->petInfo.dogInfo.breed);
        if(p->petInfo.dogInfo.purebred == true){
            printf(" (purebred)\n\n");
        }else{
            printf(" (mixed breed)\n\n");
        }
    }
    //For a dog, it should print something like:
        //Kiwi
        //Corgi (purebred)
}

void free_pet(PET* p) {
    //This function is finished
    free(p);
}
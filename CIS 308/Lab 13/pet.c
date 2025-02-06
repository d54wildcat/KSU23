#include "pet.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

//assumes a correct ("long" or "short") value for n
CAT_HAIR get_hair(char* n) {
    if (strcmp(n, "long") == 0) return longhair;
    else return shorthair;
}

//assumes a correct ("indoor" or "outdoor") value for n
CAT_ENV get_env(char* n) {
    if (strcmp(n, "indoor") == 0) return indoor;
    else return outdoor; 
}

//assumes a correct ("pure" or "mix") value for n
BOOL get_pure(char* n) {
    if (strcmp(n, "pure") == 0) return true;
    else return false; 
}

//assumes a correct ("dog" or "cat") value for n
PET_CATEGORY get_type(char* n) {
    if (strcmp(n, "dog") == 0) return isdog;
    else return iscat; 
}

PET* init_cat(char* n, int w, CAT_HAIR h, CAT_ENV en) {
    PET* p = malloc(sizeof(PET));
    strcpy(p->name, n);
    p->weight = w;
    p->pettype = iscat;
    p->petdata.catdata.hair = h;
    p->petdata.catdata.env = en;

    return p;   
}

PET* init_dog(char* n, int w, char* b, BOOL pure) {
    PET* p = malloc(sizeof(PET));
    strcpy(p->name, n);
    p->weight = w;
    strcpy(p->petdata.dogdata.breed, b);
    p->pettype = isdog;
    p->petdata.dogdata.purebred = pure;

    return p;  
}

void print_pet(void* ptr) {
    PET* p = (PET*) ptr;

    printf("Name: %s\n", p->name);
    if (p->pettype == iscat) {
        if (p->petdata.catdata.hair == shorthair) {
            printf("Shorthair cat");
        }
        else {
            printf("Longhair cat");
        }
        if (p->petdata.catdata.env == indoor) {
            printf(" (indoor only)\n");
        }
        else if (p->petdata.catdata.env == outdoor) {
            printf(" (outdoor only)\n");
        }
        else {
            printf(" (indoor/outdoor)\n");
        }
    }
    else {
        printf("Breed: %s", p->petdata.dogdata.breed);

        if (p->petdata.dogdata.purebred) {
            printf(" (purebred)\n");
        }
        else {
            printf(" (mixed breed)\n");
        }
    }
    printf("\n");
}

void free_pet(PET* p) {
    free(p);
}

int filter_dogs(PET** allpets, PET** resultpets, int len) {
    int pos = 0;
    for (int i = 0; i < len; i++) {
        if (allpets[i]->pettype == isdog) {
            resultpets[pos] = allpets[i];
            pos++;
        }
    }

    return pos;
}

int filter_cats(PET** allpets, PET** resultpets, int len) {
    int pos = 0;
    for (int i = 0; i < len; i++) {
        if (allpets[i]->pettype == iscat) {
            resultpets[pos] = allpets[i];
            pos++;
        }
    }

    return pos;
}

int filter_small(PET** allpets, PET** resultpets, int len) {
    int pos = 0;
    for (int i = 0; i < len; i++) {
        if (allpets[i]->weight < 30) {
            resultpets[pos] = allpets[i];
            pos++;
        }
    }

    return pos;
}

int filter_indoor(PET** allpets, PET** resultpets, int len) {
    int pos = 0;
    for (int i = 0; i < len; i++) {
        if (allpets[i]->pettype == iscat && allpets[i]->petdata.catdata.env == indoor) {
            resultpets[pos] = allpets[i];
            pos++;
        }
    }

    return pos;
}
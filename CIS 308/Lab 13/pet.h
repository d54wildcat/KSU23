#ifndef PET_H
#define PET_H

#include "type.h"

typedef enum {longhair, shorthair} CAT_HAIR;

typedef enum {indoor, outdoor} CAT_ENV;

typedef enum {iscat, isdog} PET_CATEGORY;

typedef struct {
    char name[30];
    int weight;
    union {
        struct {
            CAT_HAIR hair;
            CAT_ENV env;
        } catdata;
        struct {
            char breed[50];
            BOOL purebred;
        } dogdata;
    } petdata;
    PET_CATEGORY pettype;
} PET;

CAT_HAIR get_hair(char* n);

CAT_ENV get_env(char* n);

BOOL get_pure(char* n);

PET_CATEGORY get_type(char* n);

PET* init_cat(char* n, int w, CAT_HAIR h, CAT_ENV en);

PET* init_dog(char* n, int w, char* b, BOOL pure);

void print_pet(void* p);

void free_pet(PET* p);

typedef int (*filter) (PET**, PET**, int);

int filter_dogs(PET** allpets, PET** resultpets, int len);

int filter_cats(PET** allpets, PET** resultpets, int len);

int filter_small(PET** allpets, PET** resultpets, int len);

int filter_indoor(PET** allpets, PET** resultpets, int len);

#endif
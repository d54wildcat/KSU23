#ifndef PET_H
#define PET_H

typedef enum {false, true} BOOL;

typedef enum {longhair, shorthair} CAT_HAIR;

typedef enum {indoor, outdoor} CAT_ENV;

typedef struct {
    //YOU DO THIS
    //Complete the PET definition

    //should have a name field (size-30 char array)
    char name[30];
    //should store EITHER cat data OR dog data (use a union)
    union {
        struct {
            CAT_HAIR hair;
            CAT_ENV env;
        } catInfo;
        struct {
            char breed[50];
            BOOL purebred;
        } dogInfo;
    } petInfo;
    //cats should have:
        //CAT_HAIR and CAT_ENV
    //dogs should have:
        //breed (use a size-50 char array)
        //whether they are purebred (use a BOOL)

    //also, create a new enum for the pettype
        //two possible values: iscat and isdog
    enum {iscat, isdog} pettype;
} PET;

PET* init_cat(char* n, CAT_HAIR h, CAT_ENV en);

PET* init_dog(char* n, char* b, BOOL pure);

void print_pet(PET* p);

void free_pet(PET* p);

#endif
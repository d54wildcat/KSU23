#ifndef FRACTION_H
#define FRACTION_H

/*
* represents a fraction with a numerator and denominator, like 3/4
* num: the fraction's numerator
* denom: the fraction's denominator
*/
struct fraction {
    int num;
    int denom;
};

/*
* Adds two fractions and returns a new fraction holding the sum
*
* f1: the first fraction to add
* f2: the second fraction to add
* returns: a new fraction holding the sum of f1 and f2
*/
struct fraction plus(struct fraction f1, struct fraction f2);

/*
* Prints a fraction to the console in the format "3/4"
*
* f: the fraction to print
*/
void printfraction(struct fraction f);

/*
* Calculates an equivalent fraction to the parameter that
* is reduced to lowest terms
*
* f: the fraction to reduce
* returns: a new fraction equivalent to f, but whose 
*    numerator and denominator are reduced to lowest terms
*/
struct fraction reduce(struct fraction f);

#endif
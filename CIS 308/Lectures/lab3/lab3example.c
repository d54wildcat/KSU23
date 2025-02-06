#include <stdio.h>
#include <string.h>

int main(int argc, char* argv[]) {
    //read each line with fgets

    //print the 1st arg, then current line, then 2nd arg
    char line[100];
    fgets(line, 100, stdin);
    printf("First line: %s\n", line);

    return 0;
}
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void parse_date(char date[], int pieces[]);
char* get_month(int m);


int main(int argc, char* argv[]) {
    //YOU DO THIS

    //Print an error and return 1 if the user did not supply command-line arguments
    if (argc != 3) {
        printf("Error: No command-line arguments supplied");
        return 1;
    }


    //open the specified input file (for reading)
    FILE* input = fopen(argv[1], "r");
    //open the specified output file (for writing)
    FILE* output = fopen(argv[2], "w");

    //loop to read each line in the input file (use fgets)
    char buffer[100];
    while (fgets(buffer, 100, input) != NULL){

        //call parse_date to parse the current line (which is a date)
            //(you'll need a size-3 int array to use as a parameter)
        int pieces[3];
        parse_date(buffer, pieces);
    
        //use get_month to get the month name, and copy it into an output string
            //(you'll need to create one -- size 30 is fine)
        char outputString[100];

        //concatenate the day value, comma + space, and year values onto your output string
        sprintf(outputString, "%s %d, %d", get_month(pieces[0]), pieces[1], pieces[2]);



        //use sprintf to convert the day and year to strings
        //print the formatted date (your output string) to the output file
        fprintf(output, "%s\n", outputString);


    //close your connections to both files
    }
    fclose(input);
    fclose(output);

    return 0;
}

/*
 * parse_date takes a date of the form monthNum/day/year, and
 * fills the given int array with each number in the date.
 * If date was "12/31/1999", then it would update pieces to be
 * {12, 31, 1999}.
 * 
 * date: a date of the form monthNum/day/year, like "12/31/1999"
 * pieces: must be a size-3 int array. parse_date will update pieces
 *      to hold the month, day, and year values from the date.
 */
void parse_date(char date[], int pieces[]) {
    //THIS FUNCTION IS FINISHED!

    pieces[0] = atoi(strtok(date, "/"));
    pieces[1] = atoi(strtok(NULL, "/"));
    pieces[2] = atoi(strtok(NULL, "/"));
}

/*
 * get_month returns the month name for the given month number
 * 
 * m: a month number (assumed to be 1-12)
 * returns: the name of the month with number m
 *  (e.g. if m is 1, it would return "January")
 */
char* get_month(int m) {
    //THIS FUNCTION IS FINISHED!

    switch(m) {
        case 1:
            return "January";
        case 2:
            return "February";
        case 3:
            return "March";
        case 4:
            return "April";
        case 5:
            return "May";
        case 6:
            return "June";
        case 7:
            return "July";
        case 8:
            return "August";
        case 9:
            return "September";
        case 10:
            return "October";
        case 11:
            return "November";
        default:
            return "December";    
    }
}

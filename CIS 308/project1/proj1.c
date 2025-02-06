/*
*Name: Dacey Wieland
*Lab: Section A Tuesday
* Assignment: Project 1 - String functions, file redaction
*
* This program reads in a text file, and a list of words from the user that they would like to redact,
* It then prints an output file with the words the user specified redacted.
*/
#include <stdio.h>

int main(int argc, char *argv[]) 
{
    int i, j, k, l, m, n, read_in_word_Count, read_in_line_Length, read_in_word_Length;
    char read_in_line[1000], read_in_word[1000];
    read_in_word_Count = argc - 1;
    while(fgets(read_in_line, 1000, stdin) != NULL){
        read_in_line_Length = str_length(read_in_line);
        i = 0;

        while(i < read_in_line_Length) 
        {
            j = next_alpha(read_in_line, i);
            k = next_non_alpha(read_in_line, j);
            read_in_word_Length = k - j;
            for(l = 0; l < read_in_word_Length; l++)
            {
                read_in_word[l] = read_in_line[j + l];
            }
            read_in_word[read_in_word_Length] = '\0';
            for(m = 1; m <= read_in_word_Count; m++)
            {
                if(str_equals(read_in_word, 0, read_in_word_Length, argv[m]))
                {
                    for(int z = 0; z < 3; z++)
                    {
                        printf("*");
                    }
                    break;
                }
            }
            if(m > read_in_word_Count)
            {
                for(n = 0; n < read_in_word_Length; n++)
                {
                    printf("%c", read_in_word[n]);
                }
            }
            if(read_in_line[k] == '.'){
                printf(".");
            }
            printf(" ");
            i = k;
        }
        printf("\n");    
    }
    return 0;
}
    /*
* Returns whether a character is an alphabet letter
*
* c: a character
* Returns 1 if c is an alphabet letter, and 0 otherwise
*/
int is_alpha(char c){
    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')){
        return 1;
    }
    return 0;
}

/*
* Returns the length of a string
*
* str: a string
* Returns the length of str
*/
int str_length(char str[]){
    int length = 0;
    for(int i = 0; str[i] != '\0'; i++){
        length++;
    }
    return length;
}
/*
* Gets the position of the first alphabet letter in a string
* from a given starting position.
*
* str: a string to search
* pos: a starting position in str
*
* Returns the position of the first alphabet letter in str
* starting from pos. If no such letter is found, it returns length of str.
*/
int next_alpha(char str[], int pos){
    for(int i = pos; i < str_length(str); i++){
        if (is_alpha(str[i])){
            return i;
        }
    }
}
/*
* Gets the position of the first non-alphabet letter in a string
* from a given starting position.
*
* str: a string to search
* pos: a starting position in str
*
* Returns the position of the first non-alphabet letter in str
* starting from pos. If no such letter is found, it returns length of str.
*/
int next_non_alpha(char str[], int pos){
    for(int i = pos; i < str_length(str); i++){
        if (!is_alpha(str[i])){
            return i;
        }
    }
    return str_length(str);
}
/*
* Returns whether a given substring in a bigger string equals
* a smaller string
*
* str: a big string
* start: a starting position within str (start should be < length of str)
* end: the position just after the end of a substring in str
* (end should be <= length of str)
* small: a smaller string (whose length is <= str's length)
*
* Returns 1 if the substring from str[start] to str[end-1] equals
* the letters in small, and returns 0 otherwise.
*/
int str_equals(char str[], int start, int end, char small[]){
    if(end - start != str_length(small)){
        return 0;
    }
    for(int i = 0; i < str_length(small); i++){
        if(str[start + i] != small[i]){
            return 0;
        }
    }
    return 1;
}

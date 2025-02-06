#include <stdio.h>
#include <string.h>

void substring(char str[], char sub[], int start, int len);

int main() 
{
    //get an input word from the user using fgets
    char str[20];
    printf("Enter string (up to 20 characters): ");
    fgets(str, 20, stdin);

    int len;
    printf("Enter substring length: ");
    scanf("%d", &len);
    char sub[100];
    int strlength = strlen(str) - len;

    for(int i = 0; i < strlength; i++)
    {
            substring(str, sub, i, len);
            printf("%s \n", sub);
        
    }
    return 0;
}

void substring(char str[], char sub[], int start, int len)
{
    int i;
    for (i = start; i < start + len; i++) {
        sub[i - start] = str[i];
    }
    sub[i - start] = '\0';
}
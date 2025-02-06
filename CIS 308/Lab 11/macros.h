//YOU DO THIS

/*
Write the following macros: 

CUBE(x) - should evaluate as the cube of x (a cube of a number is the number multiplied by itself 3 times -- so 2 cubed is 2*2*2)

STRIP(str) - updates the string str to remove the trailing \n (use strcspn to find a "\n", and replace that spot with a '\0')

ROUND(x) - should round x to the nearest whole number (e.g., ROUND(2.7) should evaluate to 3)

*/
#define CUBE(x) (x*x*x)
#define STRIP(str) (str[strcspn(str, "\n")] = '\0')
#define ABS(num) (num < 0 ? -num : num)
#define ROUND(x) (x < 0 ? (int)((x) - 0.5) : (int)((x) + 0.5))
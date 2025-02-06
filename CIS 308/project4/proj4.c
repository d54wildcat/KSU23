/*
* Name: Dacey Wieland
* Lab: Tuesday
* Assignment: Project 4 – expression trees
*
* This holds the main function
*/
#include <stdio.h>
#include "list.h"
#include <string.h>
#include "tree.h"

int main() {
    printf("Enter an expression: ");
    char buff[40];
    fgets(buff, 40, stdin);
    //Get an expression from the user, and call parse_expr to
    //turn it into an expression tree
    EXPR_TREE* expr_tree = parse_expr(buff);
    //Call set_variables to have the user pick values for each variable
    //in the expression
    //printf("to here?");
    set_variables(expr_tree->all_operands);
    //printf("after set variables");
    char print[40];
    inorder(expr_tree, print);
    //Call inorder and print the resulting buffer to display the
    //expression with those values plugged in for each variable
    printf("Substituting in: %s\n", print);
    //Evaluate your expression tree and print the result
    printf("Answer: %d", evaluate(expr_tree));
    free_list(expr_tree->all_operands);
    free_tree(expr_tree);
    return 0;
    return 0;
}

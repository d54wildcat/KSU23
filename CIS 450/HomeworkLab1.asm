.data
IntArray: .word 0x1, 0x2, 0x4, 0xFF, 0xFE, 0xFA, 0x7, 0x9, 0x8, 0xFD
size: .word 10
result: .space 4

.text
.globl main

main:
    lw $t0, size         # Load the number of elements in IntArray
    li $t1, 0            # Initialize a variable to store the greatest integer
    la $t2, IntArray     # Load the base address of the array
    lw $t3, 0($t2)       # Load the first element of the array

loop:
    beq $t0, $zero, done # If we have processed all elements, exit the loop
    bgt $t3, $t1, update_max  # If the current element is greater than the current maximum, update the maximum
    addi $t2, $t2, 4    # Move to the next element in the array
    lw $t3, 0($t2)       # Load the next element of the array
    sub $t0, $t0, 1     # Decrement the loop counter
    j loop

update_max:
    move $t1, $t3        # Update the maximum with the current element value
    j loop

done:
    sw $t1, result       # Store the greatest integer in the "result" memory location

    # Exit the program
    li $v0, 10
    syscall

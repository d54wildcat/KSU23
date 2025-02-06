.data
g: .word 4 #intiial value of variable g
h: .word 5 #intiial value of variable h
i: .word 1 #intiial value of variable i
j: .word 2 #intiial value of variable j
f: .space 4 #intiial value of variable f

.text
la $a0, g 		#loading in the value g
lw $a1, h		#loading in the value h
lw $a2, i		#loading in the value i
lw $a3, j		#loading in the value j
jal function

function:
addi $sp, $sp, -4	
sw $s0, 0($sp)
add $t0, $a0, $a1 	#adding g and h, storing in $t0
add $t1, $a2, $a3 	#adding i and h and storing in $t1
sub $s0, $t0, $t1 	#subtracting the two sums and storing in $s0
add $v0, $s0, $zero	#move the results to $v0
lw $s0, 0($sp)		#restore $s0
addi $sp, $sp, 4	#restore $sp
jr $ra

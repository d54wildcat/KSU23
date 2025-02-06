CC = gcc
CFLAGS = -g -Wall
EXE = lab13
HEADERS = type.h linkedlist.h pet.h
CODE = linkedlist.c pet.c lab13.c

OBJECTS = $(CODE:.c=.o)

lab13: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe *.out
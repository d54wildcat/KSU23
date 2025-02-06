CC = gcc
CFLAGS = -g -Wall
EXE = lab10
HEADERS = pet.h
CODE = pet.c lab10.c

OBJECTS = $(CODE:.c=.o)

lab9: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe* *.out bylength.txt
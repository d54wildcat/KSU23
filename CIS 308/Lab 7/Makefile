CC=gcc
CFLAGS=-g -Wall
EXE=lab7
HEADERS=fraction.h
CODE=fraction.c lab7.c

OBJECTS = $(CODE:.c=.o)

lab7: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe *.out
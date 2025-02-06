CC=gcc
CFLAGS=-g -Wall
EXE=lab8
HEADERS=stack.h
CODE=stack.c lab8.c

OBJECTS = $(CODE:.c=.o)

lab8: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe *.out
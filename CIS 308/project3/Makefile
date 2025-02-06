CC=gcc
CFLAGS=-g -Wall
EXE=proj3
HEADERS=sortedset.h
CODE=sortedset.c proj3.c

OBJECTS=$(CODE:.c=.o)

proj3: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe *.out  *stackdump
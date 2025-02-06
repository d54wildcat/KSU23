CC = gcc
CFLAGS = -g -Wall
EXE = lab9
HEADERS = types.h queue.h
CODE = queue.c lab9.c

OBJECTS = $(CODE:.c=.o)

lab9: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe *.out bylength.txt

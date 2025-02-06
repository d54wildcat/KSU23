CC = gcc
CFLAGS = -g -Wall
EXE = proj4
HEADERS = list.h stack.h tree.h types.h
CODE = list.c proj4.c stack.c tree.c

OBJECTS = $(CODE:.c=.o)

target: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe *.out
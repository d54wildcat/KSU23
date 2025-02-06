CC = gcc
CFLAGS = -g -Wall -I../
EXE = test2
HEADERS = ../macros.h
CODE = lab11test2.c

OBJECTS = $(CODE:.c=.o)

target: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe *.out
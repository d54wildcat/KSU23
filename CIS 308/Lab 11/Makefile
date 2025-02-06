CC = gcc
CFLAGS = -g -Wall -I../
EXE = lab11
HEADERS = ../macros.h
CODE = lab11test1.c

OBJECTS = $(CODE:.c=.o)

target: $(OBJECTS) $(HEADERS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(EXE)

clean:
	rm -f *.o *.exe *.out
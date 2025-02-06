

# Exercise: Multi-threaded Execution

## Tasks

The provided VS Solution `10-Multi-Threaded-RW` is a demo of a "text file"
that has its own controller and is shared by two threads, one which writes the
file and one that reads it.

Rebuild and run the demo.

Now, study its class diagram, and match the code to the diagram.
Notice how the `Reader`  interface limits the `ReaderForm`  to *only* the 
`readLine`  method  (similar for `WriterForm`).

Study the  `FileController`'s  code.

There are two problems with the code -- fix them:

1. It is possible for the `WriterForm` to open the file, and while writing, then
   the `ReaderForm`  opens the same file!
   Improve the `FileController` to enforce *exclusive access* of the file to one
   thread at a time.   (Use a state variable.)

2. It is possible for the `ReaderForm` and `WriterForm` to both ask to open the
   file at the same instant, like we saw in the "token race example".
   Insert lock(s) to prevent this.


## Submission

To submit, copy the folder containing this file to your local GitHub repository
for the course, and then commit and push your modified solutions to GitHub
(see the [course note on Git/GitHub](http://softwarearch.santoslab.org/01-tooling/index.html#git-github)).

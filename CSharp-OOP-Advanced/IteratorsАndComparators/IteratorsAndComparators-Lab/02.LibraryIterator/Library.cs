using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    private class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex;
        private List<Book> books;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < books?.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}


import React, { createContext, useState, useEffect, ReactNode } from 'react';
import {BookDto} from "../api/types.ts";
import {fetchBooks} from "../api/api.ts";

type BooksContextType = {
    books: BookDto[];
    setBooks: React.Dispatch<React.SetStateAction<BookDto[]>>;
};

export const BooksContext = createContext<BooksContextType>({
    books: [],
    setBooks: () => {}
});

export function BooksProvider({ children }: { children: ReactNode }) {
    const [books, setBooks] = useState<BookDto[]>([]);
    useEffect(() => {
        fetchBooks().then(setBooks).catch(console.error);
    }, []);
    return (
        <BooksContext.Provider value={{ books, setBooks }}>
            {children}
        </BooksContext.Provider>
    );
}

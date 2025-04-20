import {useContext} from 'react';
import {BooksContext} from "../context/BooksContext.tsx";

export const useBooks = () => useContext(BooksContext);

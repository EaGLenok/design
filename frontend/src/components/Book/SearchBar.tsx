import React, {useState} from 'react';
import {useBooks} from "../../hooks/useBooks.tsx";
import {fetchBooks, searchBooks} from "../../api/api.ts";

export default function SearchBar() {
    const [query, setQuery] = useState('');
    const { setBooks } = useBooks();

    const handleSearch = async (e: React.FormEvent) => {
        e.preventDefault();
        const data = query ? await searchBooks(query) : await fetchBooks();
        setBooks(data);
    };

    return (
        <form onSubmit={handleSearch} className="flex space-x-2 mb-6">
            <input
                placeholder="Search by title or author"
                className="flex-1 border border-gray-300 p-3 rounded-lg focus:ring-2 focus:ring-blue-300 outline-none"
                value={query}
                onChange={e => setQuery(e.target.value)}
            />
            <button className="bg-green-500 text-white py-3 px-6 rounded-lg shadow hover:bg-green-600 transition">
                Search
            </button>
        </form>
    );
}

import React, { useState } from 'react';
import {addBook, fetchBooks} from "../../api/api.ts";
import {useBooks} from "../../hooks/useBooks.tsx";

interface BookFormState {
    title: string;
    author: string;
    isbn: string;
    genre: string;
    totalCopies: number;
    description: string;
}

const fields: Array<{
    name: keyof BookFormState;
    label: string;
    type?: React.HTMLInputTypeAttribute;
    required?: boolean;
}> = [
    { name: 'title', label: 'Title', required: true },
    { name: 'author', label: 'Author', required: true },
    { name: 'isbn', label: 'ISBN', required: true },
    { name: 'genre', label: 'Genre', required: true },
    { name: 'description', label: 'Description', required: false }
];

export default function BookForm() {
    const { setBooks } = useBooks();
    const [form, setForm] = useState<BookFormState>({
        title: '',
        author: '',
        isbn: '',
        genre: '',
        totalCopies: 1,
        description: ''
    });
    const [msg, setMsg] = useState<string>('');

    const submit = async (e: React.FormEvent) => {
        e.preventDefault();
            await addBook(form);
            const updated = await fetchBooks();
            setBooks(updated);
            setMsg('Book added ✅');
            setForm({ title: '', author: '', isbn: '', genre: '', totalCopies: 1, description: '' });
      };

    return (
        <form onSubmit={submit} className="bg-white p-6 rounded-xl shadow-md space-y-4 mb-6">
            <h2 className="text-xl font-semibold">Add Book</h2>
            {msg && <div className="text-green-700">{msg}</div>}
            {fields.map(({ name, label, required, type = 'text' }) => (
                <div key={name} className="flex flex-col">
                    <label className="mb-1 text-sm font-medium text-gray-700">{label}</label>
                    <input
                        required={required}
                        type={type}
                        placeholder={label}
                        className="border border-gray-300 p-3 rounded-lg focus:ring-2 focus:ring-blue-300 outline-none w-full"
                        value={form[name] as string}
                        onChange={e =>
                            setForm(prev => ({ ...prev, [name]: type === 'number' ? +e.target.value : e.target.value } as BookFormState))
                        }
                    />
                </div>
            ))}
            <div className="flex flex-col">
                <label className="mb-1 text-sm font-medium text-gray-700">Copies</label>
                <input
                    type="number"
                    min="1"
                    placeholder="Copies"
                    className="border border-gray-300 p-3 rounded-lg focus:ring-2 focus:ring-blue-300 outline-none w-full"
                    value={form.totalCopies}
                    onChange={e => setForm(prev => ({ ...prev, totalCopies: +e.target.value }))}
                />
            </div>
            <button className="w-full bg-blue-600 text-white py-3 rounded-lg shadow hover:bg-blue-700 transition">
                Add Book
            </button>
        </form>
    );
}
import React, { useState } from 'react';
import {returnBook} from "../../api/api.ts";

export default function ReturnForm() {
    const [memberId, setMemberId] = useState('');
    const [isbn, setIsbn] = useState('');
    const [msg, setMsg] = useState('');

    const submit = async (e: React.FormEvent) => {
        e.preventDefault();
            await returnBook(memberId, isbn);
            setMsg('Book returned 🔄');
       };

    return (
        <form onSubmit={submit} className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-xl font-semibold">Return Book</h2>
            <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                {[{ v: memberId, fn: setMemberId, ph: 'Member ID' }, { v: isbn, fn: setIsbn, ph: 'ISBN' }].map(({ v, fn, ph }, i) => (
                    <input
                        key={i}
                        placeholder={ph}
                        className="border border-gray-300 p-3 rounded-lg focus:ring-2 focus:ring-blue-300 outline-none"
                        value={v}
                        onChange={e => fn(e.target.value)}
                    />
                ))}
                <button className="bg-red-500 text-white py-3 rounded-lg shadow hover:bg-red-600 transition">
                    Return
                </button>
            </div>
            {msg && <div className="text-green-600">{msg}</div>}
        </form>
    );
}
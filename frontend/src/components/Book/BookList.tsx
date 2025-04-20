import {useBooks} from "../../hooks/useBooks.tsx";

export default function BookList() {
    const { books } = useBooks();

    return (
        <div className="grid gap-6">
            {books.map(b => (
                <div key={b.isbn} className="bg-white p-6 rounded-xl shadow-md">
                    <h3 className="text-lg font-bold">{b.title}</h3>
                    <p className="text-sm text-gray-600">{b.author} — {b.genre}</p>
                    <p className="mt-2 text-sm">{b.availableCopies} / {b.totalCopies} available</p>
                </div>
            ))}
        </div>
    );
}
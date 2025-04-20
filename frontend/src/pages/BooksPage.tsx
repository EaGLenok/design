import BookForm from "../components/Book/BookForm.tsx";
import SearchBar from "../components/Book/SearchBar.tsx";
import BookList from "../components/Book/BookList.tsx";


export default function BooksPage() {
    return (
        <div className="space-y-6">
            <BookForm />
            <SearchBar />
            <BookList />
        </div>
    );
}

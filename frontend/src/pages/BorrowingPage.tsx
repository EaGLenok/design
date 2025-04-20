import BorrowForm from "../components/Borrowing/BorrowForm.tsx";
import ReturnForm from "../components/Borrowing/ReturnForm.tsx";

export default function BorrowingPage() {
    return (
        <div className="space-y-6">
            <BorrowForm />
            <ReturnForm />
        </div>
    );
}

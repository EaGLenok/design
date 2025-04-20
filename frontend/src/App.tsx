import { Routes, Route, Navigate } from 'react-router-dom';
import Layout from './components/Layout';
import BooksPage from './pages/BooksPage';
import MembersPage from './pages/MembersPage';
import BorrowingPage from './pages/BorrowingPage';

export default function App() {
    return (
        <Layout>
            <Routes>
                <Route path="/" element={<Navigate to="/books" replace />} />
                <Route path="/books" element={<BooksPage />} />
                <Route path="/members" element={<MembersPage />} />
                <Route path="/borrowing" element={<BorrowingPage />} />
            </Routes>
        </Layout>
    );
}

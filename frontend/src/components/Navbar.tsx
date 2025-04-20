import { NavLink } from 'react-router-dom';

const linkClass = ({ isActive }: { isActive: boolean }) =>
    `px-4 py-2 rounded ${isActive
        ? 'bg-blue-600 text-white'
        : 'text-gray-700 hover:bg-blue-100'}`;

export default function Navbar() {
    return (
        <nav className="bg-blue-500 p-4 text-white">
            <div className="container mx-auto flex space-x-4">
                <NavLink to="/books" className={linkClass}>Books</NavLink>
                <NavLink to="/members" className={linkClass}>Members</NavLink>
                <NavLink to="/borrowing" className={linkClass}>Borrow/Return</NavLink>
            </div>
        </nav>
    );
}

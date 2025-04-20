import { ReactNode } from 'react';
import Navbar from './Navbar';

export default function Layout({ children }: { children: ReactNode }) {
    return (
        <div className="min-h-screen flex flex-col bg-gray-100">
            <Navbar />
            <main className="flex-1 container mx-auto p-6 bg-white mt-4 rounded-lg shadow">
                {children}
            </main>
        </div>
    );
}

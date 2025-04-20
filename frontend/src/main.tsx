import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import { BooksProvider } from './context/BooksContext';
import {StrictMode} from "react";

import './index.css'

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <BrowserRouter>
            <BooksProvider>
             <App />
            </BooksProvider>
        </BrowserRouter>
    </StrictMode>
);

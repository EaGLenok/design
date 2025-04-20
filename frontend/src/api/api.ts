import axios, { AxiosError } from 'axios';
import { BookDto, MemberDetailsDto } from './types';

const client = axios.create({
    baseURL: 'http://localhost:5192/api',
    headers: { 'Content-Type': 'application/json' }
});

export interface ApiError {
    error: string;
    details?: string[];
}

enum HttpMethods {
    GET = 'GET',
    POST = 'POST',
}

async function request<T>(
    method: HttpMethods,
    url: string,
    data?: unknown
): Promise<T> {
    try {
        const response = await client.request<T>({ method, url, data });
        return response.data;
    } catch (err: unknown) {
        let message = 'An unexpected error occurred';
        if (axios.isAxiosError(err)) {
            const axiosErr = err as AxiosError<ApiError>;
            if (axiosErr.response?.data?.error) {
                message = axiosErr.response.data.error;
            } else {
                message = axiosErr.message;
            }
        } else if (err instanceof Error) {
            message = err.message;
        }
        throw new Error(message);
    }
}

export const fetchBooks = (): Promise<BookDto[]> =>
    request<BookDto[]>(HttpMethods.GET, '/books');

export const searchBooks = (q: string): Promise<BookDto[]> =>
    request<BookDto[]>(HttpMethods.GET, `/books/search?q=${encodeURIComponent(q)}`);

export const addBook = (
    data: Omit<BookDto, 'id' | 'availableCopies'>
): Promise<string> =>
    request<string>(HttpMethods.POST, '/books', data);

export const registerMember = (
    data: { memberId: string; fullName: string; email: string; phoneNumber?: string }
): Promise<string> =>
    request<string>(HttpMethods.POST, '/members', data);

export const getMemberDetails = (id: string): Promise<MemberDetailsDto> =>
    request<MemberDetailsDto>(HttpMethods.GET, `/members/${encodeURIComponent(id)}`);

export const borrowBook = (
    memberId: string,
    isbn: string
): Promise<void> =>
    request<void>(HttpMethods.POST, '/borrowing/borrow', { memberId, isbn });

export const returnBook = (
    memberId: string,
    isbn: string
): Promise<void> =>
    request<void>(HttpMethods.POST, '/borrowing/return', { memberId, isbn });
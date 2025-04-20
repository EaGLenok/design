export interface BookDto {
    id: string;
    title: string;
    author: string;
    isbn: string;
    genre: string;
    totalCopies: number;
    availableCopies: number;
    description?: string;
}

export interface BorrowRecordDto {
    isbn: string;
    borrowDate: string;
}

export interface MemberDetailsDto {
    memberId: string;
    fullName: string;
    email: string;
    phoneNumber?: string;
    currentBorrows: BorrowRecordDto[];
}

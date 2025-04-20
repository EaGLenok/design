# Library Management System

A full-stack **Library Management System** built with a **.NET 9** Web API backend and a **React + Vite + TypeScript + Tailwind CSS** frontend. The solution is designed for clean architecture, modular design, and ease of use.

---

## 📦 Tech Stack

- **Backend:** ASP.NET Core 9, C#, MediatR, FluentValidation, AutoMapper  
- **Frontend:** React, Vite, TypeScript, Tailwind CSS  
- **HTTP Client:** Axios  
- **Persistence:** In-memory JSON files (no external database)  
- **Architecture:** CQRS + Mediator pattern with clean folder structure

---

## 🚀 Getting Started

### 📌 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Node.js](https://nodejs.org/) (v16+)
- npm or yarn

---

### ▶️ Run Backend

```bash
cd backend/LibraryDesignKey.Api
dotnet build
dotnet run
```

> By default the API runs on `http://localhost:5192`

---

### ▶️ Run Frontend

```bash
cd frontend/library-frontend
npm install
npm run dev
```

> The frontend will be available at `http://localhost:3000`

---

## 🔌 API Endpoints

| Method | Route                            | Description                      |
|--------|----------------------------------|----------------------------------|
| GET    | `/api/books`                     | Get all books                    |
| GET    | `/api/books/search?q=abc`        | Search books by title/author     |
| POST   | `/api/books`                     | Add a new book                   |
| POST   | `/api/members`                   | Register a new member            |
| GET    | `/api/members/{id}`              | Get member details + borrows     |
| POST   | `/api/borrowing/borrow`          | Borrow a book                    |
| POST   | `/api/borrowing/return`          | Return a borrowed book           |

---

## 🛡 Error Handling (Backend → Frontend)

Global error middleware (`ErrorHandlingMiddleware`) ensures a unified error shape:

```json
{
  "error": "Validation failed",
  "details": ["Title is required", "Email must be valid"]
}
```

Or:

```json
{ "error": "Member not found" }
```

On the frontend, Axios throws `Error` with the proper `.message`.

---

## 📦 Build for Production

### Backend

```bash
cd backend/LibraryDesignKey.Api
dotnet publish -c Release -o out
```

### Frontend

```bash
cd frontend/library-frontend
npm run build
```

---


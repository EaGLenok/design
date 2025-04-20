using AutoMapper;
using LibraryDesignKey.Domain.Entities;
using LibraryDesignKey.Shared.DTOs;
using LibraryDesingKey.Application.Commands.Book;
using LibraryDesingKey.Application.Commands.Member;

namespace LibraryDesingKey.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddBookCommand, Book>();
        CreateMap<Book, BookDto>();
        CreateMap<RegisterMemberCommand, Member>();
        CreateMap<Member, MemberDto>();
        CreateMap<BorrowRecord, BorrowRecordDto>();
        CreateMap<Member, MemberDetailsDto>()
            .ForMember(d => d.CurrentBorrows, opt => opt.MapFrom(m => m.CurrentBorrows));
    }
}
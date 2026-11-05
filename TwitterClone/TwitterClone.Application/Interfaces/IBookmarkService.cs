using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IBookmarkService
    {
        BookmarkDto? CreateBookmark(CreateBookmarkDto createBookmarkDto);
        BookmarkDto? GetBookmarkById(Guid id);
        List<BookmarkDto> GetBookmarks(Guid? userId);
        bool DeleteBookmark(Guid id);
    }
}

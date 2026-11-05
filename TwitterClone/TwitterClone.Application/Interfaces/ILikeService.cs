using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeService
    {
        LikeDto? CreateLike(CreateLikeDto createLikeDto);
        LikeDto? GetLikeById(Guid id);
        List<LikeDto> GetLikes(Guid? userId, Guid? tweetId);
        bool DeleteLike(Guid id);
    }
}

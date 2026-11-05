using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface IFollowService
    {
        FollowDto? CreateFollow(CreateFollowDto createFollowDto);
        FollowDto? GetFollowById(Guid id);
        List<FollowDto> GetFollows(Guid? followerId, Guid? followingId);
        List<UserDto> GetFollowers(Guid userId);
        List<UserDto> GetFollowing(Guid userId);
        bool DeleteFollow(Guid id);
    }
}

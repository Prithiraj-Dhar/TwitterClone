using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface INotificationService
    {
        NotificationDto? CreateNotification(CreateNotificationDto createNotificationDto);
        NotificationDto? GetNotificationById(Guid id);
        List<NotificationDto> GetNotifications(Guid? userId, string? type, bool? isRead);
        NotificationDto? MarkNotificationAsRead(Guid id);
        int MarkAllNotificationsAsRead(Guid userId);
        bool DeleteNotification(Guid id);
    }
}

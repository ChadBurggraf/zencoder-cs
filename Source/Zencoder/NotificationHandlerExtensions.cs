using Microsoft.AspNetCore.Builder;

namespace Zencoder
{
    /// <summary>
    /// 
    /// </summary>
    public static class NotificationHandlerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNotificationHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotificationHandlerMiddleware>();
        }
    }
}

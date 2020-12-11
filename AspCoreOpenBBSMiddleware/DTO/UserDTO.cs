using ApplicationCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreOpenBBSMiddleware.DTO
{
    public class UserDTO
    {
        [JsonProperty("usn")]
        public string UserSN { get; set; }

        [JsonProperty("uid")]
        public string UserId { get; set; }
    }

    public static class UserDTOExtension
    {
        public static UserDTO ToDTO(this User source)
        {
            if (source == null) return null;

            return new UserDTO
            {
                UserId = source.UserId,
                UserSN = source.UserSN
            };
        }

        public static IEnumerable<UserDTO> ToDTO(this IEnumerable<User> source)
        {
            return source?.Select(u => u.ToDTO());
        }
    }
}

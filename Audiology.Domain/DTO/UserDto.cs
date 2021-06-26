using System.Collections.Generic;
using System.Xml.Serialization;

namespace Audiology.Domain.DTO
{
    public class UserDto
    {
        [XmlElement("email")]
        public string Email { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
        [XmlElement("usertype")]
        public UserType UserType { get; set; }
    }

    [XmlRoot("users")]
    public class Users
    {
        [XmlElement("user")]
        public List<UserDto> User { get; set; }
    }
    public enum UserType
    {
        [XmlEnum("1")]
        privileged = 1,
        [XmlEnum("2")]
        normal = 2
    }
}

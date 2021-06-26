using Audiology.Domain.DTO;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Audiology.Domain
{
    public class AccountService : IAccountService
    {
        public UserType IsValidUser(UserDto userDto)
        {
            var userList = ReadXml();
            return userList.User.FirstOrDefault(x => x.Email.ToLower() == userDto.Email.ToLower() &&
                                 x.Password == userDto.Password).UserType;

        }

        private Users ReadXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Users));
            Users userList = new Users();
            var currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine($"{currentDirectory}.Domain", "XmlFile", "Users.xml");
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                userList = (Users)serializer.Deserialize(fileStream);
            }
            return userList;
        }
    }
}

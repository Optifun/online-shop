using System;

namespace OnlineShop.Core.DTO
{
    public record UserData(long Id, string Name, bool IsAdmin, DateTime Register)
    {
        public static UserData Convert(UserMutable user) => 
            new UserData(user);

        UserData(UserMutable user) : this(user.Id, user.Name, user.IsAdmin, user.Register)
        {
        }
    }

    public record UserMutable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Register { get; set; }

        public UserMutable(long Id, string Name, bool IsAdmin, DateTime Register)
        {
            this.Id = Id;
            this.Name = Name;
            this.IsAdmin = IsAdmin;
            this.Register = Register;
        }

        public UserMutable(UserData user) : this(user.Id, user.Name, user.IsAdmin, user.Register)
        {
        }

        public void Deconstruct(out long Id, out string Name, out bool IsAdmin, out DateTime Register)
        {
            Id = this.Id;
            Name = this.Name;
            IsAdmin = this.IsAdmin;
            Register = this.Register;
        }
    }

    public record UserCredentials(string UserName, string Password);
}
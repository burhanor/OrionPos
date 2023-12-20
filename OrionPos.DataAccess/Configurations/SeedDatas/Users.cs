using Microsoft.AspNetCore.Identity;
using OrionPos.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.DataAccess.Configurations.SeedDatas
{
    public static class Users
    {
        public static List<AppUser> GetSeedData()
        {
            PasswordHasher<AppUser> hasher = new(); 

            AppUser user1 = new()
            {
                Id = 1,
                Email = "user1@user.com",
                Name = "Kullanıcı 1",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false,
                AccessFailedCount = 0,
                NormalizedUserName = "USER1",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "user1",
                NormalizedEmail = "USER1@USER.COM",
                PhoneNumber = "0543 812 36 80",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false
            };
            AppUser user2 = new()
            {
                Id = 2,
                Email = "user2@user.com",
                Name = "Kullanıcı 2",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false,
                AccessFailedCount = 0,
                NormalizedUserName = "USER2",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "user2",
                NormalizedEmail = "USER2@USER.COM",
                PhoneNumber = "0543 812 36 81",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false
            };

            user1.PasswordHash = hasher.HashPassword(user1, "123456Aa");
            user2.PasswordHash = hasher.HashPassword(user2, "654321Aa");

            return [user1,user2];
        }
    }
}

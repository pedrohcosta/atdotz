using Entities.Entities;
using Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F10"),
                    Name = "Ordep",
                    Mail = "ordep@hotmail.com",
                    Balance= 10000,
                    Dotz = 1000,
                },
                new Account
                {
                    Id = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F20"),
                    Name = "Atram",
                    Mail = "Atram@hotmail.com",
                    Balance = 20000,
                    Dotz = 2000,
                }
            );
            modelBuilder.Entity<AccountCard>().HasData(
                new AccountCard { 
                        AccountId = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F10"),
                        Number = "5555-6666-7777-8888",
                        Type = TypeCard.Fisico
                },
                new AccountCard
                {
                    AccountId = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F10"),
                    Number = "6666-7777-8888-5555",
                    Type = TypeCard.Virtal
                },
                new AccountCard
                {
                    AccountId = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F10"),
                    Number = "7777-8888-5555-6666",
                    Type = TypeCard.Virtal
                },
                new AccountCard
                {
                    AccountId = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F20"),
                    Number = "1111-2222-3333-4444",
                    Type = TypeCard.Fisico
                }
            );

            modelBuilder.Entity<AccountExtract>().HasData(
                new AccountExtract
                {
                    AccountId = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F10"),
                    DocumentCode = "123456789",
                    Amount = 1000,
                    Observation = "",
                    Peso = 10,
                    Dotz= 100,
                    Type = TypeEvent.Deposit
                },
                new AccountExtract
                {
                    AccountId = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F10"),
                    DocumentCode = "234567891",
                    Amount = 2000,
                    Observation = "Depositao A",
                    Peso = 10,
                    Dotz = 200,
                    Type = TypeEvent.Deposit
                },
                new AccountExtract
                {
                    AccountId = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F10"),
                    DocumentCode = "345678912",
                    Amount = 1500,
                    Observation = "Deposito B",
                    Peso = 10,
                    Dotz = 150,
                    Type = TypeEvent.Deposit
                },
                new AccountExtract
                {
                    AccountId = Guid.Parse("DDC9CCDE-FC66-4D07-820C-5F7601756F10"),
                    DocumentCode = "987654321",
                    Amount = 100,
                    Observation = "Pagamento B",
                    Peso = 10,
                    Dotz = 10,
                    Type = TypeEvent.Payment
                }

            );
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace TestCoreApp_Elliott.Models.OlympicGames
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = "summer", Name = "Summer Olympics" },
                new Game { GameId = "winter", Name = "Winter Olympics" },
                new Game { GameId = "para", Name = "Paralympic" },
                new Game { GameId = "youth", Name = "Youth Olympic Games" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "in", Name = "Indoor"},
                new Category { CategoryId = "out", Name = "Outdoor"}
                );

            modelBuilder.Entity<Country>().HasData(
                new { CountryID = "aut", Name = "Austria", GameID = "para", CategoryID = "out", LogoImage = "AUT.PNG"},
                new { CountryID = "bra", Name = "Brazil", GameID = "summer", CategoryID = "out", LogoImage = "BRA.PNG" },
                new { CountryID = "can", Name = "Canada", GameID = "winter", CategoryID = "in", LogoImage = "CAN.PNG" },
                new { CountryID = "chn", Name = "China", GameID = "summer", CategoryID = "in", LogoImage = "CHN.PNG" },
                new { CountryID = "cyp", Name = "Cyprus", GameID = "youth", CategoryID = "in", LogoImage = "CYP.PNG" },
                new { CountryID = "fin", Name = "Finland", GameID = "youth", CategoryID = "out", LogoImage = "FIN.PNG" },
                new { CountryID = "fra", Name = "France", GameID = "youth", CategoryID = "in", LogoImage = "FRA.PNG" },
                new { CountryID = "deu", Name = "Germany", GameID = "summer", CategoryID = "in", LogoImage = "DEU.PNG" },
                new { CountryID = "gbr", Name = "Great Britain", GameID = "winter", CategoryID = "in", LogoImage = "GBR.PNG" },
                new { CountryID = "ita", Name = "Italy", GameID = "winter", CategoryID = "out", LogoImage = "ITA.PNG" },
                new { CountryID = "jam", Name = "Jamaica", GameID = "winter", CategoryID = "out", LogoImage = "JAM.PNG" },
                new { CountryID = "jpn", Name = "Japan", GameID = "winter", CategoryID = "out", LogoImage = "JAP.PNG" },
                new { CountryID = "mex", Name = "Mexico", GameID = "summer", CategoryID = "in", LogoImage = "MEX.PNG" },
                new { CountryID = "nld", Name = "Netherlands", GameID = "summer", CategoryID = "out", LogoImage = "NLD.PNG" },
                new { CountryID = "pak", Name = "Pakistan", GameID = "para", CategoryID = "out", LogoImage = "PAK.PNG" },
                new { CountryID = "prt", Name = "Portugal", GameID = "youth", CategoryID = "out", LogoImage = "PRT.PNG" },
                new { CountryID = "rus", Name = "Russia", GameID = "youth", CategoryID = "in", LogoImage = "RUS.PNG" },
                new { CountryID = "svk", Name = "Slovakia", GameID = "youth", CategoryID = "out", LogoImage = "SVK.PNG" },
                new { CountryID = "swe", Name = "Sweden", GameID = "winter", CategoryID = "in", LogoImage = "SWE.PNG" },
                new { CountryID = "tha", Name = "Thailand", GameID = "para", CategoryID = "in", LogoImage = "THA.PNG" },
                new { CountryID = "ukr", Name = "Ukraine", GameID = "para", CategoryID = "in", LogoImage = "UKR.PNG" },
                new { CountryID = "ury", Name = "Uruguay", GameID = "para", CategoryID = "in", LogoImage = "URY.PNG" },
                new { CountryID = "usa", Name = "United States", GameID = "summer", CategoryID = "out", LogoImage = "USA.PNG" },
                new { CountryID = "zwe", Name = "Zimbabwe", GameID = "para", CategoryID = "out", LogoImage = "ZWE.PNG" }
                );
        }

    }
}

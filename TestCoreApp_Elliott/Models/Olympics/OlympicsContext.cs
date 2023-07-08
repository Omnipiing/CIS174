using Microsoft.EntityFrameworkCore;

namespace TestCoreApp_Elliott.Models.OlympicGames
{
    public class OlympicsContext : DbContext
    {
        public OlympicsContext(DbContextOptions<OlympicsContext> options) : base(options) { }

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
                new { CountryID = "aut", Name = "Austria", GameId = "para", CategoryId = "out", FlagImage = "AUT.png"},
                new { CountryID = "bra", Name = "Brazil", GameId = "summer", CategoryId = "out", FlagImage = "BRA.png" },
                new { CountryID = "can", Name = "Canada", GameId = "winter", CategoryId = "in", FlagImage = "CAN.png" },
                new { CountryID = "chn", Name = "China", GameId = "summer", CategoryId = "in", FlagImage = "CHN.png" },
                new { CountryID = "cyp", Name = "Cyprus", GameId = "youth", CategoryId = "in", FlagImage = "CYP.png" },
                new { CountryID = "fin", Name = "Finland", GameId = "youth", CategoryId = "out", FlagImage = "FIN.png" },
                new { CountryID = "fra", Name = "France", GameId     = "youth", CategoryId = "in", FlagImage = "FRA.png" },
                new { CountryID = "deu", Name = "Germany", GameId = "summer", CategoryId = "in", FlagImage = "DEU.png" },
                new { CountryID = "gbr", Name = "Great Britain", GameId = "winter", CategoryId = "in", FlagImage = "GBR.png" },
                new { CountryID = "ita", Name = "Italy", GameId = "winter", CategoryId = "out", FlagImage = "ITA.png" },
                new { CountryID = "jam", Name = "Jamaica", GameId = "winter", CategoryId = "out", FlagImage = "JAM.png" },
                new { CountryID = "jpn", Name = "Japan", GameId = "winter", CategoryId   = "out", FlagImage = "JAP.png" },
                new { CountryID = "mex", Name = "Mexico", GameId = "summer", CategoryId = "in", FlagImage = "MEX.png" },
                new { CountryID = "nld", Name = "Netherlands", GameId = "summer", CategoryId = "out", FlagImage = "NLD.png" },
                new { CountryID = "pak", Name = "Pakistan", GameId = "para", CategoryId = "out", FlagImage = "PAK.png" },
                new { CountryID = "prt", Name = "Portugal", GameId = "youth", CategoryId = "out", FlagImage = "PRT.png" },
                new { CountryID = "rus", Name = "Russia", GameId = "youth", CategoryId = "in", FlagImage = "RUS.png" },
                new { CountryID = "svk", Name = "Slovakia", GameId = "youth", CategoryId     = "out", FlagImage = "SVK.png" },
                new { CountryID = "swe", Name = "Sweden", GameId = "winter", CategoryId = "in", FlagImage = "SWE.png" },
                new { CountryID = "tha", Name = "Thailand", GameId = "para", CategoryId = "in", FlagImage = "THA.png" },
                new { CountryID = "ukr", Name = "Ukraine", GameId = "para", CategoryId = "in", FlagImage = "UKR.png" },
                new { CountryID = "ury", Name = "Uruguay", GameId = "para", CategoryId = "in", FlagImage = "URY.png" },
                new { CountryID = "usa", Name = "United States", GameId = "summer", CategoryId = "out", FlagImage = "USA.png" },
                new { CountryID = "zwe", Name = "Zimbabwe", GameId = "para", CategoryId = "out", FlagImage = "ZWE.png" }
                );
        }

    }
}

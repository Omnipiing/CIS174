using Microsoft.EntityFrameworkCore;

namespace MDPwebApp.Models
{
    public class RequestContext : DbContext
    {
        public RequestContext(DbContextOptions<RequestContext> options)
           : base(options)
        { }

        public DbSet<Requestor> Requests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Requestor>().HasData(
                new Requestor
                {
                    requestId = 1,

                    OE_MRO_radio = "",
                    CIVL_ITAR_radio = "",
                    AOG = false,
                    LeadTime = false,
                    PrimarySBU = true,
                    STO = false,
                    Create_Extend_radio = "Create",
                    Make_Buy_radio = "Make",
                    MaterialNumber = "59568",
                    MaterialDescription = "SEAL",
                    MaterialPlant = "2020",
                    MaterialType = "Z001",
                    ProgramType = "AE250",
                    ProdSloc = "NEW1",
                    SalesOrg = "4000",
                    Scenario = "END ITEM",
                    OldPartNumber = "59567",
                    EPSloc = "REC1",
                    AdditionalPlant = "",
                    AdditionalSloc = "",
                    AdditionalSalesOrg = "",
                    Comment = "Required by Monday",
                    MRPController = "EAJ",
                    Component = "COM",
                    RawMaterial = "RAW",
                    Authority = "AUTH",
                    NextHigherAssembly = "NEX",
                    ProdSupervisor = "007",
                    AdditionalCheckBox = true

                }
                );
        }
    }
}

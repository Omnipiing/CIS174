using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MDPwebApp.Areas.Admin.Models
{
    public class Requestor
    {
        // EF Core will configure the db to generate this value
        [Key]
        public int requestId { get; set; }

        // Row #1
        public string OE_MRO_radio { get; set; } = string.Empty;
        public string CIVL_ITAR_radio { get; set;} = string.Empty;

        public bool AOG { get; set; } = false;
        public bool PrimarySBU { get; set; } = true;

        public bool LeadTime { get; set; } = false;
        public bool STO { get; set; } = false;

        public string Create_Extend_radio { get; set; } = string.Empty;
        public string Make_Buy_radio { get; set;} = string.Empty;

        // Row #2
        public string MaterialNumber { get; set; } = string.Empty;
        public string MaterialDescription { get; set; } = string.Empty;
        
        // Row #3
        public string MaterialPlant { get; set; } = string.Empty;
        public string SalesOrg { get; set; } = string.Empty;
        public string ProdSloc { get; set; } = string.Empty;

        // Row #4
        public string MaterialType { get; set; } = string.Empty;
        public string ProgramType { get; set; } = string.Empty;
        public string Scenario { get; set; } = string.Empty;

        // Row #5
        public string Component { get; set; } = string.Empty;
        public string RawMaterial { get; set; } = string.Empty;
        public string Authority { get; set; } = string.Empty;
        public string NextHigherAssembly { get; set; } = string.Empty;

        // Row #6
        public string OldPartNumber { get; set; } = string.Empty;
        public string ProdSupervisor { get; set; } = string.Empty;
        public string MRPController { get; set; } = string.Empty;
        public string EPSloc { get; set; } = string.Empty;

        // Row #7
        public bool AdditionalCheckBox { get; set; } = false;
        public string AdditionalPlant { get; set; } = string.Empty;
        public string AdditionalSloc { get; set; } = string.Empty;
        public string AdditionalSalesOrg { get; set; } = string.Empty;

        // Final Row of form
        public string Comment { get; set; } = string.Empty;
        
        // a read-only property for the slug at the end of the URL
        public string Slug => MaterialNumber.ToString();
    }
}

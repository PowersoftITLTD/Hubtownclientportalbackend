using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Information
    {
        [Key]
        public int InfId { get; set; }
        public string InfType { get; set; }
        public string InfDesc { get; set; }
    }
}

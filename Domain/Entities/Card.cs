using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Domain.Entities;

public class Card
{
	[Column(name: "id")]
   public Guid Id { get; set; }

   [Column(name: "number")]
   public string? Number { get; set; }

   [Column(name: "cvv")]
   public string? Cvv { get; set; }

   [Column(name: "password")]
   public string? Password { get; set; }

   [JsonIgnore]
   public virtual Profile? Profile { get; set; }

   [Column(name: "fk_profile")]
   public Guid FkProfile { get; set; }

   [Column(name: "type")]
   public CardType Type { get; set; }

   [Column(name: "validity")]
   public DateTime Validity { get; set; }

   [Column(name: "create_at")]
   public DateTime CreateAt { get; set; }

   [Column(name: "update_at")]
   public DateTime UpdateAt { get; set; }
}

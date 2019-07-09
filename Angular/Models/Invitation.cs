using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Invitation
    {
        [Key]
        public int InvitationId { get; set; }

        public int InvitationPostId { get; set; }

        [JsonIgnore]
        [ForeignKey("InvitationPostId")]
        public Post Post { get; set; }

        [JsonIgnore]
        public DateTime? InvitationDate { get; set; }

        [JsonIgnore]
        [InverseProperty("Invitation")]
        public List<Guest> Guests { get; set; }

        public string Type { get; set; }

        public int NumberOfGuests { get; set; }

        public IPoint LocationPoint { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }
    }

    public class InvitationDto
    {
        public int InvitationId { get; set; }

        public int InvitationPostId { get; set; }

        public long? InvitationDateUnix { get; set; }

        public string Type { get; set; }

        public int NumberOfGuests { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public List<Guest> Guests { get; set; }

        public static InvitationDto ToDto(Invitation invitation)
        {
            return Projection.Compile().Invoke(invitation);
        }

        public Invitation ToEntity()
        {
            return ReverseProjection.Compile().Invoke(this);
        }

        public static Expression<Func<InvitationDto, Invitation>> ReverseProjection
        {
            get
            {
                return p => new Invitation()
                {
                    InvitationId = p.InvitationId,
                    InvitationPostId = p.InvitationPostId,
                    InvitationDate = DateTimeOffset.FromUnixTimeMilliseconds(p.InvitationDateUnix.GetValueOrDefault()).UtcDateTime,
                    Type = p.Type,
                    NumberOfGuests = p.NumberOfGuests,
                    ZipCode = p.ZipCode,
                    Address = p.Address,
                    Number = p.Number,
                    City = p.City,
                    LocationPoint = p.Longitude.HasValue && p.Latitude.HasValue ? new Point(p.Latitude.GetValueOrDefault(), p.Longitude.GetValueOrDefault()) { SRID = 4326 } : null
                };
            }
        }

        public static Expression<Func<Invitation, InvitationDto>> Projection
        {
            get
            {
                return p => new InvitationDto()
                {
                    InvitationId = p.InvitationId,
                    InvitationPostId = p.InvitationPostId,
                    InvitationDateUnix = new DateTimeOffset(p.InvitationDate.GetValueOrDefault()).ToUnixTimeMilliseconds(),
                    Type = p.Type,
                    NumberOfGuests = p.NumberOfGuests,
                    ZipCode = p.ZipCode,
                    Address = p.Address,
                    Number = p.Number,
                    Guests = p.Guests,
                    Latitude = p.LocationPoint == null ? 0.00: p.LocationPoint.Coordinate.Y,
                    Longitude = p.LocationPoint == null ? 0.00 : p.LocationPoint.Coordinate.X
                };
            }
        }
    }
}

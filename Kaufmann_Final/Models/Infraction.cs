﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Kaufmann_Final.Models
{
    public partial class Infraction
    {
        public int InfractionId { get; set; }
        public int VehicleOwnerId { get; set; }
        public string Offence { get; set; }
        public DateTime InfractionDate { get; set; }
        public decimal FineAmount { get; set; }

        public virtual VehicleOwner VehicleOwner { get; set; }
    }
}
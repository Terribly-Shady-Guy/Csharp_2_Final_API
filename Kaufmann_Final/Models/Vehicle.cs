﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Kaufmann_Final.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            VehicleOwners = new HashSet<VehicleOwner>();
        }

        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }

        public virtual ICollection<VehicleOwner> VehicleOwners { get; set; }
    }
}
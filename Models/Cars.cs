namespace EVComparisons.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string? ImageLink { get; set; }
        public ExtraInfo.CarTypes Type { get; set; }
        public string? Maker { get; set; }
        public string? Model { get; set; }
        public int Range { get; set; }
        public int FullPrice { get; set; }
        public int Seats { get; set; }

        public int Made { get; set; }
        public int CargoVolume { get; set; }
        public bool RoofRails { get; set; }
        public bool TowHitch { get; set; }
        public int TowWeight { get; set; }
        public int MaxPayload { get; set; }
        public int Safety { get; set; }
        public double BatteryCapacity { get; set; }
        public double NormalChargePower { get; set; }
        public int NormalChargeTime { get; set; }
        public ExtraInfo.PortTypes NormalChargePort { get; set; }
        public ExtraInfo.Location NormalPortLocation { get; set; }
        public double FastChargePower { get; set; }
        public int FastChargeTime { get; set; }
        public ExtraInfo.PortTypes FastChargePort { get; set; }
        public ExtraInfo.Location FastPortLocation { get; set; }
        public int TopSpeed { get; set; }
        public double NaughtTo60 { get; set; }
        public int Efficiency { get; set; }
        public int TotalPower { get; set; }
        public int TotalTorque { get; set; }
        public ExtraInfo.CarDriveType Drive { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string? Link { get; set; }
    }

    public class ExtraInfo
    {
        public enum CarTypes
        {
            Hatchback,
            Saloon,
            SUV,
            Coupe,
            MPV,
            Pickup,
            Sports_Car,
            Luxury,
            Compact,
            Off_Road,
            Estate
        }

        public enum PortTypes
        {
            Type_1,
            Type_2,
            CHAdeMo,
            CCS
        }

        public enum Location
        {
            Front_Middle,
            Front_Left,
            Front_Right,
            Rear_Left,
            Rear_Right
        }

        public enum CarDriveType
        {
            Rear,
            Front,
            AWD
        }
    }
}

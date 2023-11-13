using System;

namespace ApplicationUI.Models
{
    public class RoomId
    {
        public RoomId(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }

        public int FloorNumber { get; }
        public int RoomNumber { get; }

        public override bool Equals(object? obj)
        {
            return obj is RoomId id &&
                   FloorNumber == id.FloorNumber &&
                   RoomNumber == id.RoomNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, RoomNumber);
        }

        public static bool operator ==(RoomId left, RoomId right)
        {
            if (left is null && right is null)
            {
                return true;
            }
            return !(left is null) && left.Equals(right);
        }

        public static bool operator !=(RoomId left, RoomId right)
        { return !(left == right); }

        public override string? ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }
    }
}
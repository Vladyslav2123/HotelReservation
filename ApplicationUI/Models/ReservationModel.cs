using System;

namespace ApplicationUI.Models
{
    public class ReservationModel
    {
        public ReservationModel(RoomId roomId, DateTime startTime, DateTime endTime, ClientModel clientModel)
        {
            RoomId = roomId;
            StartTime = startTime;
            EndTime = endTime;
            ClientModel = clientModel;
        }

        public RoomId RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ClientModel ClientModel { get; set; }

        public bool Conflicts(ReservationModel model)
        {
            if (model.RoomId != RoomId)
            {
                return false;
            }
            return model.StartTime < EndTime && model.EndTime > StartTime;
        }
    }
}
﻿using DormyWebService.Entities.TicketEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DormyWebService.ViewModels.TicketViewModels.RoomTransfer.SendRoomTransfer
{
    public class SendRoomTransferRequest
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int RoomTypeId { get; set; }
        [Required]
        public string Description { get; set; }

        internal static RoomTransferRequestForm NewEntityFromRequest(SendRoomTransferRequest request)
        {
            return new RoomTransferRequestForm()
            {
                StudentId = request.StudentId,
                Reason = request.Description,
                TargetRoomId = request.RoomTypeId,
                CreatedDate = DateTime.Now,
                LastUpdated = DateTime.Now
            };
        }
    }
}

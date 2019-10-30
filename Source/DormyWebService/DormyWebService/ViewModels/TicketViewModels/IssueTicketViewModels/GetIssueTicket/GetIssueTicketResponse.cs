﻿using DormyWebService.Entities.AccountEntities;
using DormyWebService.Entities.TicketEntities;
using DormyWebService.Utilities;
using Sieve.Attributes;

namespace DormyWebService.ViewModels.TicketViewModels.IssueTicketViewModels.GetIssueTicket
{
    public class GetIssueTicketResponse
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public int IssueTicketId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public int Type { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string TypeName { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string Status { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public int OwnerId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string OwnerName { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public int? EquipmentId { get; set; }
//        public int? TargetStudentId { get; set; }
        public string Description { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string ImageUrl { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string CreatedDate { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string LastUpdated { get; set; }

        public static GetIssueTicketResponse ResponseFromEntity(IssueTicket issueTicket, Student owner , Entities.ParamEntities.Param type)
        {
            return new GetIssueTicketResponse()
            {
                Status = issueTicket.Status,
                CreatedDate = issueTicket.CreatedDate.ToString(GlobalParams.DateTimeResponseFormat),
                LastUpdated = issueTicket.LastUpdated.ToString(GlobalParams.DateTimeResponseFormat),
                EquipmentId = issueTicket.EquipmentId,
                Description = issueTicket.Description,
                OwnerId = issueTicket.OwnerId,
                OwnerName = owner.Name,
                ImageUrl = issueTicket.ImageUrl,
//                TargetStudentId = issueTicket.TargetStudentId,
                Type = issueTicket.Type,
                TypeName = type.Name,
                IssueTicketId = issueTicket.IssueTicketId,
            };
        }
    }
}
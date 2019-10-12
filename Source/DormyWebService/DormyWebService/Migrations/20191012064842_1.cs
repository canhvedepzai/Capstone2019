﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormyWebService.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParamTypes",
                columns: table => new
                {
                    ParamTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamTypes", x => x.ParamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PricePerUnits",
                columns: table => new
                {
                    PricePerUnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    TargetMonth = table.Column<int>(nullable: false),
                    TargetYear = table.Column<int>(nullable: false),
                    WaterPricePerUnit = table.Column<decimal>(type: "Money", nullable: false),
                    ElectricityPricePerUnit = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricePerUnits", x => x.PricePerUnitId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    DefaultCapacity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Params",
                columns: table => new
                {
                    ParamId = table.Column<int>(nullable: false),
                    ParamTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Params", x => x.ParamId);
                    table.ForeignKey(
                        name: "FK_Params_ParamTypes_ParamTypeId",
                        column: x => x.ParamTypeId,
                        principalTable: "ParamTypes",
                        principalColumn: "ParamTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    AccessToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerUserId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: true),
                    HomeTown = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomMonthlyBills",
                columns: table => new
                {
                    RoomMonthlyBillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomId = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    TargetMonth = table.Column<int>(nullable: false),
                    TargetYear = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    PreviousWaterNumber = table.Column<int>(nullable: false),
                    NewWaterNumber = table.Column<int>(nullable: false),
                    WaterBill = table.Column<decimal>(type: "Money", nullable: false),
                    PreviousElectricityNumber = table.Column<int>(nullable: false),
                    NewElectricityNumber = table.Column<int>(nullable: false),
                    ElectricityBill = table.Column<decimal>(type: "Money", nullable: false),
                    TotalRoomFee = table.Column<decimal>(type: "Money", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomMonthlyBills", x => x.RoomMonthlyBillId);
                    table.ForeignKey(
                        name: "FK_RoomMonthlyBills_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    StartedSchoolYear = table.Column<int>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: false),
                    IdentityCardImageUrl = table.Column<string>(nullable: true),
                    StudentCardNumber = table.Column<string>(nullable: false),
                    StudentCardImageUrl = table.Column<string>(nullable: true),
                    Term = table.Column<int>(nullable: false),
                    PriorityType = table.Column<int>(nullable: false),
                    PriorityImageUrl = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    IsRoomLeader = table.Column<bool>(nullable: false),
                    EvaluationScore = table.Column<int>(nullable: false),
                    AccountBalance = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueTickets",
                columns: table => new
                {
                    IssueTicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    OwnerUserId = table.Column<int>(nullable: false),
                    TargetUserUserId = table.Column<int>(nullable: true),
                    EquipmentId = table.Column<int>(nullable: true),
                    StaffId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Point = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueTickets", x => x.IssueTicketId);
                    table.ForeignKey(
                        name: "FK_IssueTickets_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueTickets_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueTickets_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueTickets_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueTickets_Users_TargetUserUserId",
                        column: x => x.TargetUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CancelContractForms",
                columns: table => new
                {
                    CancelContractFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    CancelationDate = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: true),
                    Reason = table.Column<string>(maxLength: 500, nullable: false),
                    StatusParamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelContractForms", x => x.CancelContractFormId);
                    table.ForeignKey(
                        name: "FK_CancelContractForms_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CancelContractForms_Params_StatusParamId",
                        column: x => x.StatusParamId,
                        principalTable: "Params",
                        principalColumn: "ParamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancelContractForms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractRenewalForms",
                columns: table => new
                {
                    ContractRenewalFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRenewalForms", x => x.ContractRenewalFormId);
                    table.ForeignKey(
                        name: "FK_ContractRenewalForms_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractRenewalForms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryReservationForms",
                columns: table => new
                {
                    DormitoryReservationFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: true),
                    TargetRoomTypeRoomTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryReservationForms", x => x.DormitoryReservationFormId);
                    table.ForeignKey(
                        name: "FK_DormitoryReservationForms_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DormitoryReservationForms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DormitoryReservationForms_RoomTypes_TargetRoomTypeRoomTypeId",
                        column: x => x.TargetRoomTypeRoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyTransactions",
                columns: table => new
                {
                    MoneyTransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    OriginalBalance = table.Column<decimal>(type: "Money", nullable: false),
                    MoneyAmount = table.Column<decimal>(type: "Money", nullable: false),
                    ResultBalance = table.Column<decimal>(type: "Money", nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransactions", x => x.MoneyTransactionId);
                    table.ForeignKey(
                        name: "FK_MoneyTransactions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoneyTransactions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomTransferRequestForms",
                columns: table => new
                {
                    RoomTransferRequestFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(maxLength: 500, nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: true),
                    TargetRoomTypeRoomTypeId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTransferRequestForms", x => x.RoomTransferRequestFormId);
                    table.ForeignKey(
                        name: "FK_RoomTransferRequestForms_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomTransferRequestForms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTransferRequestForms_RoomTypes_TargetRoomTypeRoomTypeId",
                        column: x => x.TargetRoomTypeRoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentMonthlyBills",
                columns: table => new
                {
                    StudentMonthlyBillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPaid = table.Column<bool>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    RoomMonthlyBillId = table.Column<int>(nullable: false),
                    RoomUtilityFee = table.Column<decimal>(type: "Money", nullable: false),
                    Percentage = table.Column<decimal>(nullable: false),
                    UtilityFee = table.Column<decimal>(type: "Money", nullable: false),
                    RoomFee = table.Column<decimal>(type: "Money", nullable: false),
                    Total = table.Column<decimal>(type: "Money", nullable: false),
                    TargetMonth = table.Column<DateTime>(nullable: false),
                    TargetYear = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMonthlyBills", x => x.StudentMonthlyBillId);
                    table.ForeignKey(
                        name: "FK_StudentMonthlyBills_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentMonthlyBills_RoomMonthlyBills_RoomMonthlyBillId",
                        column: x => x.RoomMonthlyBillId,
                        principalTable: "RoomMonthlyBills",
                        principalColumn: "RoomMonthlyBillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMonthlyBills_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ParamTypes",
                columns: new[] { "ParamTypeId", "Name" },
                values: new object[,]
                {
                    { 0, "Contract Status" },
                    { 1, "EquipmentType" },
                    { 2, "EquipmentStatus" },
                    { 3, "MoneyTransactionType" },
                    { 4, "NotificationType" },
                    { 5, "NotificationStatus" },
                    { 6, "RequestStatus" },
                    { 7, "StudentPriorityType" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 0, "Admin" },
                    { 1, "Staff" },
                    { 2, "Student" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancelContractForms_StaffId",
                table: "CancelContractForms",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CancelContractForms_StatusParamId",
                table: "CancelContractForms",
                column: "StatusParamId");

            migrationBuilder.CreateIndex(
                name: "IX_CancelContractForms_StudentId",
                table: "CancelContractForms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_StudentId",
                table: "Contract",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRenewalForms_StaffId",
                table: "ContractRenewalForms",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRenewalForms_StudentId",
                table: "ContractRenewalForms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryReservationForms_StaffId",
                table: "DormitoryReservationForms",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryReservationForms_StudentId",
                table: "DormitoryReservationForms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryReservationForms_TargetRoomTypeRoomTypeId",
                table: "DormitoryReservationForms",
                column: "TargetRoomTypeRoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_RoomId",
                table: "Equipments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTickets_EquipmentId",
                table: "IssueTickets",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTickets_OwnerUserId",
                table: "IssueTickets",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTickets_RoomId",
                table: "IssueTickets",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTickets_StaffId",
                table: "IssueTickets",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTickets_TargetUserUserId",
                table: "IssueTickets",
                column: "TargetUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_RoomId",
                table: "MoneyTransactions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_StudentId",
                table: "MoneyTransactions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OwnerUserId",
                table: "Notifications",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Params_ParamTypeId",
                table: "Params",
                column: "ParamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomMonthlyBills_RoomId",
                table: "RoomMonthlyBills",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTransferRequestForms_StaffId",
                table: "RoomTransferRequestForms",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTransferRequestForms_StudentId",
                table: "RoomTransferRequestForms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTransferRequestForms_TargetRoomTypeRoomTypeId",
                table: "RoomTransferRequestForms",
                column: "TargetRoomTypeRoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMonthlyBills_RoomId",
                table: "StudentMonthlyBills",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMonthlyBills_RoomMonthlyBillId",
                table: "StudentMonthlyBills",
                column: "RoomMonthlyBillId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMonthlyBills_StudentId",
                table: "StudentMonthlyBills",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomId",
                table: "Students",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelContractForms");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "ContractRenewalForms");

            migrationBuilder.DropTable(
                name: "DormitoryReservationForms");

            migrationBuilder.DropTable(
                name: "IssueTickets");

            migrationBuilder.DropTable(
                name: "MoneyTransactions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PricePerUnits");

            migrationBuilder.DropTable(
                name: "RoomTransferRequestForms");

            migrationBuilder.DropTable(
                name: "StudentMonthlyBills");

            migrationBuilder.DropTable(
                name: "Params");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "RoomMonthlyBills");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ParamTypes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

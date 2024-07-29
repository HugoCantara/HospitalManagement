﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Repositories.Migrations
{
    public partial class AddDoctorTimingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorTimings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MorningShiftStartTime = table.Column<int>(type: "int", nullable: false),
                    MorningShiftEndTime = table.Column<int>(type: "int", nullable: false),
                    AfternoonShiftStartTime = table.Column<int>(type: "int", nullable: false),
                    AfternoonShiftEndTime = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTimings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorTimings_AspNetUsers_DoctorIdId",
                        column: x => x.DoctorIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTimings_DoctorIdId",
                table: "DoctorTimings",
                column: "DoctorIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorTimings");
        }
    }
}

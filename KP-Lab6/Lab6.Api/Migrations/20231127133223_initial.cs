using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Line1NumberBuilding = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ZipPostCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StateProvinceCountry = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    MedicationTypeCode = table.Column<int>(type: "integer", nullable: false),
                    MedicationName = table.Column<string>(type: "text", nullable: false),
                    MedicationDescription = table.Column<string>(type: "text", nullable: false),
                    MedicationCost = table.Column<double>(type: "double precision", nullable: false),
                    MedicationOtherDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaceuticalCompanies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyOtherDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaceuticalCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<string>(type: "text", nullable: false),
                    CustomerFirstName = table.Column<string>(type: "text", nullable: false),
                    CustomerLastName = table.Column<string>(type: "text", nullable: false),
                    CustomerPhone = table.Column<string>(type: "text", nullable: false),
                    DateOriginalyJoined = table.Column<DateOnly>(type: "date", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "text", nullable: false),
                    DateCardExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    OtherCustomerDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<string>(type: "text", nullable: false),
                    DoctorFirstName = table.Column<string>(type: "text", nullable: false),
                    DoctorLastName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    DoctorPhone = table.Column<string>(type: "text", nullable: false),
                    DoctorEmail = table.Column<string>(type: "text", nullable: false),
                    OtherDoctorDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenericMedications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    GenericMedicationsDetails = table.Column<string>(type: "text", nullable: false),
                    MedicationId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericMedications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericMedications_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandNameMedications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<string>(type: "text", nullable: false),
                    BrandMedicationName = table.Column<string>(type: "text", nullable: false),
                    BrandMedicationCost = table.Column<string>(type: "text", nullable: false),
                    BrandMedicationDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandNameMedications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandNameMedications_PharmaceuticalCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "PharmaceuticalCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: false),
                    PrescriptionStatusCode = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethodCode = table.Column<int>(type: "integer", nullable: false),
                    DatePrescriptionReceived = table.Column<DateOnly>(type: "date", nullable: false),
                    DatePrescriptionRenewal = table.Column<DateOnly>(type: "date", nullable: false),
                    DatePrescriptionSendToDoctor = table.Column<DateOnly>(type: "date", nullable: false),
                    DatePrescriptionProcessed = table.Column<DateOnly>(type: "date", nullable: false),
                    DatePrescriptionRecievedFromDoctor = table.Column<DateOnly>(type: "date", nullable: false),
                    DatePrescriptionSendToCompany = table.Column<DateOnly>(type: "date", nullable: false),
                    DatePrescriptionFilled = table.Column<DateOnly>(type: "date", nullable: false),
                    OtherPrescriptionDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenericToBrandNameCorrespondences",
                columns: table => new
                {
                    BrandNameMedicationId = table.Column<string>(type: "text", nullable: false),
                    GenericMedicationId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericToBrandNameCorrespondences", x => new { x.BrandNameMedicationId, x.GenericMedicationId });
                    table.ForeignKey(
                        name: "FK_GenericToBrandNameCorrespondences_BrandNameMedications_Bran~",
                        column: x => x.BrandNameMedicationId,
                        principalTable: "BrandNameMedications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericToBrandNameCorrespondences_GenericMedications_Generi~",
                        column: x => x.GenericMedicationId,
                        principalTable: "GenericMedications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsOrdered",
                columns: table => new
                {
                    PrescriptionId = table.Column<string>(type: "text", nullable: false),
                    MedicationId = table.Column<string>(type: "text", nullable: false),
                    DateOrdered = table.Column<DateOnly>(type: "date", nullable: false),
                    QuantityOrdered = table.Column<int>(type: "integer", nullable: false),
                    DateReceived = table.Column<DateOnly>(type: "date", nullable: false),
                    QuantityReceived = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsOrdered", x => new { x.PrescriptionId, x.MedicationId });
                    table.ForeignKey(
                        name: "FK_ItemsOrdered_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsOrdered_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionItems",
                columns: table => new
                {
                    PrescriptionId = table.Column<string>(type: "text", nullable: false),
                    MedicationId = table.Column<string>(type: "text", nullable: false),
                    PrestcriptionQuantity = table.Column<int>(type: "integer", nullable: false),
                    InstructionsToCustomer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionItems", x => new { x.PrescriptionId, x.MedicationId });
                    table.ForeignKey(
                        name: "FK_PrescriptionItems_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandNameMedications_CompanyId",
                table: "BrandNameMedications",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AddressId",
                table: "Doctors",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericMedications_MedicationId",
                table: "GenericMedications",
                column: "MedicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenericToBrandNameCorrespondences_GenericMedicationId",
                table: "GenericToBrandNameCorrespondences",
                column: "GenericMedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsOrdered_MedicationId",
                table: "ItemsOrdered",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItems_MedicationId",
                table: "PrescriptionItems",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_CustomerId",
                table: "Prescriptions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenericToBrandNameCorrespondences");

            migrationBuilder.DropTable(
                name: "ItemsOrdered");

            migrationBuilder.DropTable(
                name: "PrescriptionItems");

            migrationBuilder.DropTable(
                name: "BrandNameMedications");

            migrationBuilder.DropTable(
                name: "GenericMedications");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "PharmaceuticalCompanies");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}

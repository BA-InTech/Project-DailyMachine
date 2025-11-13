using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePcbModelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.13, \"SMT 01\": 0.35211, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.13, \"SMT 01\": 0.39673, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.13, \"SMT 01\": 0.37345, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.109, \"SMT 01\": 0.315, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.109, \"SMT 01\": 0.3783, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1089, \"SMT 01\": 0.36375, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1089, \"SMT 01\": 0.37345, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1089, \"SMT 01\": 0.37345, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1089, \"SMT 01\": 0.37345, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-2400DEG /EB /EE", 6.0, "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.108, \"SMT 01\": 0.34, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-2400DGN /LJ6", 6.0, "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1584, \"SMT 01\": 0.244, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-2400DPC /DP", 6.0, "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1584, \"SMT 01\": 0.276, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-2400DGT", 6.0, "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.108, \"SMT 01\": 0.34435, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-2450-S", 6.0, "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.109, \"SMT 01\": 0.264, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "R-2255-S", 6.0, "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.109, \"SMT 01\": 0.2231, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "REF_PASTA [1st_CM+RH 100V]1", "{ \"JVK 02\": 0.124, \"JVK 03\": 0.124, \"AVK\": 0.1, \"RH\": 0.0891, \"SMT 01\": 0.5201916, \"SMT 02\": 0.26, \"SMT 03\": 0.26 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "REF_PASTA [2nd_CM+RH 100V]2", "{ \"JVK 02\": 0.124, \"JVK 03\": 0.124, \"AVK\": 0.1, \"RH\": 0.0891, \"SMT 01\": 0.5201916, \"SMT 02\": 0.26, \"SMT 03\": 0.26 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "ARBPC2C00670", "{ \"JVK 02\": 0.097166667, \"JVK 03\": 0.097166667, \"AVK\": 0.047666667, \"RH\": 0.091666667, \"SMT 01\": 0.47724, \"SMT 02\": 0.146666667, \"SMT 03\": 0.146666667 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "BB220", 4.0, "{ \"JVK 02\": 0.24, \"JVK 03\": 0.24, \"RH\": 0.8, \"SMT 02\": 0.469, \"SMT 03\": 0.469 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "BB240", 4.0, "{ \"JVK 02\": 0.24, \"JVK 03\": 0.24, \"RH\": 0.8, \"SMT 02\": 0.579, \"SMT 03\": 0.579 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "FREEZER [BG-188654]", "{ \"JVK 02\": 0.097166667, \"JVK 03\": 0.097166667, \"AVK\": 0.047666667, \"RH\": 0.091666667, \"SMT 01\": 0.47724, \"SMT 02\": 0.146666667, \"SMT 03\": 0.146666667 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "LED FREEZER [BG-188642]", 18.0, "{ \"RH\": 0.1914, \"SMT 01\": 0.06499 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "LED ARBPLLA00750 <RH>", 14.0, "{ \"AVK\": 0.047666667, \"RH\": 0.1914 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "REF-LED-2 (BG-181293)", 14.0, "{ \"AVK\": 0.0484, \"RH\": 0.0198 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "REF-LED-3 (BG-319100)", 14.0, "{ \"AVK\": 0.0484, \"RH\": 0.0198 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "LED-BB [ARBPLLA00302]", 1.0, "{ \"SMT 02\": 0.069055556, \"SMT 03\": 0.069055556 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "VR-BB [ARBP01A00260]", 42.0, "{ \"AVK\": 0.018 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "REF_PASTA [1st_CM+RH 200V]", 2.0, "{ \"SMT 02\": 0.2, \"SMT 03\": 0.2 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "REF_PASTA [2nd_CM+RH 200V]", 2.0, "{ \"RH\": 0.3762, \"SMT 02\": 0.2, \"SMT 03\": 0.2 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "ACXA73-37130", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.354, \"SMT 03\": 0.354 }", "AC" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "LED-22280 [ACXE39C01000ID]", 10.0, "{ \"RH\": 0.1, \"SMT 01\": 0.048, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "LED-44600 (ACXE39C01500)", 10.0, "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-NA35R-S <A>", 3.0, "{ \"SMT 02\": 0.32, \"SMT 03\": 0.32 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-NA35R-S <B>", 3.0, "{ \"SMT 02\": 0.14, \"SMT 03\": 0.14 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-D10 [KEY/SUB-MAIN]", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.264, \"RH\": 0.314, \"SMT 01\": 0.42, \"SMT 02\": 0.363, \"SMT 03\": 0.363 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-D10 <A> [MAIN]", 8.0, "{ \"SMT 02\": 0.171, \"SMT 03\": 0.171 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-D10 <B> [MAIN]", 8.0, "{ \"SMT 02\": 0.352, \"SMT 03\": 0.352 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-U156-S", 2.0, "{ \"JVK 02\": 0.1, \"JVK 03\": 0.1, \"RH\": 0.1386, \"SMT 01\": 0.432, \"SMT 02\": 0.302, \"SMT 03\": 0.302 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-5270LJK", 2.0, "{ \"JVK 02\": 0.033, \"JVK 03\": 0.033, \"RH\": 0.1485, \"SMT 01\": 0.314765, \"SMT 02\": 0.267, \"SMT 03\": 0.267 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-562DD2GCK1", "{ \"JVK 02\": 0.2563, \"JVK 03\": 0.2563, \"RH\": 0.1914, \"SMT 01\": 0.48, \"SMT 02\": 0.45, \"SMT 03\": 0.45 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 41,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 42,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "LED-49380", 10.0, "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-52800", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-52810", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "LED-49390", 10.0, "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "1st_ACXA73-50110", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "2nd_ACXA73-50110", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.679, \"SMT 02\": 0.4, \"SMT 03\": 0.4 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "1st_ACXA73-50120", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "2nd_ACXA73-50120", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.679, \"SMT 02\": 0.4, \"SMT 03\": 0.4 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "LED-44600 (ACXE39C01500)", 10.0, "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-48700", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.679, \"SMT 02\": 0.4, \"SMT 03\": 0.4 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-53420", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "ACXA73-52820", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "ACXA73-52830", 2.0, "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.4, \"SMT 03\": 0.4 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "ACXA73-51410", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "LED-51390", "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "LED-51400", "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "ARBGBA301650", 6.0, "{ \"JVK 02\": 0.097166667, \"JVK 03\": 0.097166667, \"AVK\": 0.047666667, \"RH\": 0.091666667, \"SMT 01\": 0.47724, \"SMT 02\": 0.146666667, \"SMT 03\": 0.146666667 }", "Refrigerator" });

            migrationBuilder.InsertData(
                table: "PcbModels",
                columns: new[] { "Id", "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[,]
                {
                    { 60, "BG-213400", 14.0, "{ \"AVK\": 0.0484, \"RH\": 0.0198 }", "Refrigerator" },
                    { 61, "LED-BB [ARBPLLA00302]", 54.0, "{ \"SMT 02\": 0.069, \"SMT 03\": 0.069 }", "Refrigerator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.130, \"SMT 01\": 0.352, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.130, \"SMT 01\": 0.397, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.130, \"SMT 01\": 0.373, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.315, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.378, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.364, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.373, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.373, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.373, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-NA35R-S <A>", 3.0, "{ \"SMT 02\": 0.320, \"SMT 03\": 0.320 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-NA35R-S <B>", 3.0, "{ \"SMT 02\": 0.140, \"SMT 03\": 0.140 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-D10 <A> [MAIN]", 8.0, "{ \"SMT 02\": 0.171, \"SMT 03\": 0.171 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-D10 <B> [MAIN]", 8.0, "{ \"SMT 02\": 0.352, \"SMT 03\": 0.352 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-562DD2GCK1", 2.0, "{ \"JVK 02\": 0.256, \"JVK 03\": 0.256, \"RH\": 0.191, \"SMT 01\": 0.480, \"SMT 02\": 0.450, \"SMT 03\": 0.450 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "RF-D10 [KEY/SUB-MAIN]", 1.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.264, \"RH\": 0.314, \"SMT 01\": 0.420, \"SMT 02\": 0.363, \"SMT 03\": 0.363 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-U156-S", "{ \"JVK 02\": 0.100, \"JVK 03\": 0.100, \"RH\": 0.139, \"SMT 01\": 0.432, \"SMT 02\": 0.302, \"SMT 03\": 0.302 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-5270LJK", "{ \"JVK 02\": 0.033, \"JVK 03\": 0.033, \"RH\": 0.149, \"SMT 01\": 0.315, \"SMT 02\": 0.267, \"SMT 03\": 0.267 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-2400DEG /EB /EE", "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.108, \"SMT 01\": 0.340, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-2400DGN /LJ", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.158, \"SMT 01\": 0.244, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-2400DPC /DP", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.158, \"SMT 01\": 0.276, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-2400DGT", "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.108, \"SMT 01\": 0.344, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "RF-2450-S", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.264, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "R-2255-S", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.223, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }", "Audio" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "REF_PASTA [1st_CM+RH 100V]", 2.0, "{ \"SMT 02\": 0.260, \"SMT 03\": 0.260 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "REF_PASTA [2nd_CM+RH 100V]", 2.0, "{ \"SMT 02\": 0.260, \"SMT 03\": 0.260 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "REF_PASTA [1st_CM+RH 200V]", 2.0, "{ \"SMT 02\": 0.260, \"SMT 03\": 0.260 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "REF_PASTA [2nd_CM+RH 200V]", 2.0, "{ \"RH\": 0.376 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "ARBPC2C00670", 6.0, "{ \"JVK 02\": 0.097, \"JVK 03\": 0.097, \"AVK\": 0.048, \"RH\": 0.092, \"SMT 01\": 0.477, \"SMT 02\": 0.147, \"SMT 03\": 0.147 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "BB220", 4.0, "{ \"JVK 02\": 0.240, \"JVK 03\": 0.240, \"RH\": 0.800, \"SMT 02\": 0.469, \"SMT 03\": 0.469 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "BB240", 4.0, "{ \"JVK 02\": 0.240, \"JVK 03\": 0.240, \"RH\": 0.800, \"SMT 02\": 0.579, \"SMT 03\": 0.579 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "FREEZER [BG-188654]", 6.0, "{ \"JVK 02\": 0.097, \"JVK 03\": 0.097, \"AVK\": 0.048, \"RH\": 0.092, \"SMT 01\": 0.477, \"SMT 02\": 0.147, \"SMT 03\": 0.147 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "LED FREEZER [BG-188642]", 18.0, "{ \"RH\": 0.191, \"SMT 01\": 0.065 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "LED ARBPLLA00750 <RH>", 1.0, "{ \"AVK\": 0.048, \"RH\": 0.191 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "REF-LED-2 (BG-181293)", 1.0, "{ \"AVK\": 0.048, \"RH\": 0.020 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "REF-LED-3 (BG-319100)", "{ \"AVK\": 0.048, \"RH\": 0.020 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "LED-BB [ARBPLLA00302]", 1.0, "{ \"SMT 02\": 0.069, \"SMT 03\": 0.069 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "VR-BB [ARBP01A00260]", 1.0, "{ \"AVK\": 0.018 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "ARBGBA301650", 6.0, "{ \"JVK 02\": 0.097, \"JVK 03\": 0.097, \"AVK\": 0.048, \"RH\": 0.092, \"SMT 01\": 0.477, \"SMT 02\": 0.147, \"SMT 03\": 0.147 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "BG-213400", 14.0, "{ \"AVK\": 0.048, \"RH\": 0.020 }", "Refrigerator" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ModelCode", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "ACXA73-37130", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 41,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 42,
                column: "ProcessTimesJson",
                value: "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }");

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "ACXA73-52800", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-52810", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-48700", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "ACXA73-53420", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-52820", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-52830", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "ACXA73-51410", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "1st_ACXA73-50110", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "2nd_ACXA73-50110", 2.0, "{ \"SMT 02\": 0.400, \"SMT 03\": 0.400 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "1st_ACXA73-50120", "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "2nd_ACXA73-50120", "{ \"SMT 02\": 0.400, \"SMT 03\": 0.400 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "LED-22280 [ACXE39C01000ID]", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.048, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "LED-44600 (ACXE39C01500)", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson" },
                values: new object[] { "LED-49380", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "LED-49390", "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ModelCode", "ProcessTimesJson" },
                values: new object[] { "LED-51390", "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" });

            migrationBuilder.UpdateData(
                table: "PcbModels",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[] { "LED-51400", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" });
        }
    }
}

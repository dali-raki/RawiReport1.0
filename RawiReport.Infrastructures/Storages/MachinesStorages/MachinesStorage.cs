using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RawiReport.Domains.Models.Machines;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;


namespace RawiReport.Infrastructures.Storages.MachinesStorages;

public class MachinesStorage(IConfiguration configuration) : IMachinesStorage
{
    private readonly string _connectionString = configuration.GetConnectionString("RawiReportDatabase") ?? throw new InvalidOperationException($"Connection string is missing or empty.");

    private readonly string selectmachinesQuery = "SELECT Id,Name FROM Machine";

    private static MachineModel SelectMachinesFromDataRow(DataRow row)
    {
        return new MachineModel
        {
            MachineId = (int)row["Id"],
            MachineName = (string)row["Name"]
        };
    }

    public async ValueTask<List<MachineModel>> SelectMachines()
    {
        await using var connection = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand(selectmachinesQuery, connection);
        DataTable dt = new();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        await connection.OpenAsync();
        da.Fill(dt);

        return (from DataRow row in dt.Rows select SelectMachinesFromDataRow(row)).ToList();
    }
}

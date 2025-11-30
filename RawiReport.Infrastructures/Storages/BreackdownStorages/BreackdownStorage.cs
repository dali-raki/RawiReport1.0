using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RawiReport.Domains.Models.Breackdowns;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RawiReport.Infrastructures.Storages.BreackdownStorages;

public class BreackdownStorage(IConfiguration configuration) : IBreackdownStorage
{
    private readonly string _connectionString = configuration.GetConnectionString("RawiReportDatabase") ?? throw new InvalidOperationException($"Connection string is missing or empty.");

    private readonly string InsertBreackdownQuery = "  INSERT INTO Breakdown (Id,IdReport, IdMachine, StoppingTime, DurationStopping, Description) VALUES (@aId,@aIdReport, @aIdMachine, @aStoppingTime, @aDurationStopping, @aDescription);";


    public async ValueTask<bool> InsertAsync(BreackdownModel model)
    {
        using SqlConnection con = new(_connectionString);
        using SqlCommand cmd = new(InsertBreackdownQuery, con);
     

        cmd.Parameters.AddWithValue("@IdReport", model.ReportId);
        cmd.Parameters.AddWithValue("@IdMachine", model.MachineId);
        cmd.Parameters.AddWithValue("@StoppingTime", model.StoppingTime);
        cmd.Parameters.AddWithValue("@DurationStopping", model.DurationStopping);
        cmd.Parameters.AddWithValue("@Description", model.Description);

        await con.OpenAsync();
        object? result = await cmd.ExecuteScalarAsync();

        return true;
    }

}

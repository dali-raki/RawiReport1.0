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

    private readonly string InsertBreackdownQuery = @"INSERT INTO report.Breakdown (Id,ReportId,MachineId,StoppingTime,StoppingDuration,ErrorCode,[Description])
        VALUES(@aId,@aReportId,@aMachineId,@aStoppingTime,@aStoppingDuration,@aErrorCode,@aDescription)";

    private readonly string UpdateBreackdownQuery = @"UPDATE report.Breakdown
        SET MachineId = @aMachineId, StoppingTime = @aStoppingTime,StoppingDuration = @aStoppingDuration, ErrorCode = @aErrorCode,Description = @aDescription
        WHERE Id = @aId";

    private readonly string DeleteBreackdownQuery = @"DELETE FROM report.Breakdown
        WHERE Id = @aId";
    public async ValueTask<bool> InsertBreackdown(BreackdownModel model)
    {
        using SqlConnection con = new(_connectionString);
        using SqlCommand cmd = new(InsertBreackdownQuery, con);

        cmd.Parameters.AddWithValue("@aId", model.Id);
        cmd.Parameters.AddWithValue("@aReportId", model.ReportId);
        cmd.Parameters.AddWithValue("@aMachineId", model.MachineId);
        cmd.Parameters.AddWithValue("@aStoppingTime", model.StoppingTime);
        cmd.Parameters.AddWithValue("@aStoppingDuration", model.DurationStopping);
        cmd.Parameters.AddWithValue("@aErrorCode", model.ErrorCode);
        cmd.Parameters.AddWithValue("@aDescription",
        string.IsNullOrEmpty(model.Description) ? "No comment" : model.Description);


        await con.OpenAsync();
        object? result = await cmd.ExecuteScalarAsync();

        return true;
    }


    public async ValueTask<int> UpdateBreakdown(BreackdownModel model)
    {
        using SqlConnection con = new(_connectionString);
        using SqlCommand cmd = new(UpdateBreackdownQuery, con);

        cmd.Parameters.AddWithValue("@aId", model.Id);
        cmd.Parameters.AddWithValue("@aMachineId", model.MachineId);
        cmd.Parameters.AddWithValue("@aStoppingTime", model.StoppingTime);
        cmd.Parameters.AddWithValue("@aStoppingDuration", model.DurationStopping);
        cmd.Parameters.AddWithValue("@aErrorCode", model.ErrorCode);
        cmd.Parameters.AddWithValue("@aDescription", model.Description ?? (object)DBNull.Value);

        await con.OpenAsync();
        return await cmd.ExecuteNonQueryAsync();
    }



    public async ValueTask<int> DeleteBreakdown(Guid id)
    {
        using SqlConnection con = new(_connectionString);
        using SqlCommand cmd = new(DeleteBreackdownQuery, con);

        cmd.Parameters.AddWithValue("@aId", id);

        await con.OpenAsync();
        return await cmd.ExecuteNonQueryAsync();
    }




}

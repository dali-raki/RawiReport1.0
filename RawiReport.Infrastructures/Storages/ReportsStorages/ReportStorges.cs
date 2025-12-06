using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RawiReport.Apps.Apps.BreackdownsApps;
using RawiReport.Apps.Apps.ReportApps;
using RawiReport.Domains.Models.Breackdowns;
using RawiReport.Domains.Models.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RawiReport.Infrastructures.Storages.ReportsStorages;

public class ReportStorages(IConfiguration configuration) : IReportStorages
{
    private readonly string connectionString = configuration.GetConnectionString("RawiReportDatabase") ?? "";




    private const string SelectAllQuery = @"SELECT * FROM report.Header WHERE State = @aState ORDER BY CreateAt DESC;";


    private const string InsertHeaderQuery = @"INSERT INTO report.Header
        (Id,Leader,ProductId,Date,StartTime,EndTime,Objective,Speed,CreateBy,CreateAt,UpdateLast,State)
        VALUES(@aId,@aLeader,@aProductId,@aDate,@aStartTime,@aEndTime,@aObjective,@aSpeed,@aCreateBy,@aCreateAt,@aUpdateLast,@aState);";


    private const string UpdateHeaderQuery = @"UPDATE report.Header 
        SETProductId = @aProductId, Leader = @aLeader,Date = @aDate,StartTime = @aStartTime,EndTime = @aEndTime,
        Objective = @aObjective,Speed = @aSpeed,CreateBy = @aCreateBy,UpdateLast = @aUpdateLast,State = @aState
        WHERE Id = @aId;";

    private const string DeleteHeaderQuery = @"DELETE FROM report.Header
        WHERE Id = @aId;";

    private const string getByUdProc = "[report].[GetById]";



    public async ValueTask<ReportInfo> SelectById(Guid id)
    {
        await using var connection = new SqlConnection(connectionString);
        await using var command = new SqlCommand(getByUdProc, connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@aId", id);

        await connection.OpenAsync();

        var ds = new DataSet();
        var da = new SqlDataAdapter(command);
        da.Fill(ds);

        var reportTable = ds.Tables[0];
        var report = new ReportInfo();

        if (reportTable.Rows.Count > 0)
        {
            var row = reportTable.Rows[0];
            report.Id = (Guid)row["Id"];
            report.Leader = (string)row["Leader"];
            report.ProductId = (string)row["ProductId"];
            report.Date = DateOnly.FromDateTime((DateTime)row["Date"]);
            report.CreatedBy = (Guid)row["CreateBy"];
            report.StartTime = (DateTime)row["StartTime"];
            report.EndTime = (DateTime)row["EndTime"];
            report.Objective = (string) row["Objective"];
            report.Speed = (int)row["Speed"];
            report.CreatedAt = (DateTime)row["CreateAt"];
            report.Updatedlast = (DateTime)row["UpdateLast"];
            report.reportStatus =(ReportStatus)(int) row["State"];
        }

        var breakdownTable = ds.Tables[1];
        report.BreackdownList = new List<BreackdownInfo>();

        foreach (DataRow row in breakdownTable.Rows)
        {
            var breakdown = new BreackdownInfo
            {
                BreakdownId = (Guid)row["BreakdownId"],
                ReportId = (Guid)row["ReportId"],
                MachineId = (int)row["MachineId"],
                MachineName = row["MachineName"] as string,
                StoppingTime = (DateTime)row["StoppingTime"],
                DurationStopping = row["StoppingDuration"] as string,
                ErrorCode = (string)row["ErrorCode"],
                Description = row["Description"] as string
            };
            report.BreackdownList.Add(breakdown);
        }

        return report;
    }

    public async ValueTask<List<ReportHeaderModel>> SelectAllReportHeader(ReportStatus status)
    {
        using SqlConnection con = new(connectionString);
        using SqlCommand cmd = new(SelectAllQuery, con);

        cmd.Parameters.AddWithValue("@aState", status);

        await con.OpenAsync();
        using SqlDataReader reader = await cmd.ExecuteReaderAsync();

        List<ReportHeaderModel> list = new();
        while (await reader.ReadAsync())
            list.Add(MapHeader(reader));

        return list;
    }

    public async ValueTask<int> InsertReportHeader(ReportHeaderModel model)
    {
        using SqlConnection con = new(connectionString);
        using SqlCommand cmd = new(InsertHeaderQuery, con);

        cmd.Parameters.AddWithValue("@aId", model.Id);
        cmd.Parameters.AddWithValue("@aLeader", model.Leader);
        cmd.Parameters.AddWithValue("@aProductId", model.ProductId);
        cmd.Parameters.AddWithValue("@aDate", model.Date);
        cmd.Parameters.AddWithValue("@aStartTime", model.StartTime);
        cmd.Parameters.AddWithValue("@aEndTime", model.EndTime);
        cmd.Parameters.AddWithValue("@aObjective", model.Objective);
        cmd.Parameters.AddWithValue("@aSpeed", model.Speed);
        cmd.Parameters.AddWithValue("@aCreateBy", model.CreateBy);
        cmd.Parameters.AddWithValue("@aCreateAt", model.CreatedAt);
        cmd.Parameters.AddWithValue("@aUpdateLast", model.Updatlast);
        cmd.Parameters.AddWithValue("@aState", model.ReportStatus);

        await con.OpenAsync();
        return await cmd.ExecuteNonQueryAsync();
    }

    public async ValueTask<int> UpdateReportHeader(ReportHeaderModel model)
    {
        using SqlConnection con = new(connectionString);
        using SqlCommand cmd = new(UpdateHeaderQuery, con);

        cmd.Parameters.AddWithValue("@aId", model.Id);
        cmd.Parameters.AddWithValue("@aLeader", model.Leader);
        cmd.Parameters.AddWithValue("@aProductId", model.ProductId);
        cmd.Parameters.AddWithValue("@aDate", model.Date);
        cmd.Parameters.AddWithValue("@aStartTime", model.StartTime);
        cmd.Parameters.AddWithValue("@aEndTime", model.EndTime);
        cmd.Parameters.AddWithValue("@aObjective", model.Objective);
        cmd.Parameters.AddWithValue("@aSpeed", model.Speed);
        cmd.Parameters.AddWithValue("@aCreateBy", model.CreateBy);
        cmd.Parameters.AddWithValue("@aUpdateLast", model.Updatlast);
        cmd.Parameters.AddWithValue("@aState", model.ReportStatus);

        await con.OpenAsync();
        return await cmd.ExecuteNonQueryAsync();
    }

    public async ValueTask<int> DeleteReportHeader(Guid id)
    {
        using SqlConnection con = new(connectionString);
        using SqlCommand cmd = new(DeleteHeaderQuery, con);

        cmd.Parameters.AddWithValue("@aId", id);

        await con.OpenAsync();
        return await cmd.ExecuteNonQueryAsync();
    }



    private ReportHeaderModel MapHeader(SqlDataReader r)
    {
        return new ReportHeaderModel
        {
            Id = (Guid)r["Id"],
            Leader = (string)r["Leader"],
            ProductId = (string)r["ProductId"],
            Date = DateOnly.FromDateTime((DateTime)r["Date"]),
            StartTime = (DateTime)r["StartTime"],
            EndTime = (DateTime)r["EndTime"],
            Objective = (string)r["Objective"],
            Speed = (int)r["Speed"],
            CreateBy = (Guid)r["CreateBy"],
            CreatedAt = (DateTime)r["CreateAt"],
            Updatlast = (DateTime)r["UpdateLast"],
            ReportStatus = (ReportStatus)( (int)r["State"])
        };
    }
}

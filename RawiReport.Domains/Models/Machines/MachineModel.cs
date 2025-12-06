using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RawiReport.Domains.Models.Machines;

public class MachineModel
{
    [Required(ErrorMessage = "Machine is required")]
    public int MachineId { get; set; }
    public string MachineName { get; set; }
}

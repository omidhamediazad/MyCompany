using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Shop.Application.DTOs;

public class VerifyPaymentRequest
{
    public string Status { get; set; } = default!; // e.g. "OK", "Failed"
    public string Authority { get; set; } = default!; // gateway token
}

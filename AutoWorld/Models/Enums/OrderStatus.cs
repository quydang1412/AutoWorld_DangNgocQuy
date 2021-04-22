using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.Enums
{
    public enum OrderStatus
    {
        New = 0,
		Processing,
		Completed,
		Cancelled
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Application.DTOs.Search;
public class ServicePagedSearchDto : PagedSearch
{
    public string? Keyword { get; set; }
}

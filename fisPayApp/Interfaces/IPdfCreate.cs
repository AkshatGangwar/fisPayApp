using fisPayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Interfaces
{
    public interface IPdfCreate
    {
        Task<string> getPdf(string from, string to);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IOperationEntryService
    {
        int EditEntry(Operator_Entry data);
        int AddEntry(Operator_Entry data);
        bool AddEntryDetails(List<Operator_Entry_Detail> datas);
    }
}

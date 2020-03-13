using Statuses.ModelStatus;
using System;

namespace Statuses
{
    public interface IStatus
    {
        ModelStatusDelete DeleteRecord(bool check, string ex);
        ModelStatusInsert InsertRecord(int id, bool check, string ex);
    }
}

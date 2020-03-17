using Statuses.ModelStatus;
using System;

namespace Statuses
{
    public interface IStatus
    {
        ModelStatusDelete DeleteRecord(bool check, string ex);
        ModelStatusInsert InsertRecord(int id, bool check, string ex);
        ModelStatusUpdate UpdateRecord(int id, bool check, string result);
    }
}

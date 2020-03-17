using Statuses.ModelStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Statuses.Exception
{
    public class DataStatuses : IStatus
    {
        
        public ModelStatusDelete DeleteRecord(bool check, string ex)
        {
            ModelStatusDelete status = new ModelStatusDelete();
            if (!check)
            {
                status.Status = false;
                status.Description = ex;
            }
            else
            {
                status.Status = true;
                status.Description = "Record successful delete";
                
            }
            return status;
        }

        public ModelStatusInsert InsertRecord(int id, bool check, string ex)
        {
            ModelStatusInsert status = new ModelStatusInsert();
            status.IdModel = id;
            if (!check)
            {
                status.Description = ex;
            }
            else
            {
                status.IdModel = id;
                status.Status = true;
                status.Description = $"Record with Id = {id} successful created";

            }
            return status;
        }

        public ModelStatusUpdate UpdateRecord(int id, bool check, string result)
        {
            ModelStatusUpdate status = new ModelStatusUpdate();
            status.IdModel = id;
            if (!check)
            {
                status.Status = false;
                status.Description = result;
            }
            else
            {
                status.Status = true;
                status.Description = $"Record with Id = {id} successful updated";
                status.JsonModel = result;
            }
            return status;
        }
    }
}

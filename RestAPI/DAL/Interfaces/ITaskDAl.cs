using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface ITaskDAL
    {
        IList<SHARED.ViewModals.Task> getTasks();
        SHARED.ViewModals.Task PostTasks(SHARED.ViewModals.Task item);
        SHARED.ViewModals.Task EditTasks(int id,SHARED.ViewModals.Task item);
        IList<SHARED.ViewModals.Task> getSortedTasks(string sort);
        IList<SHARED.ViewModals.Task> getFilteredTasks(string Filter);
        IEnumerable<SHARED.ViewModals.Task> getPagination(int? pageNumber, int? pageSize);

    }
}

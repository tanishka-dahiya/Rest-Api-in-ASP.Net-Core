using System;
using System.Collections.Generic;
using System.Text;
using SHARED;

namespace BLL.Interfaces
{
    public interface ITaskBLL
    {
        IList<SHARED.ViewModals.Task> getTasks();
        SHARED.ViewModals.Task PostTasks(SHARED.ViewModals.Task item);
    }
}

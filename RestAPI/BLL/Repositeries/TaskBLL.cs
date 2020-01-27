using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositries;
using SHARED.ViewModals;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class TaskBLL: ITaskBLL
    {
        private readonly ITaskDAL taskDAL;

        public TaskBLL(ITaskDAL task)
        {
            taskDAL = task;
        }

        public IList<SHARED.ViewModals.Task> getTasks()
        {
            var IsTaskOrNull = taskDAL.getTasks();
            if (IsTaskOrNull != null)
            {
                
                return IsTaskOrNull;
            }
            else
            {
                
                return null;
            }
        }

        public SHARED.ViewModals.Task PostTasks(SHARED.ViewModals.Task item)
        {
            SHARED.ViewModals.Task PostedTask = taskDAL.PostTasks( item);
            return PostedTask;
        }

        public SHARED.ViewModals.Task EditTasks(int id,SHARED.ViewModals.Task item)
        {
            SHARED.ViewModals.Task PostedTask = taskDAL.EditTasks(id,item);
            return PostedTask;
        }



        public IList<SHARED.ViewModals.Task>  getSortedTasks(string sort)
        {
            var PostedTask = taskDAL.getSortedTasks(sort);
            return PostedTask;
        }
    }
}

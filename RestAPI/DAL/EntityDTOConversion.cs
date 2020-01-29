using System;
using System.Collections.Generic;
using System.Text;
using SHARED;
using DAL.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SHARED.ViewModals;

namespace DAL

{
   public  class EntityDTOConversion
    {


        private static MapperConfiguration config2 = new MapperConfiguration(c =>
        {
            c.CreateMap<TodoModel, SHARED.ViewModals.Task>();
        });
        private static IMapper mapper2 = config2.CreateMapper();
        public static IList<SHARED.ViewModals.Task> EntityToDTO(IList<TodoModel> evenyEntityList)
        {

            return mapper2.Map<IList<SHARED.ViewModals.Task>>(evenyEntityList);
        }





        private static MapperConfiguration config4 = new MapperConfiguration(c =>
        {
            c.CreateMap<SHARED.ViewModals.Task,TodoModel>();
        });
        private static IMapper mapper4 = config4.CreateMapper();
        public static TodoModel DTOToEntity(SHARED.ViewModals.Task evenyEntityList)
        {

            return mapper4.Map<TodoModel>(evenyEntityList);
        }

        internal static Task EntityToDTO(DbSet<TodoModel> tasks)
        {
            throw new NotImplementedException();
        }
    }
}

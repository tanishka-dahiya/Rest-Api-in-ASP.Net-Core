using System;
using System.Collections.Generic;
using System.Text;
using SHARED;
using DAL.Entities;
using AutoMapper;

namespace Conversions
{
    public class EntityDTOConversion
    {
        private static MapperConfiguration config2 = new MapperConfiguration(c =>
        {
            c.CreateMap<TodoModel, SHARED.ViewModals.Task>();
        });
        private static IMapper mapper2 = config2.CreateMapper();


        public static SHARED.ViewModals.Task EntityToDTO(TodoModel taskEntity)
        {
            return mapper2.Map<SHARED.ViewModals.Task>(taskEntity);
        }


        


    }
}

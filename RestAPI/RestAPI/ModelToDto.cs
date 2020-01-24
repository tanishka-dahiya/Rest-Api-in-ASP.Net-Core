﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHARED;


namespace RestAPI
{
    public class ModelToDto
    {
        private static MapperConfiguration config9 = new MapperConfiguration(c =>
        {
            c.CreateMap<Task, SHARED.ViewModals.Task>();
        });
        private static IMapper mapper9 = config9.CreateMapper();

        public static SHARED.ViewModals.Task ModelToDTO(Task eventDTOList)
        {
            return mapper9.Map<SHARED.ViewModals.Task>(eventDTOList);
        }





        private static MapperConfiguration config8 = new MapperConfiguration(c =>
        {
            c.CreateMap<SHARED.ViewModals.Task, Task>();
        });
        private static IMapper mapper8 = config8.CreateMapper();

        public static IList<Task> DTOToModel(IList<SHARED.ViewModals.Task> eventDTOList)
        {
            return mapper8.Map<IList<Task>>(eventDTOList);
        }


    }
}

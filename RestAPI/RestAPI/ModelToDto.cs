using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHARED;


namespace RestAPI
{   /// <summary>
/// Shared View and view modal Conversions
/// </summary>
    public class ModelToDto
    {    

        //map View modal into shared modal
        private static MapperConfiguration config9 = new MapperConfiguration(c =>
        {
            c.CreateMap<Task, SHARED.ViewModals.Task>();
        });
        private static IMapper mapper9 = config9.CreateMapper();

        public static SHARED.ViewModals.Task ModelToDTO(Task eventDTOList)
        {
            return mapper9.Map<SHARED.ViewModals.Task>(eventDTOList);
        }




        //map <IList>shared modal to <IList> View modal
        private static MapperConfiguration config8 = new MapperConfiguration(c =>
        {
            c.CreateMap<SHARED.ViewModals.Task, Task>();
        });
        private static IMapper mapper8 = config8.CreateMapper();

        public static IList<Task> DTOToModel(IList<SHARED.ViewModals.Task> eventDTOList)
        {
            return mapper8.Map<IList<Task>>(eventDTOList);
        }



        //map <IEnumerable>shared modal to <IEnumerable> View modal
        private static MapperConfiguration config10 = new MapperConfiguration(c =>
        {
            c.CreateMap<SHARED.ViewModals.Task, Task>();
        });
        private static IMapper mapper10 = config8.CreateMapper();

        public static IEnumerable<Task> DTOToModel(IEnumerable<SHARED.ViewModals.Task> eventDTOList)
        {
            return mapper10.Map<IEnumerable<Task>>(eventDTOList);
        }


    }
}

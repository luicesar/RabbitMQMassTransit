using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMassTransit.Domain.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<ClassA-Message, ClassB-Message>();
        }
    }
}

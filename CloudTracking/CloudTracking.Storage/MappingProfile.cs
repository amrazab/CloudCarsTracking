using AutoMapper;
using CloudTracking.Messages;
using CloudTracking.Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudTracking.Storage
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<PingMessage, PingLogEntry>();
            CreateMap<PingMessage, PingMessageEntity>();
            CreateMap<PingMessageEntity, PingMessage>();
        }
    }
}

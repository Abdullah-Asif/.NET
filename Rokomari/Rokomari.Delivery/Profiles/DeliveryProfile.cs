using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = Rokomari.Delivery.Entities;
using BO = Rokomari.Delivery.BusinessObjects;

namespace Rokomari.Delivery.Profiles
{
    public class DeliveryProfile : Profile
    {
        public DeliveryProfile()
        {
            CreateMap<EO.Book, BO.Book>().ReverseMap();
        }
    }
}

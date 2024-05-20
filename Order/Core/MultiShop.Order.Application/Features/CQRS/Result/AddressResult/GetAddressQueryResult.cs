using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Result.AddressResult
{
    //Adres sınıfımızdaki propertyleri tututacak ve listeleme sağlayacak.( Domain/entities/Address.cs içinde)
    //bütün listeleri getirecek
    public class GetAddressQueryResult
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}

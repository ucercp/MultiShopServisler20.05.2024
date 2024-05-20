using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bu yapı, EfCargoOperationDal sınıfının, CargoOperation nesneleriyle ilgili veritabanı
//işlemlerini gerçekleştirmek için kullanıldığını gösterir. EfCargoOperationDal sınıfı,
//GenericRepository sınıfının genel veritabanı işlemleri davranışını miras alırken,
//ICargoOperationDal arayüzü de özel işlemleri tanımlar. Böylece, EfCargoOperationDal sınıfı,
//hem genel veritabanı işlemlerini hem de CargoOperation nesnelerine özgü işlemleri gerçekleştirebilir.
namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoOperationDal:GenericRepository<CargoOperation>,ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context):base(context) { }
    }
}

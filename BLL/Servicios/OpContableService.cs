using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entidades;
namespace BLL.Servicios
{
    public class OpContableService
    {
        private readonly IOpContableRepository _opContableService;
        public OpContableService(IOpContableRepository opContableRepository) 
        {
            _opContableService = opContableRepository;
        }
        public int AddNuevaOpContable(OperacionContable _opContable) 
        {
            return _opContableService.AddOperacionContable(_opContable);
        }
    }
}

using OneBoard.Business.Abstract;
using OneBoard.Core.Business.EFBaseService;
using OneBoard.Core.DataAccess;
using OneBoard.DataAccess.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.Concrete
{
    public class ChartTypeManager : EfBaseService<IChartTypeDal, ChartType>, IChartTypeService
    {
        public ChartTypeManager(IChartTypeDal dal,IUnitOfWork unitOfWork) : base(dal,unitOfWork)
        {
        }
    }
}

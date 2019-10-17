using OneBoard.Business.Abstract;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.DataAccess.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.Concrete
{
    public class WidgetManager:IWidgetService
    {
        public IWidgetDal widgetDal;

        public WidgetManager(IWidgetDal dal)
        {
            widgetDal = dal;
        }

        public IResult Add(Widget widget)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Widget widget)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Widget>> GetWidgets()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Widget widget)
        {
            throw new NotImplementedException();
        }
    }
}

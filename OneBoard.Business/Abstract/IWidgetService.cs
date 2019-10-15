using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.Abstract
{
    public interface IWidgetService
    {
        IResult Add(Widget widget);

        IResult Update(Widget widget);

        IResult Delete(Widget widget);

        IDataResult<List<Widget>> GetWidgets();
    }
}

using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.Abstract
{
    public interface IWidgetTypeService
    {
        IResult Add(WidgetType widget);

        IResult Update(WidgetType widget);

        IResult Delete(WidgetType widget);

        IDataResult<List<WidgetType>> GetWidgetTypes();
    }
}

<<<<<<< HEAD
﻿using OneBoard.Core.Utilities.Results.Abstract;
=======
﻿using OneBoard.Core.Business;
>>>>>>> 8c801620bd8fb9e83daf0fb6aebfe4096afb9d0d
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.Abstract
{
    public interface IWidgetTypeService:IService<WidgetType>
    {
        IResult Add(WidgetType widget);

        IResult Update(WidgetType widget);

        IResult Delete(WidgetType widget);

        IDataResult<List<WidgetType>> GetWidgetTypes();
    }
}

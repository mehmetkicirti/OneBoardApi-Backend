using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.Abstract
{
    public interface IFirmService
    {
        IResult Add(Firm firm);

        IResult Update(Firm firm);

        IResult Delete(Firm firm);

        IDataResult<List<Firm>> GetFirm();
    }
}

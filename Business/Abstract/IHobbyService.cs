using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHobbyService
    {
        IDataResult<Hobby> GetById(int hobbyId);
        IDataResult<List<Hobby>> GetList();
        IResult Add(Hobby hobby);
        IResult Delete(Hobby hobby);
        IResult Update(Hobby hobby);
    }
}

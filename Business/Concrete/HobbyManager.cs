using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class HobbyManager : IHobbyService
    {
        private IHobbyDal _hobbyDal;
        public HobbyManager(IHobbyDal hobbyDal)
        {
            _hobbyDal = hobbyDal;
        }
        public IResult Add(Hobby hobby)
        {
            _hobbyDal.Add(hobby);
            return new SuccessResult(Messages.HobbyAdded);
        }

        public IResult Delete(Hobby category)
        {
             _hobbyDal.Delete(category);
            return new SuccessResult(Messages.HobbyDeleted);
        }

        public IDataResult<Hobby> GetById(int hobbyId)
        {
            return new SuccessDataResult<Hobby>(_hobbyDal.Get(i => i.Id == hobbyId));
        }

        public IDataResult<List<Hobby>> GetList()
        {
            return new SuccessDataResult<List<Hobby>>(_hobbyDal.GetList().ToList());
        }

        public IResult Update(Hobby category)
        {
            _hobbyDal.Update(category);
            return new SuccessResult(Messages.HobbyUpdated);
        }
    }
}

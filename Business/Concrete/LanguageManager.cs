using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private ILanguageDal _languageDal;
        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }
        public IDataResult<List<Language>> GetLanguages()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetList().ToList());
        }
    }
}

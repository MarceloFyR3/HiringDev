using HiringDev.INegocio.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using HiringDev.IRepositorio.Base;


namespace HiringDev.Negocio.Base
{
    public class BaseNegocio<TViewModel, T> : IBaseNegocio<TViewModel, T>, IDisposable where T : class
    {
        private readonly IBaseRepositorio<T> _baseRepositorio;
        private readonly IMapper _mapper;

        public BaseNegocio(IBaseRepositorio<T> baseRepositorio, IMapper mapper)
        {
            _baseRepositorio = baseRepositorio;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _baseRepositorio.Dispose();
        }
    }
}

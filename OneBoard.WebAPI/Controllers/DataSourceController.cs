using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBoard.Business.Abstract;
using OneBoard.Entities.Concrete;

namespace OneBoard.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourceController : ControllerBase
    {
        private IDataSourceService _iDataSourceService;
        private IMapper _iMapper;
        
        public DataSourceController(IDataSourceService dataSourceService, IMapper mapper)
        {
            _iDataSourceService = dataSourceService;
            _iMapper = mapper;
        }

        //public IActionResult Add(DataSource dataSource)
        //{
        //    var result = _iDataSourceService.Add(dataSource);
        //}
    }
}
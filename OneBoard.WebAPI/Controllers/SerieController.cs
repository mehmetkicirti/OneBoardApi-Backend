using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBoard.Business.Abstract;
using OneBoard.Core.Utilities.Extensions;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.Serie;
using OneBoard.Entities.Mapping.SerieMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private ISerieService _service;
        private IMapper mapper;

        public SerieController(ISerieService service, IMapper mapper)
        {
            this._service = service;
            this.mapper = mapper;
        }

        #region NORMAL
        [HttpPost("Add")]
        public IActionResult Add(SerieDTO serieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                mapper = SerieMapping.GetMapper().CreateMapper();

                Serie serie = mapper.Map<SerieDTO, Serie>(serieDto);

                IResult result = _service.Add(serie);

                if (result.Success)
                    return Ok(result.Message);

                return BadRequest(result.Message);
            }
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult Update(SerieDTO serieDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                IDataResult<Serie> dataResult = _service.GetById(Id);

                if (dataResult == null)
                    return BadRequest(dataResult.Message);

                else
                {
                    mapper = SerieMapping.GetMapper().CreateMapper();

                    Serie serie = mapper.Map<SerieDTO, Serie>(serieDTO);

                    IResult result = _service.Update(serie);

                    if (result.Success)
                        return Ok(result.Message);

                    return BadRequest(result.Message);
                }
            }

        }

        [HttpPut("Delete/{id:int}")]
        public IActionResult Delete(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                IDataResult<Serie> dataResult = _service.GetById(Id);

                if (dataResult == null)
                    return BadRequest(dataResult.Message);

                else
                {
                    IResult result = _service.Delete(dataResult.Data);

                    if (result.Success)
                        return Ok(result.Message);

                    return BadRequest(result.Message);
                }
            }
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            IDataResult<IList<Serie>> result = _service.GetEntityValues();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }


        #endregion

        #region Async



        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(SerieDTO serieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                mapper = SerieMapping.GetMapper().CreateMapper();

                Serie serie = mapper.Map<SerieDTO, Serie>(serieDto);

                IResult result = await _service.AddAsync(serie);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }
        }

        [HttpPut("UpdateAsync/{id:int}")]

        public async Task<IActionResult> UpdateAsync(SerieDTO serieDto, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            IDataResult<Serie> dataResult = _service.GetById(Id);

            if (dataResult == null)
                return BadRequest(dataResult.Message);

            else
            {
                mapper = SerieMapping.GetMapper().CreateMapper();
                Serie serie = mapper.Map<SerieDTO, Serie>(serieDto);
                IResult result = await _service.UpdateAsync(serie);


                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);

            }
        }


        [HttpDelete("DeleteAsync/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                IResult result = await _service.DeleteByIdAsync(Id);

                if (result.Success)
                {
                    return Ok(result.Message);
                }

                return BadRequest(result.Message);

            }
        }


        [HttpGet("GetAllAsync")]

        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<IList<Serie>> result = await _service.GetEntityValuesAsync();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByIdAsync/{id:int}")]

        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {

                IDataResult<Serie> result = await _service.FindByIdAsync(Id);

                if (result.Success)
                    return Ok(result.Data);

                return BadRequest(result.Message);
            }

        }

        #endregion
    }

}
    

    

 


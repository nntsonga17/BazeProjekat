using Microsoft.AspNetCore.Mvc;
using StambenaZgradaLibrary;
using StambenaZgradaLibrary.DTOs;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VlasnikStanaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiVlasnikeStanova")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<IActionResult> GetVlasnikeZgrade()
     {
         (bool isError, var zap, string? error) = await DataProvider.VratiSveVlasnikeStanovaAsync();

         if (isError)
         {
             return BadRequest(error);
         }

         return Ok(zap);
     }

    [HttpPost]
    [Route("DodajVlasnikaStana")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddVlasnik([FromBody] VlasnikStanaView z)
    {
        var data = await DataProvider.DodajVlasnikaAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan vlasnik stana .");
    }


    [HttpDelete]
    [Route("IzbrisiVlasnikaStana/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteVlasnik(long id)
    {
        var data = DataProvider.ObrisiVlasnika(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan vlasnik stana. ID: {id}");
    }




    [HttpGet]
    [Route("PreuzmiStanareStana/{idStan}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetStanariStana(int idStan)
    {
        (bool isError, var zap, string? error) = await DataProvider.VratiStanareZgradeiStanaAsync(idStan);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(zap);
    }


    [HttpPost]
    [Route("DodajStanara")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddStanar([FromBody] ImenaStanaraView z)
    {
        var data = await DataProvider.SacuvajImeStanaraAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan stanar .");
    }


    [HttpDelete]
    [Route("IzbrisiStanara/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteStanar(int id)
    {
        var data = DataProvider.ObrisiStanara(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan stanar. ID: {id}");
    }
}

    
using Microsoft.AspNetCore.Mvc;
using StambenaZgradaLibrary;
using StambenaZgradaLibrary.DTOs;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LiftController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiPutnickeLiftoveZgrade/{id_zgrade}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPutnickeLiftoveZgrade(int id_zgrade)
    {
        (bool isError, var liftovi, string? error) = await DataProvider.VratiPutnickeLiftoveZgradeAsync(id_zgrade);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(liftovi);
    }

    [HttpPost]
    [Route("DodajPutnickiLift")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddPutnickiLift([FromBody] PutnickiLiftView z)
    {
        var data = await DataProvider.SacuvajPutnickiLiftAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan lift.");
    }



    [HttpDelete]
    [Route("IzbrisiPutnickiLift/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeletePutnickiLift(int id)
    {
        var data = DataProvider.ObrisiPutnickiLift(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan lift. ID: {id}");
    }



    [HttpPut]
    [Route("PromeniPutnickiLift")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangePLift([FromBody] PutnickiLiftView z)
    {
        (bool isError, var lift, string? error) = await DataProvider.IzmeniPutnickiLiftAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (lift == null)
        {
            return BadRequest("Lift nije validan.");
        }

        return Ok($"Uspešno ažuriran lift. ");
    }



    [HttpGet]
    [Route("PreuzmiTeretneLiftoveZgrade/{id_zgrade}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTeretneLiftoveZgrade(int id_zgrade)
    {
        (bool isError, var liftovi, string? error) = await DataProvider.VratiTeretneLiftoveZgradeAsync(id_zgrade);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(liftovi);
    }

    [HttpPost]
    [Route("DodajTeretniLift")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddTeretniLift([FromBody] TeretniLiftView z)
    {
        var data = await DataProvider.SacuvajTeretniLiftAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan lift.");
    }



    [HttpDelete]
    [Route("IzbrisiTeretniLift/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteTeretniLift(int id)
    {
        var data = DataProvider.ObrisiTeretniLift(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan lift. ID: {id}");
    }



    [HttpPut]
    [Route("PromeniTeretniLift")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeTLift([FromBody] TeretniLiftView z)
    {
        (bool isError, var lift, string? error) = await DataProvider.IzmeniTeretniLiftAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (lift == null)
        {
            return BadRequest("Lift nije validan.");
        }

        return Ok($"Uspešno ažuriran lift. ");
    }
}



    
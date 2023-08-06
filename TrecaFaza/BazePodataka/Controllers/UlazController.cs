using Microsoft.AspNetCore.Mvc;
using StambenaZgradaLibrary;
using StambenaZgradaLibrary.DTOs;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UlazController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiUlazeZgrade/{id_zgrade}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUlazeZgrade(int id_zgrade)
    {
        (bool isError, var ulazi, string? error) = await DataProvider.VratiUlazeNekeZgradeAsync(id_zgrade);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(ulazi);
    }

    [HttpPost]
    [Route("DodajUlazUZgradu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUlaz([FromBody] UlazView z)
    {
        var data = await DataProvider.SacuvajUlazAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan ulaz.");
    }



    [HttpDelete]
    [Route("IzbrisiUlaz/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteUlaz(int id)
    {
        var data = DataProvider.ObrisiUlaz(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan ulaz. ID: {id}");
    }



    [HttpPut]
    [Route("PromeniUlaz")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeUlaz([FromBody] UlazView z)
    {
        (bool isError, var ulaz, string? error) = await DataProvider.IzmeniUlazAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (ulaz == null)
        {
            return BadRequest("Ulaz nije validan.");
        }

        return Ok($"Uspešno ažuriran ulaz. ");
    }
}



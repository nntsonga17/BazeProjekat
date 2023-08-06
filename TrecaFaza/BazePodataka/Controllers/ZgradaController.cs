using Microsoft.AspNetCore.Mvc;
using StambenaZgradaLibrary;
using StambenaZgradaLibrary.DTOs;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ZgradaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiZgrade")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetZgrade()
    {
        (bool isError, var zgrade, string? error) = await DataProvider.VratiSveZgradeAsync();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(zgrade);
    }

    [HttpPost]
    [Route("DodajZgradu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddZgrada([FromBody] ZgradaView z)
    {
        var data = await DataProvider.DodajZgraduAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisana zgrada. Adresa: {z.Mesto} , ulica: {z.Ulica} , broj: {z.Broj} .");
    }

    [HttpPut]
    [Route("PromeniZgradu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeZgrada([FromBody] ZgradaView z)
    {
        (bool isError, var zgrada, string? error) = await DataProvider.AzurirajZgraduAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (zgrada == null)
        {
            return BadRequest("Zgrada nije validna.");
        }

        return Ok($"Uspešno ažurirana zgrada. Adresa: {z.Mesto} , ulica: {z.Ulica} , broj: {z.Broj} ");
    }


    [HttpDelete]
    [Route("IzbrisiZgradu/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteZgrada(int id)
    {
        var data = DataProvider.ObrisiZgradu(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisana zgrada. ID: {id}");
    }

    [HttpGet]
    [Route("PreuzmiUgovor/{ID}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUgovor(int ID)
    {
        (bool isError, var ugovor, string? error) = await DataProvider.VratiUgovorAsync(ID);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(ugovor);
    }


    [HttpPost]
    [Route("DodajUgovor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUgovor([FromBody] UgovorView z)
    {

        var ug = await DataProvider.SacuvajUgovorAsync(z);

        if (ug.IsError)
        {
            return BadRequest(ug.Error);
        }

       

        return Ok($"Uspešno dodat ugovor.");

    }

    [HttpDelete]
    [Route("IzbrisiUgovor/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteUgovor(int id)
    {
        var data = DataProvider.ObrisiUgovor(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan ugovor. ID: {id}");
    }


}

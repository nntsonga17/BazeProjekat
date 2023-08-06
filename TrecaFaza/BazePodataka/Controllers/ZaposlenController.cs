using Microsoft.AspNetCore.Mvc;
using StambenaZgradaLibrary;
using StambenaZgradaLibrary.DTOs;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ZaposlenController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiZaposlene")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetZaposlene()
    {
        (bool isError, var zap, string? error) = await DataProvider.VratiSveZaposleneAsync();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(zap);
    }

    [HttpPost]
    [Route("DodajZaposlenog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddZaposlen([FromBody] ZaposlenView z)
    {
        var data = await DataProvider.DodajZaposlenogAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan zaposleni .");
    }

    [HttpPut]
    [Route("PromeniZaposlenog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeZaposlen([FromBody] ZaposlenView z)
    {
        (bool isError, var zap, string? error) = await DataProvider.IzmeniZaposlenogAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (zap == null)
        {
            return BadRequest("Zaposleni nije validan.");
        }

        return Ok($"Uspešno ažuriran zaposleni. ");
    }


    [HttpDelete]
    [Route("IzbrisiZaposlenog/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteZaposlen(long id)
    {
        var data = DataProvider.ObrisiZaposlenog(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan zaposleni. ID: {id}");
    }




    [HttpGet]
    [Route("PreuzmiUpravnike")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUpravnike()
    {
        (bool isError, var zap, string? error) = await DataProvider.VratiSveUpravnikeAsync();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(zap);
    }

    [HttpPost]
    [Route("DodajUpravnika")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUpravnik([FromBody] ProfesionalniUpravnikView z)
    {
        var data = await DataProvider.DodajUpravnikaAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan upravnik .");
    }

    [HttpPut]
    [Route("PromeniUpravnika")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeUpravnik([FromBody] ProfesionalniUpravnikView z)
    {
        (bool isError, var zap, string? error) = await DataProvider.IzmeniUpravnikaAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (zap == null)
        {
            return BadRequest("Upravnik nije validan.");
        }

        return Ok($"Uspešno ažuriran upravnik. ");
    }


    [HttpDelete]
    [Route("IzbrisiUpravnika/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteUpravnik(long id)
    {
        var data = DataProvider.ObrisiUpravnika(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan upravnik. ID: {id}");
    }




    [HttpGet]
    [Route("PreuzmiSveLicence")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetLicence()
    {
        (bool isError, var lic, string? error) = await DataProvider.VratiSveLicenceAsync();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(lic);
    }


    [HttpGet]
    [Route("PreuzmiLicenceUpravnika/{idUpravnik}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetLokaliZgrade(long idUpravnik)
    {
        (bool isError, var lic, string? error) = await DataProvider.VratiLicenceUpravnikaAsync(idUpravnik);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(lic);
    }

    [HttpPost]
    [Route("DodajLicencu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddLicenca([FromBody] LicencaView z)
    {
        var data = await DataProvider.SacuvajLicencuAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisana licenca .");
    }

    [HttpPut]
    [Route("PromeniLicencu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeLicenca([FromBody] LicencaView z)
    {
        (bool isError, var zap, string? error) = await DataProvider.IzmeniLicencuAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (zap == null)
        {
            return BadRequest("Licenca nije validna.");
        }

        return Ok($"Uspešno ažurirana licenca. ");
    }


    [HttpDelete]
    [Route("IzbrisiLicencu/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteLicenca(int id)
    {
        var data = DataProvider.ObrisiLicencu(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisana licenca. ID: {id}");
    }
}







    
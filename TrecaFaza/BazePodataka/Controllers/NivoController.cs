using Microsoft.AspNetCore.Mvc;
using StambenaZgradaLibrary;
using StambenaZgradaLibrary.DTOs;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class NivoController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiNivoeZgrade/{id_zgrade}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetNivoe(int id_zgrade)
    {
        (bool isError, var nivoi, string? error) = await DataProvider.VratiSveNivoeZgradeAsync(id_zgrade);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(nivoi);
    }

    [HttpPost]
    [Route("DodajStan")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddStan([FromBody] StanView z)
    {
        var data = await DataProvider.SacuvajStanAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan stan.");
    }

    [HttpPost]
    [Route("DodajLokal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddLokal([FromBody] LokalView z)
    {
        var data = await DataProvider.SacuvajLokalAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisan lokal.");
    }


    [HttpPost]
    [Route("DodajParkingMesto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddPMesto([FromBody] ParkingMestoView z)
    {
        var data = await DataProvider.SacuvajParkingMestoAsync(z);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno upisano parking mesto .");
    }


    [HttpDelete]
    [Route("IzbrisiNivo/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteNivo(int id)
    {
        var data = DataProvider.ObrisiNivo(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan nivo. ID: {id}");
    }


    [HttpPut]
    [Route("PromeniLokal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeLokal([FromBody] LokalView z)
    {
        (bool isError, var lokal, string? error) = await DataProvider.AzurirajLokalAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (lokal == null)
        {
            return BadRequest("Lokal nije validan.");
        }

        return Ok($"Uspešno ažuriran lokal. ");
    }


    [HttpPut]
    [Route("PromeniParkingMesto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangePMesto([FromBody] ParkingMestoView z)
    {
        (bool isError, var mesto, string? error) = await DataProvider.AzurirajParkingMestoAsync(z);

        if (isError)
        {
            return BadRequest(error);
        }

        if (mesto == null)
        {
            return BadRequest("Parking mesto nije validno.");
        }

        return Ok($"Uspešno ažurirano parking mesto. ");
    }


    [HttpGet]
    [Route("PreuzmiStanoveZgrade/{ID_zgrade}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetStanoviZgrade(int ID_zgrade)
    {
        (bool isError, var stanovi, string? error) = await DataProvider.VratiStanoveZgradeAsync(ID_zgrade);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(stanovi);
    }

    [HttpGet]
    [Route("PreuzmiLokaleZgrade/{ID_zgrade}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetLokaliZgrade(int ID_zgrade)
    {
        (bool isError, var lokali, string? error) = await DataProvider.VratiLokaleZgradeAsync(ID_zgrade);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(lokali);
    }

    [HttpGet]
    [Route("PreuzmiParkingMestaZgrade/{ID_zgrade}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPMestaZgrade(int ID_zgrade)
    {
        (bool isError, var mesta, string? error) = await DataProvider.VratiPMestaZgradeAsync(ID_zgrade);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(mesta);
    }

    [HttpGet]
    [Route("PreuzmiStanoveVlasnika/{ID_vlasnik}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetStanoviVlasnika(long ID_vlasnik)
    {
        (bool isError, var stanovi, string? error) = await DataProvider.VratiStanoveVlasnikaAsync(ID_vlasnik);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(stanovi);
    }


}

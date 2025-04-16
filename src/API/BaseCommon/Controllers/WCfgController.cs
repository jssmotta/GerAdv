namespace MenphisSI.BaseCommon;

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public class WCfgController(IWCfgService wcfgService) : ControllerBase
{
    private readonly IWCfgService _wcfgService = wcfgService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [HttpDelete("{key}")]
    public async Task<IActionResult> DeleteCfq(string key, [FromRoute] string uri)
    {
        _logger.Info($"Deleting CFQ with key: {key}, uri: {uri}");
        var result = await _wcfgService.DeleteCfq(key, uri);

        if (result) _logger.Info($"Successfully deleted CFQ with key: {key}, uri: {uri}");
        return Ok(result);

    }

    [HttpDelete("{key}/{oper}")]
    public async Task<IActionResult> DeleteCfq(string key, int oper, [FromRoute] string uri)
    {
        _logger.Info($"Deleting CFQ with key: {key}, oper: {oper}, uri: {uri}");
        var result = await _wcfgService.DeleteCfq(key, oper, uri);
        if (result) _logger.Info($"Successfully deleted CFQ with key: {key}, oper: {oper}, uri: {uri}");
        return Ok(result);

    }

    [HttpPost("{key}/{value}")]
    public async Task<IActionResult> SetCfq(string key, int value, [FromRoute] string uri)
    {
        _logger.Info($"Setting CFQ with key: {key}, value: {value}, uri: {uri}");
        await _wcfgService.SetCfq(key, value, uri);
        _logger.Info($"Successfully set CFQ with key: {key}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpPost("{key}/{value}")]
    public async Task<IActionResult> SetCfqC(string key, string value, [FromRoute] string uri)
    {
        _logger.Info($"Setting CFQ-C with key: {key}, value: {value}, uri: {uri}");
        await _wcfgService.SetCfqC(key, value, uri);
        _logger.Info($"Successfully set CFQ-C with key: {key}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpPost("{key}/{value}")]
    public async Task<IActionResult> SetCfqMemo(string key, string value, [FromRoute] string uri)
    {
        _logger.Info($"Setting CFQ-Memo with key: {key}, value: {value}, uri: {uri}");
        await _wcfgService.SetCfqMemo(key, value, uri);
        _logger.Info($"Successfully set CFQ-Memo with key: {key}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpPost("{key}/{oper}/{value}")]
    public async Task<IActionResult> SetCfq(string key, int oper, int value, [FromRoute] string uri)
    {
        _logger.Info($"Setting CFQ with key: {key}, oper: {oper}, value: {value}, uri: {uri}");
        await _wcfgService.SetCfq(key, oper, value, uri);
        _logger.Info($"Successfully set CFQ with key: {key}, oper: {oper}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpPost("{key}/{oper}/{value}")]
    public async Task<IActionResult> SetCfqC(string key, int oper, string value, [FromRoute] string uri)
    {
        _logger.Info($"Setting CFQ-C with key: {key}, oper: {oper}, value: {value}, uri: {uri}");
        await _wcfgService.SetCfqC(key, oper, value, uri);
        _logger.Info($"Successfully set CFQ-C with key: {key}, oper: {oper}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpPost("{key}/{oper}/{value}")]
    public async Task<IActionResult> SetCfqMemo(string key, int oper, string value, [FromRoute] string uri)
    {
        _logger.Info($"Setting CFQ-Memo with key: {key}, oper: {oper}, value: {value}, uri: {uri}");
        await _wcfgService.SetCfqMemo(key, oper, value, uri);
        _logger.Info($"Successfully set CFQ-Memo with key: {key}, oper: {oper}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpPost("{id}/{key}/{value}")]
    public async Task<IActionResult> SetTCfq(int id, string key, int value, [FromRoute] string uri)
    {
        _logger.Info($"Setting TCFQ with id: {id}, key: {key}, value: {value}, uri: {uri}");
        await _wcfgService.SetTCfq(id, key, value, uri);
        _logger.Info($"Successfully set TCFQ with id: {id}, key: {key}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpPost("{id}/{key}/{value}")]
    public async Task<IActionResult> SetTCfqC(int id, string key, string value, [FromRoute] string uri)
    {
        _logger.Info($"Setting TCFQ-C with id: {id}, key: {key}, value: {value}, uri: {uri}");
        await _wcfgService.SetTCfqC(id, key, value, uri);
        _logger.Info($"Successfully set TCFQ-C with id: {id}, key: {key}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpPost("{id}/{key}/{value}")]
    public async Task<IActionResult> SetTCfqMemo(int id, string key, string value, [FromRoute] string uri)
    {
        _logger.Info($"Setting TCFQ-Memo with id: {id}, key: {key}, value: {value}, uri: {uri}");
        await _wcfgService.SetTCfqMemo(id, key, value, uri);
        _logger.Info($"Successfully set TCFQ-Memo with id: {id}, key: {key}, value: {value}, uri: {uri}");
        return Ok();
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetCfq(string key, [FromRoute] string uri)
    {
        _logger.Info($"Getting CFQ with key: {key}, uri: {uri}");
        var result = await _wcfgService.GetCfq(key, uri);
        _logger.Info($"Successfully got CFQ with key: {key}, uri: {uri}");
        return Ok(result);
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetCfqC(string key, [FromRoute] string uri)
    {
        _logger.Info($"Getting CFQ-C with key: {key}, uri: {uri}");
        var result = await _wcfgService.GetCfqC(key, uri);
        _logger.Info($"Successfully got CFQ-C with key: {key}, uri: {uri}");
        return Ok(result);
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetCfqMemo(string key, [FromRoute] string uri)
    {
        _logger.Info($"Getting CFQ-Memo with key: {key}, uri: {uri}");
        var result = await _wcfgService.GetCfqMemo(key, uri);
        _logger.Info($"Successfully got CFQ-Memo with key: {key}, uri: {uri}");
        return Ok(result);
    }

    [HttpGet("{key}/{oper}")]
    public async Task<IActionResult> GetCfq(string key, int oper, [FromRoute] string uri)
    {
        _logger.Info($"Getting CFQ with key: {key}, oper: {oper}, uri: {uri}");
        var result = await _wcfgService.GetCfq(key, oper, uri);
        _logger.Info($"Successfully got CFQ with key: {key}, oper: {oper}, uri: {uri}");
        return Ok(result);
    }

    [HttpGet("{key}/{oper}")]
    public async Task<IActionResult> GetCfqC(string key, int oper, [FromRoute] string uri)
    {
        _logger.Info($"Getting CFQ-C with key: {key}, oper: {oper}, uri: {uri}");
        var result = await _wcfgService.GetCfqC(key, oper, uri);
        _logger.Info($"Successfully got CFQ-C with key: {key}, oper: {oper}, uri: {uri}");
        return Ok(result);
    }

    [HttpGet("{key}/{oper}")]
    public async Task<IActionResult> GetCfqMemo(string key, int oper, [FromRoute] string uri)
    {
        _logger.Info($"Getting CFQ-Memo with key: {key}, oper: {oper}, uri: {uri}");
        var result = await _wcfgService.GetCfqMemo(key, oper, uri);
        _logger.Info($"Successfully got CFQ-Memo with key: {key}, oper: {oper}, uri: {uri}");
        return Ok(result);
    }

    [HttpGet("{id}/{key}")]
    public async Task<IActionResult> GetTCfq(int id, string key, [FromRoute] string uri)
    {
        _logger.Info($"Getting TCFQ with id: {id}, key: {key}, uri: {uri}");
        var result = await _wcfgService.GetTCfq(id, key, uri);
        _logger.Info($"Successfully got TCFQ with id: {id}, key: {key}, uri: {uri}");
        return Ok(result);
    }

    [HttpGet("{id}/{key}")]
    public async Task<IActionResult> GetTCfqC(int id, string key, [FromRoute] string uri)
    {
        _logger.Info($"Getting TCFQ-C with id: {id}, key: {key}, uri: {uri}");
        var result = await _wcfgService.GetTCfqC(id, key, uri);
        _logger.Info($"Successfully got TCFQ-C with id: {id}, key: {key}, uri: {uri}");
        return Ok(result);
    }

    [HttpGet("{id}/{key}")]
    public async Task<IActionResult> GetTCfqMemo(int id, string key, [FromRoute] string uri)
    {
        _logger.Info($"Getting TCFQ-Memo with id: {id}, key: {key}, uri: {uri}");
        var result = await _wcfgService.GetTCfqMemo(id, key, uri);
        _logger.Info($"Successfully got TCFQ-Memo with id: {id}, key: {key}, uri: {uri}");
        return Ok(result);
    }
}

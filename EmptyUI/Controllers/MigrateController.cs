using AudioApp.Logic.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

public class MigrateController : Controller 
{
    readonly IMigrateService _migrateService;
    public MigrateController(IMigrateService migrateService)
    {
        _migrateService = migrateService;
    }
    [Route("migrate")]
    public void Migrate() 
    {
        _migrateService.MigrateDatabase();
    }
}
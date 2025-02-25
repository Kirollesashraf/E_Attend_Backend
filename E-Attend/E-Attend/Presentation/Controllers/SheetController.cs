using E_Attend.Entities.Models;
using E_Attend.Service.Sheet;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("/sheet")]
[ApiController]
public class SheetController : ControllerBase {
    private readonly ISheetService _sheetService;

    public SheetController(ISheetService sheetService) {
        this._sheetService = sheetService;
    }

    [HttpPost("/add-sheet")]
    public async Task<IActionResult> Add([FromBody] Sheet sheet) =>
        Ok(await _sheetService.AddSheetAsync(sheet));

    [HttpPost("/update-sheet/{sheetId}")]
    public async Task<IActionResult> Update(int sheetId, [FromBody] Sheet updatedSheet) =>
        Ok(await _sheetService.UpdateSheetAsync(sheetId, updatedSheet));

    [HttpPost("/view-sheet/{sheetId}")]
    public async Task<OkObjectResult> View(int sheetId) =>
        Ok(await _sheetService.ViewSheetAsync(sheetId));

    [HttpPost("/delete-sheet/{sheetId}")]
    public async Task<IActionResult> Delete(int sheetId) =>
        Ok(await _sheetService.DeleteSheetAsync(sheetId));

    // [HttpPost("/upload-sheet/{sheetId}")]
    // public async Task<IActionResult> Upload(int sheetId, [FromBody] byte[] fileData) =>
    //     Ok(await _sheetService.UploadSheetAsync(sheetId, fileData));
}
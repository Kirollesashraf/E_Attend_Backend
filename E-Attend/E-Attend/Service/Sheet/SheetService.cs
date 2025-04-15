using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Sheet;

public class SheetService : ISheetService
{
    private readonly IUnitOfWork unitOfWork;

    public SheetService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<Entities.Models.Sheet>> AddSheetAsync(Entities.Models.Sheet sheet)
    {
        await unitOfWork.SheetRepository.AddAsync(sheet);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<Entities.Models.Sheet>.Success(sheet, "Sheet added successfully.");
    }

    public async Task<GeneralResponse<object>> UpdateSheetAsync(int sheetId, Entities.Models.Sheet updatedSheet)
    {
        var sheet = await unitOfWork.SheetRepository.GetFirstOrDefaultAsync(s => s.ID == sheetId);
        if (sheet == null)
            return GeneralResponse<object>.Error("Sheet not found.");

        sheet.CourseID = updatedSheet.CourseID;
        sheet.Titel = updatedSheet.Titel;
        sheet.FilePath = updatedSheet.FilePath;
        sheet.UploadedAt = updatedSheet.UploadedAt;

        await unitOfWork.SheetRepository.UpdateAsync(sheet);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Sheet updated successfully.");
    }

    public async Task<GeneralResponse<Entities.Models.Sheet>> ViewSheetAsync(int sheetId)
    {
        var sheet = await unitOfWork.SheetRepository.GetFirstOrDefaultAsync(s => s.ID == sheetId);
        return sheet == null
            ? GeneralResponse<Entities.Models.Sheet>.Error("Sheet not found.")
            : GeneralResponse<Entities.Models.Sheet>.Success(sheet);

    }

    public async Task<GeneralResponse<object>> DeleteSheetAsync(int sheetId)
    {
        var sheet = await unitOfWork.SheetRepository.GetFirstOrDefaultAsync(s => s.ID == sheetId);
        if (sheet == null)
            return GeneralResponse<object>.Error("Sheet not found.");

        await unitOfWork.SheetRepository.RemoveAsync(sheet);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Sheet deleted successfully.");
    }

    public async Task<GeneralResponse<object>> UploadSheetAsync(int sheetId, byte[] fileData)
    {
        // Implement your upload logic here.  This remains unchanged from the previous example.
        return GeneralResponse<object>.Error("Upload not implemented");
    }
}
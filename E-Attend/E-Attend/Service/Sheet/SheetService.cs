using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Sheet;

public class SheetService : ISheetService {
    private readonly IUnitOfWork unitOfWork;

    public SheetService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> AddSheetAsync(Entities.Models.Sheet sheet) {
        await unitOfWork.SheetRepository.AddAsync(sheet);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> UpdateSheetAsync(int sheetId, Entities.Models.Sheet updatedSheet) {
        var sheet = await unitOfWork.SheetRepository.GetFirstOrDefaultAsync(s => s.ID == sheetId);
        if (sheet == null) throw new KeyNotFoundException("Sheet not found.");

        sheet.CourseID = updatedSheet.CourseID;
        sheet.Titel = updatedSheet.Titel;
        sheet.FilePath = updatedSheet.FilePath;
        sheet.UploadedAt = updatedSheet.UploadedAt;

        await unitOfWork.SheetRepository.UpdateAsync(sheet);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<Entities.Models.Sheet> ViewSheetAsync(int sheetId) {
        return await unitOfWork.SheetRepository.GetFirstOrDefaultAsync(s => s.ID == sheetId) ?? throw new KeyNotFoundException("Sheet not found.");
    }

    public async Task<bool> DeleteSheetAsync(int sheetId) {
        var sheet = await unitOfWork.SheetRepository.GetFirstOrDefaultAsync(s => s.ID == sheetId);
        if (sheet == null) throw new KeyNotFoundException("Sheet not found.");

        await unitOfWork.SheetRepository.RemoveAsync(sheet);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> UploadSheetAsync(int sheetId, byte[] fileData) {
        // var sheet = await unitOfWork.SheetRepository.GetFirstOrDefaultAsync(s => s.ID == sheetId);
        // if (sheet == null) throw new KeyNotFoundException("Sheet not found.");
        //
        // sheet.FileData = fileData;
        // await unitOfWork.SheetRepository.UpdateAsync(sheet);
        // await unitOfWork.CompleteAsync();
        // return true;
        throw new NotImplementedException();
    }
}

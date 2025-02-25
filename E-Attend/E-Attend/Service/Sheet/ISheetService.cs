using E_Attend.Entities.Models;

namespace E_Attend.Service.Sheet
{
    public interface ISheetService
    {
        Task<bool> AddSheetAsync(Entities.Models.Sheet sheet);
        Task<bool> UpdateSheetAsync(int sheetId, Entities.Models.Sheet updatedSheet);
        Task<Entities.Models.Sheet> ViewSheetAsync(int sheetId);
        Task<bool> DeleteSheetAsync(int sheetId);
        Task<bool> UploadSheetAsync(int sheetId, byte[] fileData);
   
    }
}

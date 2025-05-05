using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Sheet
{
    public interface ISheetService
    {
        Task<GeneralResponse<Entities.Models.Sheet>> AddSheetAsync(Entities.Models.Sheet sheet);
        Task<GeneralResponse<object>> UpdateSheetAsync(string sheetId, Entities.Models.Sheet updatedSheet);
        Task<GeneralResponse<Entities.Models.Sheet>> ViewSheetAsync(string sheetId);
        Task<GeneralResponse<object>> DeleteSheetAsync(string sheetId);
        //Task<GeneralResponse<object>> UploadSheetAsync(int sheetId, byte[] fileData);
    }
}
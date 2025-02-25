namespace E_Attend.Service.Sheet
{
    public interface ISheetService
    {
        Task<bool> AddSheetAsync(Sheet sheet);
        Task<bool> UpdateSheetAsync(int sheetId, Sheet updatedSheet);
        Task<Sheet> ViewSheetAsync(int sheetId);
        Task<bool> DeleteSheetAsync(int sheetId);
        Task<bool> UploadSheetAsync(int sheetId, byte[] fileData);
   
    }
}

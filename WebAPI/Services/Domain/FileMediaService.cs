using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public class FileMediaService : IFileMediaService
    {
        private DataContext _context;

        public FileMediaService(DataContext context)
        {
            _context = context;
        }
		public int AddFile(File_Media fileData)
		{
			try
			{
				_context.File_Media.Add(fileData);
				int num = _context.SaveChanges();
				if (num > 0)
				{
					return fileData.Id;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return -1;
		}

		public File_Media GetMediaName(int part_id)
		{
			try
			{
				var query = (from filemedia in _context.File_Media							 
							 where filemedia.Part_Id == part_id
							 select new
							 {
								 filemedia.File_Type,
								 filemedia.File_Name,
								 filemedia.Content_Type,
								 filemedia.File_Url
							 }).FirstOrDefault();
				File_Media fileDownload = new File_Media();
				fileDownload.File_Type = query.File_Type;
				fileDownload.File_Name = query.File_Name;
				fileDownload.Content_Type = query.Content_Type;
				fileDownload.File_Url = query.File_Url;
				return fileDownload;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

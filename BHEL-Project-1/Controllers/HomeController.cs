using BHEL_Project_1.Data;
using BHEL_Project_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;


namespace BHEL_Project_1.Controllers
{
    public class HomeController : Controller
    {
		private readonly ApplicationDBContext _context;
		private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context)
        {
            _logger = logger;

			_context = context;
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult>ComponentMasterPartial()
        {

             return PartialView("_ComponentMaster", await _context.ComponentMaster.ToListAsync());
		}
        public async Task<IActionResult>ComponentTypeMasterPartial()
		{
            var componentTypeMasters = _context.ComponentTypeMaster.Include(c => c.ComponentMaster);
            return PartialView("_ComponentTypeMaster", await componentTypeMasters.ToListAsync());  
		}
		[HttpPost]
		public async Task<IActionResult> UploadExcel(IFormFile file)
		{
			//Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			if (file != null && file.Length > 0)
			{
				var uploadFolder = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads\\";
				if (!Directory.Exists(uploadFolder))
				{
					Directory.CreateDirectory(uploadFolder);
				}
				var filePath = Path.Combine(uploadFolder, file.FileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);
				}
				using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
				{

					using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
					{

						do
						{
							//bool isHeaderSkipped = false;
							int headerLines=5;
							while (reader.Read())
							{
								if (headerLines!=0)
								{
									headerLines--;
									continue;
								}
								var name = reader.GetValue(2).ToString();
								// reader.GetDouble(0);
								//School school = new School();
								//school.Name = reader.GetValue(1).ToString();
								//school.Marks = Convert.ToInt32(reader.GetValue(2));

								//_context.Add(school);
								//await _context.SaveChangesAsync();

							}
						} while (reader.NextResult());


					}
				}
			}
			return View();
		}

	}
}
    
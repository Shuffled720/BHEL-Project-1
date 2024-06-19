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
							int headerLines=5;//to skip 5 lines of header in excel sheet
							while (reader.Read())
							{
								if (headerLines != 0)
								{
									headerLines--;
									continue;
								}
								if(reader.GetValue(0)==null)//to stop code from reading useless data from sheet and break
                                {
                                    break;
                                }
								var componentMasterName= reader.GetValue(1).ToString();
								int id=_context.ComponentMaster.Where(x=>x.Component_Name==componentMasterName).Select(x=>x.ComponentMasterId).FirstOrDefault<int>();
								if (id == 0) //if component master not found
								{
									ComponentMaster componentMaster = new ComponentMaster();
									componentMaster.Component_Name = reader.GetValue(1).ToString();
									componentMaster.Component_Ref_Name= reader.GetValue(2).ToString();
									componentMaster.Updated_By = "Admin";
									
									_context.Add(componentMaster);
									await _context.SaveChangesAsync();
								}
								//now finding the id of the component master
                                 id = _context.ComponentMaster.Where(x => x.Component_Name == componentMasterName).Select(x => x.ComponentMasterId).FirstOrDefault<int>();


                                ComponentTypeMaster componentTypeMaster = new ComponentTypeMaster();
								componentTypeMaster.Identity_Number= reader.GetValue(3).ToString();
								componentTypeMaster.Make = reader.GetValue(5).ToString();
								componentTypeMaster.Is_Ind = true;
								componentTypeMaster.Location = reader.GetValue(7).ToString();
								componentTypeMaster.Reference_Doc = reader.GetValue(8).ToString();
								componentTypeMaster.Is_BOI = true;
                                componentTypeMaster.Applicable_Item_Id = 4;//doubt regarding this
                                componentTypeMaster.ComponentMasterId= id;
								_context.Add(componentTypeMaster);
								await _context.SaveChangesAsync();
							}
						} while (reader.NextResult());


					}
				}
			}
			return View("Index");
		}

	}
}
    
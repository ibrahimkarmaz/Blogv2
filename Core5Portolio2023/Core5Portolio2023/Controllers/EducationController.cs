using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.IO;

namespace Core5Portolio2023.Controllers
{
	public class EducationController : Controller
	{
		EducationManager _educationManager = new EducationManager(new EFEducationDAL());
		public IActionResult Index()
		{
			return View();
		}
		public JsonResult EducationList()
		{
			var values = _educationManager.TGetAllList();
			var educationConvert = JsonConvert.SerializeObject(values);
			return Json(educationConvert);
		}

		
		public IActionResult StatusPagesSet(int id)
		{
			var values = _educationManager.TGetById(id);
			if (values.EducationArchive)
				values.EducationArchive = false;
			else
				values.EducationArchive = true;

			_educationManager.TUpdate(values);
			var educationConvert = JsonConvert.SerializeObject(values);
			return Json(educationConvert);
		}

		[HttpPost]
		public IActionResult EducationDelete(int id)
		{
			var values = _educationManager.TGetById(id);
			_educationManager.TDelete(values);
			var educationConvert = JsonConvert.SerializeObject(values);
			return Json(educationConvert);
		}

		[HttpPost]
		public IActionResult EducationContent(int id)
		{
			var values = _educationManager.TGetById(id);
			var educationConvert = JsonConvert.SerializeObject(values);
			return Json(educationConvert);
		}

		[HttpPost]
		public IActionResult AddEducation(Education education)
		{
			if (education.EducationArchive)
			{
				education.EducationArchive = false;
			}
			else
			{
				education.EducationArchive = true;
			}
			_educationManager.TAdd(education);
			return Json(education);
		}
		public IActionResult EducationGetById(int id)
		{
			var values = _educationManager.TGetById(id);

			if (values.EducationArchive)
			{
				values.EducationArchive = false;
			}
			else
			{
				values.EducationArchive = true;
			}
			var EducationConvert = JsonConvert.SerializeObject(values);
			return Json(EducationConvert);
		}

		[HttpPost]
		public IActionResult EducationUpdate(Education education)
		{
			if (education.EducationArchive)
			{
				education.EducationArchive = false;
			}
			else
			{
				education.EducationArchive = true;
			}
			_educationManager.TUpdate(education);
			return Json(education);
		}
		public IActionResult EducationExcelList()
		{
			using (var workbook = new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("EgitimListesi");
				worksheet.Cell(1, 1).Value = "EĞİTİM ID";
				worksheet.Cell(1, 2).Value = "OKUL ADI";
				worksheet.Cell(1, 3).Value = "ALAN ADI";
				worksheet.Cell(1, 4).Value = "ALAN İÇERİĞİ";
				worksheet.Cell(1, 5).Value = "BAŞLANGIÇ TARİHİ";
				worksheet.Cell(1, 6).Value = "BİTİŞ TARİHİ";
				worksheet.Cell(1, 7).Value = "DEVAM EDİYOR MU ?";

				int countrow = 2;
				foreach (var veri in _educationManager.TGetAllList())
				{
					worksheet.Cell(countrow, 1).Value = veri.EducationID;
					worksheet.Cell(countrow, 2).Value = veri.EducationSchoolName;
					worksheet.Cell(countrow, 3).Value = veri.EducationSectionName;
					worksheet.Cell(countrow, 4).Value = veri.EducationContent;
					worksheet.Cell(countrow, 5).Value = veri.EducationStartYear;
					worksheet.Cell(countrow, 6).Value = veri.EducationStopYear;
					worksheet.Cell(countrow, 7).Value = veri.EducationContinue ? "Evet" : "Hayır";
					//DEVAM EDİYOR MU KISMININ RENGİNİ TURUNCU YAPTIM.
					if (veri.EducationContinue)
						worksheet.Cell(countrow, 7).Style.Fill.SetBackgroundColor(XLColor.Orange);


					worksheet.Cell(countrow, 1).Style.Font.SetBold();
					//İÇERİKLERİ ORTALAR
					worksheet.Row(countrow).CellsUsed().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
					countrow++;
				}


				//STİL İŞLEMLERİ
				worksheet.Row(1).CellsUsed().Style.Font.SetBold();
				worksheet.Row(1).CellsUsed().Style.Font.SetFontSize(12);
				worksheet.Row(1).CellsUsed().Style.Fill.SetBackgroundColor(XLColor.Gray);

				//Hücrelerin genişliğini otomatik ayarlama
				worksheet.Columns().AdjustToContents();

				using (var stream = new MemoryStream())
				{
					workbook.SaveAs(stream);
					var context = stream.ToArray();
					return File(context, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DosyaEgitim.xlsx");

				}
			}
		}
	}
}

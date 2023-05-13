using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace Core5Portolio2023.Controllers
{
	public class SummaryController : Controller
	{
		SummaryManager _summaryManager = new SummaryManager(new EFSummaryDAL());
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult SummaryList()
		{
			var values = _summaryManager.TGetAllList();
			var jsonSummary = JsonConvert.SerializeObject(values);
			return Json(jsonSummary);
		}

		public IActionResult StatusPagesSet(int id)
		{
			var idbilgisi = _summaryManager.TGetById(id);
			if (idbilgisi.SummaryArchive)
			{
				idbilgisi.SummaryArchive = false;
			}
			else
			{
				idbilgisi.SummaryArchive = true;
			}
			_summaryManager.TUpdate(idbilgisi);

			var jsonSummary = JsonConvert.SerializeObject(idbilgisi);
			return Json(jsonSummary);
		}
		[HttpPost]
		public IActionResult SummaryDelete(int id)
		{
			var idbilgisi = _summaryManager.TGetById(id);
			_summaryManager.TDelete(idbilgisi);
			var jsonConvert = JsonConvert.SerializeObject(idbilgisi);
			return Json(jsonConvert);
		}

		public IActionResult SummaryContent(int id)
		{
			var idbilgisi = _summaryManager.TGetById(id);
			var jsonConvert = JsonConvert.SerializeObject(idbilgisi);
			return Json(jsonConvert);
		}

		/*	[HttpPost]
			public IActionResult AddExperience(Experience information)
			{
				if (information.ExperienceArchive)
				{
					information.ExperienceArchive = false;
				}
				else
				{
					information.ExperienceArchive = true;
				}
				_experienceManager.TAdd(information);
				return Json(information);
			}*/
		/*[HttpPost]
		public IActionResult UpdateExperienceGet(int id)
		{
			var idbilgisi = _experienceManager.TGetById(id);
			if (idbilgisi.ExperienceArchive)
			{
				idbilgisi.ExperienceArchive = false;
			}
			else
			{
				idbilgisi.ExperienceArchive = true;
			}
			var jsonExperience = JsonConvert.SerializeObject(idbilgisi);
			return Json(jsonExperience);
		}*/

		/*[HttpPost]
		public JsonResult UpdateExperience(Experience information)
		{
			if (information.ExperienceArchive)
			{
				information.ExperienceArchive = false;
			}
			else
			{
				information.ExperienceArchive = true;
			}
			_experienceManager.TUpdate(information);
			return Json(information);
		}*/
		
		public IActionResult ExcelList()
		{
			using (var workbook = new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("OzetListesi");
				worksheet.Cell(1, 1).Value = "ÖZET ID";
				worksheet.Cell(1, 2).Value = "ÖZET BAŞLIĞI";
				worksheet.Cell(1, 3).Value = "ÖZET İÇERİĞİ";

				int countrow = 2;
				foreach (var veri in _summaryManager.TGetAllList())
				{
					worksheet.Cell(countrow, 1).Value = veri.SummaryID;
					worksheet.Cell(countrow, 2).Value = veri.SummaryTitle;
					worksheet.Cell(countrow, 3).Value = veri.SummaryContent;

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
					return File(context, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DosyaOzet.xlsx");

				}
			}
		}
	}
}
/*
 *KAYNAKÇA EXCELLE İLGİLİ:
 *https://enestas.net/Detay/asp-net-core-ile-closedxml-kullanimi-excel-disa-aktarma-2
 */

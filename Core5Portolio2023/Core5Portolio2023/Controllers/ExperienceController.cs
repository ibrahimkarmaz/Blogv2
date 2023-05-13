using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using ClosedXML.Excel;
using System.IO;

namespace Core5Portolio2023.Controllers
{
	public class ExperienceController : Controller
	{
		ExperienceManager _experienceManager = new ExperienceManager(new EFExperienceDAL());
		public IActionResult Index()
		{
			var values = _experienceManager.TGetAllList();
			return View(values);
		}

		public IActionResult ExperienceList()
		{
			var values = _experienceManager.TGetAllList();
			var jsonExperience = JsonConvert.SerializeObject(values);
			return Json(jsonExperience);
		}

		public IActionResult StatusPagesSet(int id)
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
			_experienceManager.TUpdate(idbilgisi);

			var jsonExperience = JsonConvert.SerializeObject(idbilgisi);
			return Json(jsonExperience);
		}
		[HttpPost]
		public IActionResult ExperienceDelete(int id)
		{
			var idbilgisi = _experienceManager.TGetById(id);
			_experienceManager.TDelete(idbilgisi);
			var jsonExperience = JsonConvert.SerializeObject(idbilgisi);
			return Json(jsonExperience);
		}

		public IActionResult ExperienceContent(int id)
		{
			var idbilgisi = _experienceManager.TGetById(id);
			var jsonExperience = JsonConvert.SerializeObject(idbilgisi);
			return Json(jsonExperience);
		}

		[HttpPost]
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
		}
		[HttpPost]
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
		}

		[HttpPost]
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
		}

		public IActionResult ExportExcelList()
		{
			using (var workbook=new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("DeneyimListesi");
				worksheet.Cell(1, 1).Value = "DENEYİM ID";
				worksheet.Cell(1, 2).Value = "FİRMA ADI";
				worksheet.Cell(1, 3).Value = "MESLEK";
				worksheet.Cell(1, 4).Value = "İŞ İÇERİĞİ";
				worksheet.Cell(1, 5).Value = "BAŞLANGIÇ TARİHİ";
				worksheet.Cell(1, 6).Value = "BİTİŞ TARİHİ";
				worksheet.Cell(1, 7).Value = "DEVAM EDİYOR MU ?";

				int countrow = 2;
				foreach (var veri in _experienceManager.TGetAllList())
				{
					worksheet.Cell(countrow, 1).Value = veri.ExperienceID;
					worksheet.Cell(countrow, 2).Value = veri.ExperienceCompanyName;
					worksheet.Cell(countrow, 3).Value = veri.ExperienceJobName;
					worksheet.Cell(countrow, 4).Value = veri.ExperienceContext;
					worksheet.Cell(countrow, 5).Value = veri.ExperienceStartYear;
					worksheet.Cell(countrow, 6).Value = veri.ExperienceStopYear;
					worksheet.Cell(countrow, 7).Value = veri.ExperienceContinue? "Evet":"Hayır";
					//DEVAM EDİYOR MU KISMININ RENGİNİ TURUNCU YAPTIM.
					if (veri.ExperienceContinue)
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

				using (var stream=new MemoryStream())
				{
					workbook.SaveAs(stream);
					var context = stream.ToArray();
					return File(context, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DosyaDeneyim.xlsx");

				}
			}
		}
	}
}
/*
 *KAYNAKÇA EXCELLE İLGİLİ:
 *https://enestas.net/Detay/asp-net-core-ile-closedxml-kullanimi-excel-disa-aktarma-2
 */
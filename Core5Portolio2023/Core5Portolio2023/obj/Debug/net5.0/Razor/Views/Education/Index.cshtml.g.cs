#pragma checksum "C:\Users\ibrah\OneDrive\Masaüstü\Core5Portolio2023\Core5Portolio2023\Views\Education\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7dc35a807ebc16990d9596f29be459cfd392ec91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Education_Index), @"mvc.1.0.view", @"/Views/Education/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ibrah\OneDrive\Masaüstü\Core5Portolio2023\Core5Portolio2023\Views\_ViewImports.cshtml"
using Core5Portolio2023;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ibrah\OneDrive\Masaüstü\Core5Portolio2023\Core5Portolio2023\Views\_ViewImports.cshtml"
using Core5Portolio2023.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dc35a807ebc16990d9596f29be459cfd392ec91", @"/Views/Education/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1823000a85f965eb4c95aa8f390f8bf2e184bb79", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Education_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ibrah\OneDrive\Masaüstü\Core5Portolio2023\Core5Portolio2023\Views\Education\Index.cshtml"
  
	ViewData["Title"] = "Index";
	Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
	<h1>Eğitim Sayfası</h1>
	<p>Eğitim işlemlerinizi yapabilir veya Özgeçmiş sayfa görünülüklerini düzenleyebilirsiniz.</p>
</div>

<div class=""d-flex flex-column flex-md-row"">
	<button class=""btn btn-outline-dark flex-fill m-1 shadow"" id=""educationadd"">
		<i class=""bi bi-plus-circle-fill""></i> Yeni Eğitim
	</button>
	<button class=""btn btn-outline-dark flex-fill  m-1 shadow"" id=""educatiogetlist"">
		<i class=""bi bi-list""></i>
		Listele/Yenile
	</button>
	<button class=""btn btn-outline-dark flex-fill  m-1 shadow"" onclick=educatioExcelList()>
		<i class=""bi bi-cloud-arrow-down-fill""></i>
		Excel Döküman İndir
	</button>
</div>
<div id=""educationlist"">
	Eğitim Listesi
</div>


");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
	<script>

		function educatioExcelList(){
			window.open(""/Education/EducationExcelList"");
		}


		function GetListX() {
			$.ajax({
				contentType: ""application/json"",
				dataType: ""json"",
				type: ""Get"",
				url: ""/Education/EducationList"",
				success: function (func) {
					let w = jQuery.parseJSON(func);
					console.log(w);
					let tablehtml = ""<table class='table table-light table-responsive text-center shadow'>"" +
						""<thead>"" +
						""<tr>"" +
						""<th>#</th><th>Okul Adı</th><th>Alan Adı</th><th>Başlangıç Yılı</th><th>Bitiş Yılı</th><th>Eğitim Durumu</th><th>Sayfa Durumu</th><th>Aksiyon</th>"" +
						""</tr>"" +
						""</thead>"" +
						""<tbody class='table-hover'>"";
					$.each(w, (index, value) => {
						let id = value.EducationID.toString();
						tablehtml += `<tr>
																												<th>${id}</th>
																														<td>${value.EducationSchoolName}</td>
																																<td>${value.EducationSectionName}</td>
														");
                WriteLiteral(@"																		<td> `; let startyear = new Date(value.EducationStartYear).getFullYear();

						tablehtml += `	${startyear}	</td>
																																		<td>`; let stopyear = new Date(value.EducationStopYear).getFullYear();
						tablehtml += `${stopyear} </td>
																								<td>`;


						if (value.EducationContinue == true) {
							tablehtml += `	<span class=""badge rounded-pill bg-warning text-dark"">Evet</span> `;
						}
						else {
							tablehtml += `<span class=""badge rounded-pill bg-light text-dark"">Hayır</span>`;
						}


						tablehtml += `	</td>
																										<td>`;
						if (value.EducationArchive == true) {
							tablehtml += `	<span class=""badge rounded-pill bg-success"">Açık</span> `;
						}
						else {
							tablehtml += `	<span class=""badge rounded-pill bg-danger""> Kapalı </span> `;
						}

						tablehtml += `	</td>

																								<td>
																									<!-- Example single danger button -->
												");
                WriteLiteral(@"													<div class=""btn-group"">
																										<button type=""button"" class=""btn btn-danger dropdown-toggle rounded-pill"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button>
																										<ul class=""dropdown-menu"">
																																							<li><a class=""dropdown-item"" onclick=EducationGetById(""${id}""); ><i class=""bi bi-pencil-fill"" ></i> Düzenle</a></li>
																																	<li><a class=""dropdown-item"" onclick=EducationDelete(""${id}"");><i class=""bi bi-trash3-fill""></i> Sil</a></li>
																											<li><hr class=""dropdown-divider""></li>
																																																			<li><a class=""dropdown-item"" onclick=EducationPagesSet(""${id}"");><i class=""bi bi-gear-fill"" ></i> Sayfa durumunu değiştir</a></li>
																											<li><hr class=""dropdown-divider""></li>
																																											<li><a class=""dropdown-item"" onclick=EducationContentGet(""${id}"");><i class=""bi bi-eye-fill"" ></i> Deneyim içeri");
                WriteLiteral(@"ğini göster</a></li>
																										</ul>
																									</div>
																								</td>
																							</tr>`;
					});
					tablehtml += ""	</tbody></table>"";
					$(""#educationlist"").html(tablehtml);
				}
			});
		}

		$(document).ready(function () {
			GetListX();
		});

		$(""#educatiogetlist"").click(function () {
			GetListX();
		});
		function EducationPagesSet(a) {
			console.log(a);
			$.ajax({
				contentType: ""application/json"",
				dataType: ""json"",
				type: ""get"",
				url: ""/Education/StatusPagesSet/"" + a,
				data: { id: a },
				success: function (func) {
					GetListX();
				}
			});
		}

		function EducationDelete(a) {

			Swal.fire({
				title: 'Emin misiniz?',
				text: ""Seçilen bilgiler silinicektir."",
				icon: 'Uyarı',
				showCancelButton: true,
				confirmButtonColor: '#3085d6',
				cancelButtonColor: '#d33',
				confirmButtonText: 'Evet',
				cancelButtonText: 'Hayır',
			}).then((result) => {

				if (res");
                WriteLiteral(@"ult.isConfirmed) {
					EDelete(a);//Silme İşlemi (Evet demesi durumunda)
					const Toast = Swal.mixin({
						toast: true,
						position: 'top-end',
						showConfirmButton: false,
						timer: 2000,
						timerProgressBar: true,
						didOpen: (toast) => {
							toast.addEventListener('mouseenter', Swal.stopTimer)
							toast.addEventListener('mouseleave', Swal.resumeTimer)
						}
					})
					Toast.fire({
						icon: 'success',
						title: 'Silindi!'
					})

				}
			})
		};
		function EDelete(a) {
			console.log(a);
			$.ajax({
				contentType: ""application/json"",
				dataType: ""json"",
				type: ""post"",
				url: ""/Education/EducationDelete/"" + a,
				success: function (func) {
					GetListX();
				}
			});
		}

		function EducationContentGet(a) {
			console.log(a);
			$.ajax({
				contentType: ""application/json"",
				dataType: ""json"",
				type: ""post"",
				url: ""/Education/EducationContent/"" + a,
				success: function (func) {
					let exp = jQuery.parseJSO");
                WriteLiteral(@"N(func);
					console.log(exp);
					Swal.fire(
						exp.EducationSchoolName,
						exp.EducationContent,
						'info'
					)
				}
			});
		}

		$(""#educationadd"").click(async function () {

			const { value: formValues } = await Swal.fire({
				title: 'Yeni Eğitim',
				showCancelButton: true,
				cancelButtonColor: '#d43f3a',
				cancelButtonText: 'İptal Et',
				confirmButtonText: 'Kaydet',
				confirmButtonColor: '#337ab7',
				html:
					'<input id=""EducationSchoolName"" placeholder=""Okul Adını Giriniz"" class=""swal2-input"">' +
					'<input id=""EducationSectionName"" placeholder=""Alan Adını Giriniz"" class=""swal2-input"">' +
					'<input  id=""EducationStartYear""  type=""date"" style=""width:70%;"" placeholder=""Başlangıç Yılı (00.00.0000)"" class=""swal2-input"">' +
					'<input id=""EducationStopYear""  type=""date"" style=""width:70%;"" placeholder=""Bitiş Yılı (00.00.0000)"" class=""swal2-input"">' +
					'<textarea rows=""10"" cols=""22"" id=""EducationContent"" placeholder=""Eğitim hayatınız hakkında b");
                WriteLiteral(@"ilgi veriniz."" class=""swal2-textarea""> </textarea>' +
					'<h5>Devam Ediyorum <input type=""checkbox"" id=""EducationContinue"" /></h5><p/>' +
					'<h5>Özgeçmiş sayfasında gösterme <input type=""checkbox"" id=""EducationArchive"" /></h5>',
				focusConfirm: false,
				preConfirm: () => {

					return [
						document.getElementById('EducationSchoolName').value,
						document.getElementById('EducationSectionName').value,
						document.getElementById('EducationStartYear').value,
						document.getElementById('EducationStopYear').value,
						document.getElementById('EducationContent').value,
						document.getElementById('EducationContinue').checked,
						document.getElementById('EducationArchive').checked

					]
				}
			});
			//Checkbox'tan veri getir. ve gönder.
			$.ajax({
				url: '/Education/AddEducation/',
				type: 'Post',
				dataType: 'json',
				data: {
					EducationSchoolName: formValues[0],
					EducationSectionName: formValues[1],
					EducationStartYear: formValues[2],
");
                WriteLiteral(@"					EducationStopYear: formValues[3],
					EducationContent: formValues[4],
					EducationContinue: formValues[5],
					EducationArchive: formValues[6]

				},
				success: function (gelen) {
					const Toast = Swal.mixin({
						toast: true,
						position: 'top-end',
						showConfirmButton: false,
						timer: 2000,
						timerProgressBar: true,
						didOpen: (toast) => {
							toast.addEventListener('mouseenter', Swal.stopTimer)
							toast.addEventListener('mouseleave', Swal.resumeTimer)
						}
					})

					Toast.fire({
						icon: 'success',
						title: 'Kaydedildi!'
					})
					GetListX();
				}
			});

		});
		function EducationGetById(id) {

			$.ajax({
				contentType: ""application/json"",
				dataType: ""json"",
				type: ""get"",
				url: ""/Education/EducationGetById/"" + id,
				success: function (func) {
					let exp=jQuery.parseJSON(func);
					EducationUpdate(exp);
					
				}
			});
		};

		async function EducationUpdate(data){
			console.log(data");
                WriteLiteral(@");
			let date = new Date(data.EducationStartYear).toISOString().split('T')[0];
			let date2 = new Date(data.EducationStopYear).toISOString().split('T')[0];
			const { value: formValuesGet } = await Swal.fire({
				title: 'Deneyimi Düzenle',
				showCancelButton: true,
				cancelButtonColor: '#d43f3a',
				cancelButtonText: 'İptal Et',
				confirmButtonText: 'Düzenle',
				confirmButtonColor: '#32CD32',
				html:
					'<input id=""EducationSchoolNameGet"" placeholder=""Okul Adını Giriniz"" class=""swal2-input"" value=' + data.EducationSchoolName + '>' +
					'<input id=""EducationSectionNameGet"" placeholder=""Meslek Adını Giriniz"" class=""swal2-input"" value=' + data.EducationSectionName + '>' +
					'<input id=""EducationStartYearGet""  type=""date"" style=""width:70%;"" placeholder=""Başlangıç Yılı (00.00.0000)"" class=""swal2-input"" value=' + date + '>' +
					'<input id=""EducationStopYearGet""  type=""date"" style=""width:70%;"" placeholder=""Bitiş Yılı (00.00.0000)"" class=""swal2-input"" value=' + date2 + '> ' +
			");
                WriteLiteral(@"		'<textarea rows=""10"" cols=""22"" id=""EducationContentGet"" placeholder=""Firma içinde ne iş yaptığınız hakkında bilgi veriniz."" class=""swal2-textarea""> ' + data.EducationContent + ' </textarea>' +
					'<h5>Devam Ediyorum <input type=""checkbox"" id=""EducationContinueGet"" ' + (data.EducationContinue ? 'checked' : '') + '/></h5><p/>' +
					'<h5>Özgeçmiş sayfasında gösterme <input type=""checkbox"" id=""EducationArchiveGet"" ' + (data.EducationArchive ? 'checked' : '') + ' /></h5>',
				focusConfirm: false,
				preConfirm: () => {

					return [
						data.EducationID,
						document.getElementById('EducationSchoolNameGet').value,
						document.getElementById('EducationSectionNameGet').value,
						document.getElementById('EducationStartYearGet').value,
						document.getElementById('EducationStopYearGet').value,
						document.getElementById('EducationContentGet').value,
						document.getElementById('EducationContinueGet').checked,
						document.getElementById('EducationArchiveGet').checked

					]");
                WriteLiteral(@"
				}
			});
			//dsdas
			console.log('dada')
			$.ajax({
				url: '/Education/EducationUpdate/',
				type: 'Post',
				dataType: 'json',
				data: {
					EducationID: formValuesGet[0],
					EducationSchoolName: formValuesGet[1],
					EducationSectionName: formValuesGet[2],
					EducationStartYear: formValuesGet[3],
					EducationStopYear: formValuesGet[4],
					EducationContent: formValuesGet[5],
					EducationContinue: formValuesGet[6],
					EducationArchive: formValuesGet[7],


				},
				success: function (getdate) {
					const Toast = Swal.mixin({
						toast: true,
						position: 'top-end',
						showConfirmButton: false,
						timer: 2000,
						timerProgressBar: true,
						didOpen: (toast) => {
							toast.addEventListener('mouseenter', Swal.stopTimer)
							toast.addEventListener('mouseleave', Swal.resumeTimer)
						}
					})

					Toast.fire({
						icon: 'success',
						title: 'Düzenlendi!'
					})
					GetListX();
				}
			});
		}
	</script>
");
            }
            );
            WriteLiteral("<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.2/font/bootstrap-icons.css\">");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

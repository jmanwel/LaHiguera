
using Entidades.Models;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Snippets.Font;
using System.Reflection;

namespace Servicios
{
    public static class PacientePdfService
    {
        public static Array GeneratePdfHistory(dynamic patient)
        {

            if (PdfSharp.Fonts.GlobalFontSettings.FontResolver is null)
            {
                GlobalFontSettings.FontResolver = new NewFontResolver();
            }

            var document = new PdfDocument();
            document.Info.Title = "Historia Clínica Paciente: " + patient.information.Nombre + " " + patient.information.Apellido;

            DrawPatientInformationPage(document, patient);

            if (patient.background.Count > 0)
            {
                DrawBackgroundPage(document, patient);
            }

            if (patient.history.Count > 0)
            {
                DrawHistoryPage(document, patient);
            }

            if (patient.consultations.Count > 0)
            {
                DrawConsultationPage(document, patient);
            }

            if (patient.pediatry.Count > 0)
            {
                DrawPediatryPage(document, patient);
            }

            if (patient.ginecology.Count > 0)
            {
                DrawGinecologyPage(document, patient);
            }

            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }

            return response;
        }


        // Drawing Pages
        private static void DrawGinecologyPage(PdfDocument document, dynamic patient)
        {
            int maximumSectionsOnPage = 3;
            int pageCount = patient.ginecology.Count % maximumSectionsOnPage == 0 ? patient.ginecology.Count / maximumSectionsOnPage : patient.ginecology.Count / maximumSectionsOnPage + 1;
            int index = 0;

            for (int i = 0; i < pageCount; i++)
            {

                PdfPage page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Draw sections
                drawHeader(gfx, patient);

                for (int j = 0; j < maximumSectionsOnPage; j++)
                {
                    if (patient.ginecology.Count > index)
                    {
                        DrawGinecologyInformation(gfx, patient.ginecology[index], index, j);
                    }
                    index++;
                }
            }

        }
        private static void DrawPediatryPage(PdfDocument document, dynamic patient)
        {
            int maximumSectionsOnPage = 3;
            int pageCount = patient.pediatry.Count % maximumSectionsOnPage == 0 ? patient.pediatry.Count / maximumSectionsOnPage : patient.pediatry.Count / maximumSectionsOnPage + 1;
            int index = 0;

            for (int i = 0; i < pageCount; i++)
            {

                PdfPage page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Draw sections
                drawHeader(gfx, patient);

                for (int j = 0; j < maximumSectionsOnPage; j++)
                {
                    if (patient.pediatry.Count > index)
                    {
                        DrawPediatryInformation(gfx, patient.pediatry[index], index, j);
                    }
                    index++;
                }
            }

        }
        private static void DrawConsultationPage(PdfDocument document, dynamic patient)
        {
            int maximumSectionsOnPage = 6;
            int pageCount = patient.consultations.Count % maximumSectionsOnPage == 0 ? patient.consultations.Count / maximumSectionsOnPage : patient.consultations.Count / maximumSectionsOnPage + 1;
            int index = 0;

            for (int i = 0; i < pageCount; i++)
            {

                PdfPage page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Draw sections
                drawHeader(gfx, patient);

                for (int j = 0; j < maximumSectionsOnPage; j++)
                {
                    if (patient.consultations.Count > index)
                    {
                        DrawConsultationInformation(gfx, patient.consultations[index], index, j);
                    }
                    index++;
                }
            }

        }

        private static void DrawHistoryPage(PdfDocument document, dynamic patient)
        {
            int maximumSectionsOnPage = 2;
            int pageCount = patient.history.Count % maximumSectionsOnPage == 0 ? patient.history.Count / maximumSectionsOnPage : patient.history.Count / maximumSectionsOnPage + 1;
            int index = 0;

            for (int i = 0; i < pageCount; i++)
            {

                PdfPage page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Draw sections
                drawHeader(gfx, patient);

                for (int j = 0; j < maximumSectionsOnPage; j++)
                {
                    if (patient.history.Count > index)
                    {
                        DrawHistoryInformation(gfx, patient.history[index], index, j);
                    }
                    index++;
                }
            }

        }
        private static void DrawBackgroundPage(PdfDocument document, dynamic patient)
        {
            int maximumSectionsOnPage = 2;
            int pageCount = patient.background.Count % maximumSectionsOnPage == 0 ? patient.background.Count / maximumSectionsOnPage : patient.background.Count / maximumSectionsOnPage + 1;
            int index = 0;

            for (int i = 0; i < pageCount; i++) {

                PdfPage page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Draw sections
                drawHeader(gfx, patient);

                for (int j = 0; j < maximumSectionsOnPage; j++) {
                    if (patient.background.Count > index) { 
                        DrawBackgroundInformation(gfx, patient.background[index], index, j);
                    }
                    index++;
                }
            }

        }

        private static void DrawPatientInformationPage(PdfDocument document, dynamic patient)
        {
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;

            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Draw sections
            drawHeader(gfx, patient);
            DrawPatientInformation(gfx, patient);

            if (patient.complementary != null)
            {
                DrawComplementaryInformation(gfx, patient);
            }
        }

        // Drawing Generals
        private static void DrawTitle(XGraphics gfx, string title, double xPosition, double yPosition, string fontName = "Arial", int fontSize = 20)
        {

            XFont font = new XFont(fontName, fontSize);

            gfx.DrawString(title, font, XBrushes.Black,
            new XRect(xPosition, yPosition, 240, 270), XStringFormats.TopLeft);

        }

        private static void DrawImageScaled(XGraphics gfx)
        {
            XImage image = XImage.FromFile(Directory.GetCurrentDirectory() + "/wwwroot/img/LaHiguera_logo.png");
            gfx.DrawImage(image, 10, 0, 100, 100);
        }
        private static void drawHeader(XGraphics gfx, dynamic patient)
        {
            DrawTitle(gfx,"Historia Clínica Paciente",105, 25);
            DrawTitle(gfx, patient.information.Nombre + " " + patient.information.Apellido, 105, 50);
            DrawImageScaled(gfx);
        }


        // Drawing Sections
        private static void DrawPatientInformation(XGraphics gfx, dynamic patient)
        {
            double startingY = 110;
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Datos Filiatorios", 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Nombre: " + patient.information.Nombre, font, XBrushes.Black, new XRect(20, rectStartingX, 210/2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("DNI: " + patient.information.Dni, font, XBrushes.Black, new XRect(20, rectStartingX + rectSize, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Sexo: " + patient.information.Sexo, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Activo: " + (patient.information.FlgActivo == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("Apellido: " + patient.information.Apellido, font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Fecha Nacimiento: " + patient.information.FechaNac.ToString(), font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Paraje Atención: " + patient.information.ParajeAtencion, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Fecha Alta: " + patient.information.FechaAlta.ToString(), font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawComplementaryInformation(XGraphics gfx, dynamic patient)
        {
            double startingY = 225;
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Datos Complementarios", 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Lugar Nacimiento: " + patient.complementary.LugarNac, font, XBrushes.Black, new XRect(20, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Paraje Residencia: " + patient.complementary.ParajeResidencia, font, XBrushes.Black, new XRect(20, rectStartingX + rectSize, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Etnia: " + patient.complementary.Etnia, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Estado Civil: " + patient.complementary.EstadoCivil, font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("¿Sabe Leer?: " + (patient.complementary.SabeLeer == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Escolaridad: " + patient.complementary.Escolaridad, font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Ocupación: " + patient.complementary.Ocupacion, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Año Ingreso: " + patient.complementary.AnoIngreso.ToString(), font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // notes
            gfx.DrawString("Notas:", font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString(patient.complementary.Notas, font, XBrushes.Black, new XRect(20, rectStartingX + (5 * rectSize), 210 - 20, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawBackgroundInformation(XGraphics gfx, dynamic background, int backgroundCount, int backgroundPosition)
        {
            double sectionSizeY = 325;
            double startingY = 110 + (sectionSizeY * backgroundPosition);
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Antecedente Nº" + (backgroundCount + 1), 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Sedentarismo: " + (background.Sedentarismo == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Alcohol: " + (background.Alcohol == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Consumo Drogas: " + (background.Drogas == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Tabaco: " + (background.Tabaco == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Alergias: " + (background.Alergias == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Dbt: " + (background.Dbt == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Hta: " + (background.Dbt == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Displemia: " + (background.Dbt == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Obesidad: " + (background.Obesidad == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (8 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Chagas: " + (background.Chagas == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (9 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Hidatidosis: " + (background.Hidatidosis == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (10 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("Tbc: " + (background.Tbc == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Cáncer: " + (background.Cancer == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Quirúrgicos: " + (background.Cancer == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Riesgo Nutricional: " + (background.RiesgoNut == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Riesgo Social: " + (background.RiesgoSoc == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Personales: " + (background.Personales == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Familiares: " + (background.Familiares == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Hospitalizaciones: " + (background.Hospitalizaciones == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Antecedentes Perinatales: " + (background.AntPerinatales == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (8 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Vacunación: " + (background.Vacunacion == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (9 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Medicación: " + (background.Medicacion == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (10 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // creation date
            gfx.DrawString("Fecha Creación: " + background.FechaCreacion.ToString(), font, XBrushes.Black, new XRect(20, rectStartingX + (11 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // notes
            gfx.DrawString("Notas:", font, XBrushes.Black, new XRect(20, rectStartingX + (12 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString(background.Notas ?? "", font, XBrushes.Black, new XRect(20, rectStartingX + (13 * rectSize), 210 - 20, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawHistoryInformation(XGraphics gfx, dynamic history, int backgroundCount, int backgroundPosition)
        {
            double sectionSizeY = 355;
            double startingY = 110 + (sectionSizeY * backgroundPosition);
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Historia Nº" + (backgroundCount + 1), 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Exámen Físico: " + history.ExamenFisico, font, XBrushes.Black, new XRect(20, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Tensión Arterial: " + history.Ta, font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Peso (Kg): " + history.Peso, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Talla (Mt): " + history.Talla, font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Imc (Kg/M²): " + history.Imc, font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Circunferencia Cintura: " + history.CircCintura, font, XBrushes.Black, new XRect(20, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Circunferencia Cadera: " + history.CircCadera, font, XBrushes.Black, new XRect(20, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Saturación (%): " + history.Saturacion, font, XBrushes.Black, new XRect(20, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Temperatura (ºC): " + history.Temperatura, font, XBrushes.Black, new XRect(20, rectStartingX + (8 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Glicemia (mg/dl): " + history.Glicemia, font, XBrushes.Black, new XRect(20, rectStartingX + (9 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Agudeza Visual Ojo Derecho: " + history.AgudezaDer, font, XBrushes.Black, new XRect(20, rectStartingX + (10 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Agudeza Visual Ojo Izquierdo: " + history.AgudezaIzq, font, XBrushes.Black, new XRect(20, rectStartingX + (11 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Derivación Aguda: " + (history.DerivacionAguda==1? "Si": "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (12 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Derivación: " + history.ObservacionDeriv, font, XBrushes.Black, new XRect(20, rectStartingX + (13 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);


            // second column
            gfx.DrawString("Ecografía: " + (history.Ecografia == 1 ? "Si":"No"), font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Ecografía: " + history.ObservacionEco, font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Ecg: " + (history.Ecg == 1 ? "Si":"No"), font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Ecg: " + history.ObservacionEcg, font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Radiografía: " +( history.Radiografia == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Radiografía: " + history.ObservacionRadiografia, font, XBrushes.Black, new XRect(275, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Laboratorio: " + (history.Laboratorio == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Laboratorio: " + history.ObservacionLab, font, XBrushes.Black, new XRect(275, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Estudios Complementarios: " + history.EstudiosComp, font, XBrushes.Black, new XRect(275, rectStartingX + (8 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Diagnóstico: " + history.Diagnostico, font, XBrushes.Black, new XRect(275, rectStartingX + (9 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Tratamiento: " + history.Tratamiento, font, XBrushes.Black, new XRect(275, rectStartingX + (10 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Derivación Programada: " + (history.DerivacionProg==1?"Si":"No"), font, XBrushes.Black, new XRect(275, rectStartingX + (11 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);


            // creation date
            gfx.DrawString("Fecha Creación: " + history.FechaCreacion.ToString(), font, XBrushes.Black, new XRect(20, rectStartingX + (14 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawConsultationInformation(XGraphics gfx, dynamic consultation, int backgroundCount, int backgroundPosition)
        {
            double sectionSizeY = 110;
            double startingY = 110 + (sectionSizeY * backgroundPosition);
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Consulta Nº" + (backgroundCount + 1), 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Fecha de Creación: " + consultation.FechaAtencion.ToString(), font, XBrushes.Black, new XRect(20, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Diagnóstico Consulta: " + consultation.DiagnosticoConsulta, font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Evaluación Nutricional: " + consultation.EvalNutric, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("Motivo Consulta: " + consultation.MotivoConsulta, font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación: " + consultation.Observacion, font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Evaluación Social: " + consultation.EvalSoc, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawPediatryInformation(XGraphics gfx, dynamic pediatry, int backgroundCount, int backgroundPosition)
        {
            double sectionSizeY = 210;
            double startingY = 110 + (sectionSizeY * backgroundPosition);
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Consulta Pediátrica Nº" + (backgroundCount + 1), 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Peso: " + pediatry.Peso, font, XBrushes.Black, new XRect(20, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Percentil Peso: " + pediatry.PercentilPeso, font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("PzPeso: " + pediatry.PzPeso, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Talla: " + pediatry.Talla, font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Percentil Talla: " + pediatry.PercentilTalla, font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("PzTalla: " + pediatry.PzTalla, font, XBrushes.Black, new XRect(20, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Agudeza Visual Ojo Der: " + pediatry.AgudezaDer, font, XBrushes.Black, new XRect(20, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("Imc: " + pediatry.Imc, font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("PercentilImc: " + pediatry.PercentilImc, font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("PzImc: " + pediatry.PzImc, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Pc: " + pediatry.Pc, font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Percentil Pc: " + pediatry.PercentilPc, font, XBrushes.Black, new XRect(275, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("PzPc: " + pediatry.PzPc, font, XBrushes.Black, new XRect(275, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Agudeza Visual Ojo Izq: " + pediatry.AgudezaIzq, font, XBrushes.Black, new XRect(275, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // creation date
            gfx.DrawString("Fecha Creación: " + pediatry.FechaCreacion.ToString(), font, XBrushes.Black, new XRect(20, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawGinecologyInformation(XGraphics gfx, dynamic ginecology, int backgroundCount, int backgroundPosition)
        {
            double sectionSizeY = 200;
            double startingY = 110 + (sectionSizeY * backgroundPosition);
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Consulta Ginecológica Nº" + (backgroundCount + 1), 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Gestas: " + ginecology.Gestas, font, XBrushes.Black, new XRect(20, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Para: " + ginecology.Para, font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Cesáreas: " + ginecology.Cesareas, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Abortos: " + ginecology.Abortos, font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Inicio Rel. Sexuales (Irs): " + ginecology.Irs, font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Menarca: " + ginecology.Menarca, font, XBrushes.Black, new XRect(20, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("Ritmo Menstrual: " + ginecology.RitmoMenst, font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Menopausia: " + ginecology.Menopausia, font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Toma Pap: " + ginecology.TomaPap, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Resultado Pap: " + ginecology.ResultadoPap, font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Colposcopía: " + ginecology.Colposcopia, font, XBrushes.Black, new XRect(275, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Estudios Complementarios: " + ginecology.EstudiosComp, font, XBrushes.Black, new XRect(275, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // creation date
            gfx.DrawString("Fecha Creación: " + ginecology.FechaCreacion.ToString(), font, XBrushes.Black, new XRect(20, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
        }
    }
}

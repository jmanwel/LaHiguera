
using Entidades.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace Servicios
{
    public static class PacientePdfService
    {
        public static byte[] GeneratePdfHistory(Paciente patient)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Historia Clínica Paciente: " + patient.Nombre + " " + patient.Apellido;

            DrawPatientInformationPage(document, patient);

            if (patient.Antecedentes.Count > 0)
            {
                DrawDynamicPage(document, patient, PageType.Background, 2);

            }

            if (patient.Consultas.Count > 0)
            {
                DrawDynamicPage(document, patient, PageType.Consultations, 1);

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

        private static void DrawDynamicPage(PdfDocument document, Paciente patient, PageType type, int sectionsOnPage=2)
        {
            int maximumSectionsOnPage = sectionsOnPage;
            dynamic patientCollection = null;
            int index = 0;

            switch (type)
            {
                case PageType.Consultations:
                    patientCollection = patient.Consultas;
                    break;
                case PageType.Background:
                    patientCollection = patient.Antecedentes;
                    break;
            }

            int pageCount = patientCollection.Count % maximumSectionsOnPage == 0 ? patientCollection.Count / maximumSectionsOnPage : patientCollection.Count / maximumSectionsOnPage + 1;

            for (int i = 0; i < pageCount; i++)
            {

                PdfPage page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;

                XGraphics gfx = XGraphics.FromPdfPage(page);
                XSize pageSize = gfx.PageSize;

                // Draw sections
                drawHeader(gfx, patient);

                for (int j = 0; j < maximumSectionsOnPage; j++)
                {
                    if (patientCollection.Count > index)
                    {
                        switch (type)
                        {
                            case PageType.Consultations:
                                DrawConsultationInformation(gfx, patientCollection[index], index, j);
                                break;
                            case PageType.Background:
                                DrawBackgroundInformation(gfx, patientCollection[index], index, j);
                                break;
                        }
                    }
                    index++;
                }
                drawFooter(gfx, document.PageCount, pageSize.Width, pageSize.Height);
            }

        }

        private static void DrawPatientInformationPage(PdfDocument document, Paciente patient)
        {
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XSize pageSize = gfx.PageSize;

            // Draw sections
            drawHeader(gfx, patient);

            DrawPatientInformation(gfx, patient);          
            DrawComplementaryInformation(gfx, patient);
    
            drawFooter(gfx, document.PageCount, pageSize.Width, pageSize.Height);
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

        private static void drawHeader(XGraphics gfx, Paciente patient)
        {
            DrawTitle(gfx, "Historia Clínica Paciente", 105, 25);
            DrawTitle(gfx, patient.Nombre + " " + patient.Apellido, 105, 50);
            DrawImageScaled(gfx);
        }

        private static void drawFooter(XGraphics gfx, int pageNumber, double pageWidth, double pageHeight)
        {
            XFont font = new XFont("Arial", 12);
            XRect box = new XRect(0,-10, pageWidth, pageHeight);

            gfx.DrawString(String.Format("-{0}-", pageNumber), font, XBrushes.Black, box, XStringFormats.BottomCenter);
        }


        // Drawing Sections
        private static void DrawPatientInformation(XGraphics gfx, Paciente patient)
        {
            double startingY = 110;
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Datos Filiatorios", 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Nombre: " + patient.Nombre, font, XBrushes.Black, new XRect(20, rectStartingX + (0 * rectSize), 210/2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("DNI: " + patient.Dni, font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Sexo: " + patient.Sexo, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Activo: " + (patient.FlgActivo == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("Apellido: " + patient.Apellido, font, XBrushes.Black, new XRect(275, rectStartingX + (0 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Fecha Nacimiento: " + patient.FechaNac.ToString(), font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Paraje Atención: " + patient.ParajeAtencion, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Fecha Alta: " + patient.FechaAlta.ToString(), font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawComplementaryInformation(XGraphics gfx, Paciente patient)
        {
            Complementario datosComplementarios = patient.Complementarios.FirstOrDefault() ?? new Complementario();
            double startingY = 225;
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Datos Complementarios", 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Lugar Nacimiento: " + patient.LugarNac, font, XBrushes.Black, new XRect(20, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Paraje Atención: " + patient.ParajeAtencion, font, XBrushes.Black, new XRect(20, rectStartingX + rectSize, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Etnia: " + (patient.Etnia != null ? patient.Etnia.Nombre : ""), font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Estado Civil: " + (datosComplementarios.EstadoCivil == null ? "" : datosComplementarios.EstadoCivil.Descripcion) , font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("¿Sabe Leer?: " + (datosComplementarios.SabeLeer == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Escolaridad: " + (datosComplementarios.Escolaridad != null ? datosComplementarios.Escolaridad.Descripcion : ""), font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Ocupación: " + datosComplementarios.Ocupacion, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Año Ingreso: " + patient.AnoIngreso.ToString(), font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // notes
            gfx.DrawString("Notas:", font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString(datosComplementarios.Notas ?? "", font, XBrushes.Black, new XRect(20, rectStartingX + (5 * rectSize), 210 - 20, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawBackgroundInformation(XGraphics gfx, Antecedente background, int backgroundCount, int backgroundPosition)
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
            gfx.DrawString("Hta: " + (background.Hta == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Dislipemia: " + (background.Dislipemia == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Obesidad: " + (background.Obesidad == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (8 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Chagas: " + (background.Chagas == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (9 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Hidatidosis: " + (background.Hidatidosis == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (10 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("Tbc: " + (background.Tbc == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX, 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Cáncer: " + (background.Cancer == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Quirúrgicos: " + (background.Cancer == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Riesgo Nutricional: " + (background.RiesgoNut == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Riesgo Social: " + (background.RiesgoSoc == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Familiares: " + (background.Familiares == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Hospitalizaciones: " + (background.Hospitalizaciones == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Perinatales: " + (background.AntPerinatales == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (8 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Vacunación: " + (background.Vacunacion != null ? background.Vacunacion.Descripcion : ""), font, XBrushes.Black, new XRect(275, rectStartingX + (9 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Medicación: " + (background.Medicacion == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (10 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // creation date
            gfx.DrawString("Fecha Creación: " + background.FechaCreacion.ToString(), font, XBrushes.Black, new XRect(20, rectStartingX + (11 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // notes
            gfx.DrawString("Notas:", font, XBrushes.Black, new XRect(20, rectStartingX + (12 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString(background.Notas ?? "", font, XBrushes.Black, new XRect(20, rectStartingX + (13 * rectSize), 210 - 20, rectSize), XStringFormats.CenterLeft);
        }

        private static void DrawConsultationInformation(XGraphics gfx, Consulta consultation, int backgroundCount, int backgroundPosition)
        {
            double sectionSizeY = 110;
            double startingY = 110 + (sectionSizeY * backgroundPosition);
            double rectSize = 20;
            double rectStartingX = startingY + rectSize;

            DrawTitle(gfx, "Consulta Nº" + (backgroundCount + 1), 20, startingY, fontSize: 16);
            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);

            // first column
            gfx.DrawString("Fecha Atención: " + consultation.FechaAtencion.ToString(), font, XBrushes.Black, new XRect(20, rectStartingX + (0 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Edad Consulta: " + consultation.EdadConsulta, font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Diagnóstico Consulta: " + consultation.DiagnosticoConsulta, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Evaluación Nutricional: " + consultation.EvalNutric, font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Exámen Físico: " + consultation.ExamenFisico, font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Tensión Arterial: " + consultation.Ta, font, XBrushes.Black, new XRect(20, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Peso (Kg): " + consultation.Peso, font, XBrushes.Black, new XRect(20, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Talla (Mt): " + consultation.Talla, font, XBrushes.Black, new XRect(20, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Imc (Kg/M²): " + consultation.Imc, font, XBrushes.Black, new XRect(20, rectStartingX + (8 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Circ. Cintura: " + consultation.CircCintura, font, XBrushes.Black, new XRect(20, rectStartingX + (9 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Circ. Cadera: " + consultation.CircCadera, font, XBrushes.Black, new XRect(20, rectStartingX + (10 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Saturación (%): " + consultation.Saturacion, font, XBrushes.Black, new XRect(20, rectStartingX + (11 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Temperatura (ºC): " + consultation.Temperatura, font, XBrushes.Black, new XRect(20, rectStartingX + (12 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Glicemia (mg/dl): " + consultation.Glicemia, font, XBrushes.Black, new XRect(20, rectStartingX + (13 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Agudeza Visual Ojo Der: " + consultation.AgudezaDer, font, XBrushes.Black, new XRect(20, rectStartingX + (14 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Derivación Aguda: " + (consultation.DerivacionAguda == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(20, rectStartingX + (15 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Derivación: " + consultation.ObservacionDeriv, font, XBrushes.Black, new XRect(20, rectStartingX + (16 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

            // second column
            gfx.DrawString("Motivo Consulta: " + consultation.MotivoConsulta, font, XBrushes.Black, new XRect(275, rectStartingX + (0 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación: " + consultation.Observacion, font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Evaluación Social: " + consultation.EvalSoc, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Ecografía: " + (consultation.Ecografia == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Ecografía: " + consultation.ObservacionEco, font, XBrushes.Black, new XRect(275, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Ecg: " + (consultation.Ecg == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Ecg: " + consultation.ObservacionEcg, font, XBrushes.Black, new XRect(275, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Radiografía: " + (consultation.Radiografia == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (7 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Radiografía: " + consultation.ObservacionRadiografia, font, XBrushes.Black, new XRect(275, rectStartingX + (8 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Laboratorio: " + (consultation.Laboratorio == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (9 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Observación Laboratorio: " + consultation.ObservacionLab, font, XBrushes.Black, new XRect(275, rectStartingX + (10 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Estudios Complementarios: " + consultation.EstudiosComp, font, XBrushes.Black, new XRect(275, rectStartingX + (11 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Tratamiento: " + consultation.Tratamiento, font, XBrushes.Black, new XRect(275, rectStartingX + (12 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Derivación Programada: " + (consultation.DerivacionProg == 1 ? "Si" : "No"), font, XBrushes.Black, new XRect(275, rectStartingX + (13 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            gfx.DrawString("Agudeza Visual Ojo Izq: " + consultation.AgudezaIzq, font, XBrushes.Black, new XRect(275, rectStartingX + (14 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);


            startingY = rectStartingX + (18 * rectSize);
            rectStartingX = rectStartingX + (19 * rectSize);

            if (consultation.Paciente.Sexo.ToUpper() == "FEMENINO")
            {
                DrawTitle(gfx, "Ginecología", 20, startingY, fontSize: 14);

                // first column
                gfx.DrawString("Gestas: " + consultation.Gestas, font, XBrushes.Black, new XRect(20, rectStartingX + (0 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Para: " + consultation.Para, font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Cesáreas: " + consultation.Cesareas, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Abortos: " + consultation.Abortos, font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Inicio Rel. Sexuales (Irs): " + consultation.Irs, font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Menarca: " + consultation.Menarca, font, XBrushes.Black, new XRect(20, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Fecha última Menstruación: " + consultation.Fum, font, XBrushes.Black, new XRect(20, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);


                // second column
                gfx.DrawString("Ritmo Menstrual: " + consultation.RitmoMenst, font, XBrushes.Black, new XRect(275, rectStartingX + (0 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Menopausia: " + consultation.Menopausia, font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Toma Pap: " + consultation.TomaPap, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Resultado Pap: " + consultation.ResultadoPap, font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Colposcopía: " + consultation.Colposcopia, font, XBrushes.Black, new XRect(275, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Método Anticonceptivo (MAC): " + consultation.MacActual, font, XBrushes.Black, new XRect(275, rectStartingX + (5 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Fecha MAC: " + consultation.FechaMac, font, XBrushes.Black, new XRect(275, rectStartingX + (6 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);


                startingY = rectStartingX + (8 * rectSize); // + 6 elements on section
                rectStartingX = rectStartingX + (9 * rectSize); // +6 elements on section
            }

            if (consultation.EdadConsulta < 18)
            {
                DrawTitle(gfx, "Pediatría", 20, startingY, fontSize: 14);

                // first column
                gfx.DrawString("Percentil Peso: " + consultation.PercentilPeso, font, XBrushes.Black, new XRect(20, rectStartingX + (0 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Pz Peso: " + consultation.PzPeso, font, XBrushes.Black, new XRect(20, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Percentil Talla: " + consultation.PercentilTalla, font, XBrushes.Black, new XRect(20, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Pz Talla: " + consultation.PzTalla, font, XBrushes.Black, new XRect(20, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Perímetro Cefálico: " + consultation.Pc, font, XBrushes.Black, new XRect(20, rectStartingX + (4 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);

                // second column
                gfx.DrawString("Percentil Imc: " + consultation.PercentilImc, font, XBrushes.Black, new XRect(275, rectStartingX + (0 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Pz Imc: " + consultation.PzImc, font, XBrushes.Black, new XRect(275, rectStartingX + (1 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Percentil Pc: " + consultation.PercentilPc, font, XBrushes.Black, new XRect(275, rectStartingX + (2 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
                gfx.DrawString("Pz Pc: " + consultation.PzPc, font, XBrushes.Black, new XRect(275, rectStartingX + (3 * rectSize), 210 / 2, rectSize), XStringFormats.CenterLeft);
            
            }

        }
    }

    enum PageType
    {
        Information,
        Background,
        Consultations
    }
}

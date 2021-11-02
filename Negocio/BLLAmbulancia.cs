using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Negocio
{
    public class BLLAmbulancia 
    {
        public List<BEEAmbulancia> CargarXML()
        {
            var consulta = from ambulancia in XElement.Load("Ambulancias.xml").Elements("Ambulancia")
                           select new BEEAmbulancia
                           {
                               NumAmbulancia = Convert.ToInt32(ambulancia.Attribute("Numero").Value.ToString().Trim()),
                               Emergencia = ambulancia.Element("Emergencia").Value.ToString().Trim().ToLower() == "si",
                               EnServicio = ambulancia.Element("Servicio").Value.ToString().Trim().ToLower() == "si",
                               CantPasajeros = Convert.ToInt32(ambulancia.Element("Pasajeros").Value.ToString().Trim())
                           };
            List<BEEAmbulancia> LAmbulancias = consulta.ToList();

            return LAmbulancias;
        }

        public void BorrarXML(string num)
        {
            XDocument documento = XDocument.Load("Ambulancias.xml");

            var consulta = from ambulancia in documento.Descendants("Ambulancia")
                           where ambulancia.Attribute("Numero").Value == num
                           select ambulancia;
            consulta.Remove();
            documento.Save("Ambulancias.xml");
        }

        public void AgregarXML(BEEAmbulancia amb)
        {
            string emergencia = amb.Emergencia ? "si" : "no";
            string servicio = amb.EnServicio ? "si" : "no";

            XDocument doc = XDocument.Load("Ambulancias.xml");

            doc.Element("Ambulancias").Add(new XElement("Ambulancia",
                new XAttribute("Numero", amb.NumAmbulancia.ToString().Trim()),
                new XElement("Emergencia", emergencia),
                new XElement("Servicio", servicio),
                new XElement("Pasajeros", amb.CantPasajeros.ToString().Trim()))
                );

            doc.Save("Ambulancias.xml");
            CargarXML();
        }

        public List<BEEAmbulancia> BuscarXML(string tipo, string valor)
        {
            List<BEEAmbulancia> LAmbulancias = null;
            if (tipo == "Numero")
            {
                var consulta =
                              from ambulancia in XElement.Load("Ambulancias.xml").Elements("Ambulancia")
                              where (string)ambulancia.Attribute(tipo) == valor
                              select new BEEAmbulancia
                              {
                                  NumAmbulancia = Convert.ToInt32(ambulancia.Attribute("Numero").Value.ToString().Trim()),
                                  Emergencia = ambulancia.Element("Emergencia").Value.ToString().Trim().ToLower() == "si",
                                  EnServicio = ambulancia.Element("Servicio").Value.ToString().Trim().ToLower() == "si",
                                  CantPasajeros = Convert.ToInt32(ambulancia.Element("Pasajeros").Value.ToString().Trim())
                              };
                LAmbulancias = consulta.ToList();
            }
            else
            {
                var consulta =
                               from ambulancia in XElement.Load("Ambulancias.xml").Elements("Ambulancia")
                               where (string)ambulancia.Element(tipo) == valor
                               select new BEEAmbulancia
                               {
                                   NumAmbulancia = Convert.ToInt32(ambulancia.Attribute("Numero").Value.ToString().Trim()),
                                   Emergencia = ambulancia.Element("Emergencia").Value.ToString().Trim().ToLower() == "si",
                                   EnServicio = ambulancia.Element("Servicio").Value.ToString().Trim().ToLower() == "si",
                                   CantPasajeros = Convert.ToInt32(ambulancia.Element("Pasajeros").Value.ToString().Trim())
                               };
                LAmbulancias = consulta.ToList();
            }
            return LAmbulancias;
        }


    }
}
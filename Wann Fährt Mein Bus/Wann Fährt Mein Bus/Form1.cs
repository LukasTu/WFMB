﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net; //Für HTTP-Request und HTTP-Response benötigt
using System.IO; //Für Stream benötigt

namespace Wann_Fährt_Mein_Bus
{
    public partial class WFMB_Form : Form
    {
        public class Stop //Erstellen der Klasse "Stop", mit der Objekte angelegt werden in denen Stop-Informationen abgelegt werden
        {
            public string id;
            public string name;
            public string route;
            public string richtung;
            public string code;
            public string text;
            public List<long> depTimes = new List<long>();
        }

        HttpWebRequest request; //Einmalige Definition des HTTP-Requests beim Aufruf der Anwendung
        HttpWebResponse response; //Einmalige Definition der HTTP-Respnse beim Aufruf der Anwendung

        Stop stop = new Stop(); //Erstellen eines Objektes der Klasse Stop
        string str_routenID;

        public void getStopInfo(Stop stop, string routenID, string str_response) //Methode zum Auswerten der HTTP-Response
        {
            bool faultless = true;
            stop.code = str_response.Substring(str_response.IndexOf("<code>") + 6, 3); //Im Antwort-String das Elemet <code> suchen und dessen Wert in eine Variable speichern
            if (stop.code != "200") //Abfrage, ob der Wert von <code> NICHT 200 ist
            {
                stop.text = str_response.Substring(str_response.IndexOf("<text>") + 6, str_response.IndexOf("</text>") - (str_response.IndexOf("<text>") + 6)); //Auslesen des Textes, der den Code beschreibt
            }
            else //Wenn der Wert von <code> 200 ist, war die Abfrage erfolgreich und die Antwort kann ausgewertet werden
            {
                stop.name = str_response.Substring(str_response.IndexOf("<name>", str_response.IndexOf("<stop>")) + 6, str_response.IndexOf("</name>", str_response.IndexOf("<stop>")) - (str_response.IndexOf("<name>", str_response.IndexOf("<stop>")) + 6)).Replace("amp;", "&"); //Auslesen des Stopnamen
                stop.richtung = str_response.Substring(str_response.IndexOf("<direction>", str_response.IndexOf("<stop>")) + 11, str_response.IndexOf("</direction>", str_response.IndexOf("<stop>")) - (str_response.IndexOf("<direction>", str_response.IndexOf("<direction>")) + 11)).Replace("NE", "north-eastbound").Replace("NW", "north-westbound").Replace("SE", "south-eastbound").Replace("SW", "south-westbound").Replace("N", "northbound").Replace("S", "southbound").Replace("W", "westbound").Replace("E", "eastbound"); //Auslesen der Fahrtrichtung
                try
                {
                    stop.route = str_response.Substring(str_response.IndexOf("<description>", str_response.IndexOf("<id>" + routenID + "</id>")) + 13, str_response.IndexOf("</description>", str_response.IndexOf("<id>" + routenID + "</id>")) - (str_response.IndexOf("<description>", str_response.IndexOf("<id>" + routenID + "</id>")) + 13)).Replace("amp;", "&"); //Auslesen der Route, wenn sie unter <direction> angegeben ist
                }
                catch (ArgumentOutOfRangeException)
                {
                    try
                    {
                        stop.route = str_response.Substring(str_response.IndexOf("<longName>", str_response.IndexOf("<id>" + routenID + "</id>")) + 10, str_response.IndexOf("</longName>", str_response.IndexOf("<id>" + routenID + "</id>")) - (str_response.IndexOf("<longName>", str_response.IndexOf("<id>" + routenID + "</id>")) + 10)).Replace("amp;", "&"); //Auslesen der Route, wenn sie unter <longName> angegeben ist
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        txt_ausgabe.Text = "Error!" + Environment.NewLine + "Invalid rout ID.";
                        stop.route = "";
                        faultless = false;
                    }
                }

                if (faultless == true)
                {
                    int temp_LastDepPos = str_response.IndexOf("<routeId>" + routenID + "</routeId>");
                    long temp_DepTime;

                    for (int i = 0; i < 5; i++) //Schleife zum Einlesen der Abfahrtszeiten
                    {
                        try
                        {
                            temp_DepTime = Convert.ToInt64(str_response.Substring(str_response.IndexOf("<departureTime>", temp_LastDepPos) + 15, str_response.IndexOf("</departureTime>", temp_LastDepPos + 16) - (str_response.IndexOf("<departureTime>", temp_LastDepPos) + 15))); //Die Abfahrtszeiten befinden sich in <departureTime /> Tags und sind im Unix-Millisekunden-Vormat angegeben
                            if (temp_DepTime > (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds) //Prüfen, ob die Abfahrtszeit veraltet ist
                            {
                                stop.depTimes.Add(temp_DepTime); //Abfahrtszeiten werden in einer Liste gespeichert
                            }
                            else
                            {
                                i--;  //Wenn die Abfahrtszeit schon vergangen ist, wird der Zähler der Schleife um 1 zurückgesetzt, um trotzdem die gewünschte Anzahl an Abfahrtszeiten zu erhalten
                            }
                            temp_LastDepPos = str_response.IndexOf("</departureTime>", temp_LastDepPos + 16); //Bestimmung der Position der zuletzt eingelesenen Abfahrtszeit
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            break;
                        }
                    }
                }
            }

        }

        public DateTime UnixTimeConverter(long UnixTime) //Funktion zur Umrechnung der Unix-Zeit in "lesbare" Zeit
	    {
	        return (new DateTime(1970, 1, 1, 0, 0, 0)).AddMilliseconds(UnixTime);
	    }

        public Int16 MinutesToDeparture(long depTime) //Funktion zur Bestimmung der Zeit bis zur Abfahrt
        {
            return Convert.ToInt16((depTime - (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds) / 1000 / 60); //Die Differenz von aktueller Zeit zu Abfahrtszeit wird von Millisekunden in Minuten umgerechnet
        }

        public WFMB_Form()
        {
            InitializeComponent();
        }

        private void btn_getInfo_Click(object sender, EventArgs e) //Button-Click-Event 
        {
            //Leeren der Ausgabefelder
            lbl_stopname.Text = "";
            lbl_route.Text = "";
            lbl_fahrtrichtung.Text = "";
            txt_ausgabe.Clear();
            txt_ausgabe.Update();

            lbl_currentTime.Text = String.Format("{0:dd.MM.yyyy}", DateTime.UtcNow.AddHours(-7)) + " / " + String.Format("{0:HH:mm}", DateTime.UtcNow.AddHours(-7)); //Ausgabe der aktuellen Zeit

            stop.id = txt_stopID.Text; //Ablegen der durch den Benutzer eingegebenen Stop ID
            str_routenID = txt_routenID.Text; 

            request = (HttpWebRequest)WebRequest.Create("http://api.onebusaway.org/api/where/schedule-for-stop/" + stop.id + ".xml?key=TEST"); //Erstellen des HTTP-Requests
            response = (HttpWebResponse)request.GetResponse(); //Ablage für die Antwort auf den HTTP-Request
            
            Stream responeStream = response.GetResponseStream(); //Einen Stream der Antwort erstellen
            StreamReader responseTranslator = new StreamReader(responeStream, Encoding.UTF8); //Die Antwort mit einem Streamreader in UTF-8-Codierung umwandeln
            string str_response = responseTranslator.ReadToEnd(); //Die UTF-8-codierte Antwort in eine Variable vom Typ String legen
            responseTranslator.Close(); //Streamreader schließen
            responeStream.Close(); //Stream schließen

            getStopInfo(stop, str_routenID, str_response);

            if (stop.code != "200")
            {
                txt_ausgabe.Text = "Error!" + Environment.NewLine + "Code: " + stop.code + Environment.NewLine; //Wenn der Wert von <code> nicht 200 ist, soll er ausgegeben werden
                txt_ausgabe.Text += "\"" + stop.text + "\"";//Das Element <text> enthält eine kleine Fehlermeldung zu dem code
            }
            else
            {
                lbl_stopname.Text = stop.name; //Ausgabe des Stopnamen
                lbl_fahrtrichtung.Text = stop.richtung; //Ausgabe der Fahrtrichtung
                lbl_route.Text = stop.route; //Ausgabe der Route

                foreach (long depTime in stop.depTimes) 
                {
                    txt_ausgabe.Text += String.Format("{0:HH:mm}", UnixTimeConverter(depTime).AddHours(-7)); //Jede Abfahrtszeit in der Liste der Abfahrtszeiten wird augegeben
                    if (MinutesToDeparture(depTime) < 60)
                    {
                        txt_ausgabe.Text += "    (in " + MinutesToDeparture(depTime) + " minutes)" + Environment.NewLine; //Und gegebenenfalls auch die Zeit bis zur Abfahrt in Minuten (wenn < 60)
                    }
                    else
                    {
                        txt_ausgabe.Text += Environment.NewLine;
                    }
                }
                stop.depTimes.Clear(); //Liste mit den Abfahrtszeiten leeren
            }
        }

        private void txt_stopID_TextChanged(object sender, EventArgs e) //Text-Changed-Event für das Textfeld, in dem der Benutzer die ID des Stops angibt
        {
            if (txt_stopID.Text != "")
            {
                btn_getInfo.Enabled = true;
            }
            else btn_getInfo.Enabled = false; //Der Botton ist nur Verfügbar, wenn der Benutzer eine Stop ID eingegeben hat
        }

        private void WFMB_Form_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }
    }
}

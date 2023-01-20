using System;
using System.ComponentModel;
using System.Xml.Linq;

namespace IncrementCBsep2022
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Source = new BindingSource();
			LookingForSource = new BindingList<Person>();
			
		}

		private static BindingSource Source;
		private XElement Master;
		private List<XElement> MasterList = new List<XElement>();
		public BindingList<Person> LookingForSource;

		#region XML Things
		// : Lees en Schrijf Xml kunnen misschien in aparte class

		private void LeesXML()
		{
			// haalt de padnaam op waar het xml bestand staat
			// twee opties: file buiten en file binnen assembly
			// Onderstaande code is voor xml file binnen assembly
			// essentieel: in solution explorer de xml file aanklikken en in rechtermuismenu
			// properties aanklikken en property 'Build Action' instellen op Embedded Resource
			// en property 'Copy to Output Directory' instellen op 'Copy Always'
			Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
			String path = Directory.GetCurrentDirectory();
			Master = XElement.Load(path + "\\Master.xml");

			// pad buiten assembly (als voorbeeld):
			//Master = XElement.Load(@"C:\Users\Admin\Desktop\Master.xml")
			// essentieel: in solution explorer de xml file aanklikken en in rechtermuismenu
			// properties aanklikken en property 'Build Action' instellen op Content
			// en property 'Copy to Output Directory' instellen op 'Copy if newer'
			//MasterList = Master.Elements().ToList();

			
			
			foreach (var item in Master.Elements())
			{
				Person P = new Person();
				P.Id = item.Element("Id").Value;
				P.Team = item.Element("Team").Value;
				P.Startdatum = item.Element("Startdatum").Value;
				P.Einddatum = item.Element("Einddatum").Value;
				P.Voornaam = item.Element("Voornaam").Value;
				P.Tussenvoegsel = item.Element("Tussenvoegsel").Value;
				P.Achternaam = item.Element("Achternaam").Value;
				P.Telefoonnr = item.Element("Telefoonnr").Value;
				P.Email = item.Element("Email").Value;
				P.Geboortedatum = item.Element("Geboortedatum").Value;
				P.BSN = item.Element("BSN").Value;
				P.Straat = item.Element("Straat").Value;
				P.Huisnummer = item.Element("Huisnummer").Value;
				P.Pc = item.Element("Pc").Value;
				P.Woonplaats = item.Element("Woonplaats").Value;
				P.Provincie = item.Element("Provincie").Value;
				P.Instantie = item.Element("Instantie").Value;
				P.ContactpersoonInstantie = item.Element("ContactpersoonInstantie").Value;
				P.OfferteDatum = item.Element("OfferteDatum").Value;
				P.OrderNummer = item.Element("OrderNummer").Value;
				P.BriefInstantieOntvangstDatum = item.Element("BriefInstantieOntvangstDatum").Value;
				P.BevestigingDatumOpleiding = item.Element("BevestigingDatumOpleiding").Value;
				P.FactuurDatum = item.Element("FactuurDatum").Value;
				P.VerzendDatumEindrapportage = item.Element("VerzendDatumEindrapportage").Value;
				P.CertificaatPSMI1 = item.Element("CertificaatPSMI1").Value;
				P.Baan = item.Element("Baan").Value;
				P.AanwezigOpCvApp = item.Element("AanwezigOpCvApp").Value;
				P.Opmerkingen = item.Element("Opmerkingen").Value;
				
				LookingForSource.Add(P);
			}
			
			Source = new BindingSource(LookingForSource, "");
			dataGridView1.DataSource = Source;
			dataGridView1.AutoGenerateColumns = true;
		}

		private void SchrijfML()
		{
			IEnumerable<XElement> TrekUmDrin()
			{
				foreach (var person in LookingForSource)
				{
					XElement Person = new XElement("Person");

					//XElement Id = new XElement("Id", person.Id);
					Person.Add(new XElement("Id", person.Id));
					Person.Add(new XElement("Team", person.Team));
					Person.Add(new XElement("Startdatum", person.Startdatum));
					Person.Add(new XElement("Einddatum", person.Einddatum));
					Person.Add(new XElement("Voornaam", person.Voornaam));
					Person.Add(new XElement("Tussenvoegsel", person.Tussenvoegsel));
					Person.Add(new XElement("Achternaam", person.Achternaam));
					Person.Add(new XElement("Telefoonnr", person.Telefoonnr));
					Person.Add(new XElement("Email", person.Email));
					Person.Add(new XElement("Geboortedatum", person.Geboortedatum));
					Person.Add(new XElement("BSN", person.BSN));
					Person.Add(new XElement("Straat", person.Straat));
					Person.Add(new XElement("Huisnummer", person.Huisnummer));
					Person.Add(new XElement("Pc", person.Pc));
					Person.Add(new XElement("Woonplaats", person.Woonplaats));
					Person.Add(new XElement("Provincie", person.Provincie));
					Person.Add(new XElement("Instantie", person.Instantie));
					Person.Add(new XElement("ContactpersoonInstantie", person.ContactpersoonInstantie));
					Person.Add(new XElement("OfferteDatum", person.OfferteDatum));
					Person.Add(new XElement("OrderNummer", person.OrderNummer));
					Person.Add(new XElement("BriefInstantieOntvangstDatum", person.BriefInstantieOntvangstDatum));
					Person.Add(new XElement("BevestigingDatumOpleiding", person.BevestigingDatumOpleiding));
					Person.Add(new XElement("FactuurDatum", person.FactuurDatum));
					Person.Add(new XElement("VerzendDatumEindrapportage", person.VerzendDatumEindrapportage));
					Person.Add(new XElement("CertificaatPSMI1", person.CertificaatPSMI1));
					Person.Add(new XElement("Baan", person.Baan));
					Person.Add(new XElement("AanwezigOpCvApp", person.AanwezigOpCvApp));
					Person.Add(new XElement("Opmerkingen", person.Opmerkingen));

					yield return Person;
				}
			}
			XElement doc = new XElement("Master", TrekUmDrin());

			Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
			String path = Directory.GetCurrentDirectory();
			doc.Save(path + "\\Master.xml");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LeesXML();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SchrijfML();
		}
		#endregion


		// Onderstaande class is 'autogenerated' door vs. (de xml file met copy in de code te plakken en dan
		// plakkenspeciaal in menu vs te kiezen en daarna optie xmltoclass te kiezen. xml wordt dan
		// in een class geschreven die weer gebruikt kan worden om de datagridview (het excell dingetje 
		// op het ui formulier te s
		[System.SerializableAttribute()]
		[System.ComponentModel.DesignerCategoryAttribute("code")]
		[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
		[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
		public partial class Person
		{
			private object idField;

			private object teamField;

			private object startdatumField;

			private object einddatumField;

			private object voornaamField;

			private object tussenvoegselField;

			private object achternaamField;

			private object telefoonnrField;

			private object emailField;

			private object geboortedatumField;

			private object bSNField;

			private object straatField;

			private object huisnummerField;

			private object pcField;

			private object woonplaatsField;

			private object provincieField;

			private object instantieField;

			private object contactpersoonInstantieField;

			private object offerteDatumField;

			private object orderNummerField;

			private object briefInstantieOntvangstDatumField;

			private object bevestigingDatumOpleidingField;

			private object factuurDatumField;

			private object verzendDatumEindrapportageField;

			private object certificaatPSMI1Field;

			private object baanField;

			private object aanwezigOpCvAppField;

			private object opmerkingenField;

			/// <remarks/>
			public object Id
			{
				get
				{
					return this.idField;
				}
				set
				{
					this.idField = value;
				}
			}

			/// <remarks/>
			public object Team
			{
				get
				{
					return this.teamField;
				}
				set
				{
					this.teamField = value;
				}
			}

			/// <remarks/>
			public object Startdatum
			{
				get
				{
					return this.startdatumField;
				}
				set
				{
					this.startdatumField = value;
				}
			}

			/// <remarks/>
			public object Einddatum
			{
				get
				{
					return this.einddatumField;
				}
				set
				{
					this.einddatumField = value;
				}
			}

			/// <remarks/>
			public object Voornaam
			{
				get
				{
					return this.voornaamField;
				}
				set
				{
					this.voornaamField = value;
				}
			}

			/// <remarks/>
			public object Tussenvoegsel
			{
				get
				{
					return this.tussenvoegselField;
				}
				set
				{
					this.tussenvoegselField = value;
				}
			}

			/// <remarks/>
			public object Achternaam
			{
				get
				{
					return this.achternaamField;
				}
				set
				{
					this.achternaamField = value;
				}
			}

			/// <remarks/>
			public object Telefoonnr
			{
				get
				{
					return this.telefoonnrField;
				}
				set
				{
					this.telefoonnrField = value;
				}
			}

			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("E-mail")]
			public object Email
			{
				get
				{
					return this.emailField;
				}
				set
				{
					this.emailField = value;
				}
			}

			/// <remarks/>
			public object Geboortedatum
			{
				get
				{
					return this.geboortedatumField;
				}
				set
				{
					this.geboortedatumField = value;
				}
			}

			/// <remarks/>
			public object BSN
			{
				get
				{
					return this.bSNField;
				}
				set
				{
					this.bSNField = value;
				}
			}

			/// <remarks/>
			public object Straat
			{
				get
				{
					return this.straatField;
				}
				set
				{
					this.straatField = value;
				}
			}

			/// <remarks/>
			public object Huisnummer
			{
				get
				{
					return this.huisnummerField;
				}
				set
				{
					this.huisnummerField = value;
				}
			}

			/// <remarks/>
			public object Pc
			{
				get
				{
					return this.pcField;
				}
				set
				{
					this.pcField = value;
				}
			}

			/// <remarks/>
			public object Woonplaats
			{
				get
				{
					return this.woonplaatsField;
				}
				set
				{
					this.woonplaatsField = value;
				}
			}

			/// <remarks/>
			public object Provincie
			{
				get
				{
					return this.provincieField;
				}
				set
				{
					this.provincieField = value;
				}
			}

			/// <remarks/>
			public object Instantie
			{
				get
				{
					return this.instantieField;
				}
				set
				{
					this.instantieField = value;
				}
			}

			/// <remarks/>
			public object ContactpersoonInstantie
			{
				get
				{
					return this.contactpersoonInstantieField;
				}
				set
				{
					this.contactpersoonInstantieField = value;
				}
			}

			/// <remarks/>
			public object OfferteDatum
			{
				get
				{
					return this.offerteDatumField;
				}
				set
				{
					this.offerteDatumField = value;
				}
			}

			/// <remarks/>
			public object OrderNummer
			{
				get
				{
					return this.orderNummerField;
				}
				set
				{
					this.orderNummerField = value;
				}
			}

			/// <remarks/>
			public object BriefInstantieOntvangstDatum
			{
				get
				{
					return this.briefInstantieOntvangstDatumField;
				}
				set
				{
					this.briefInstantieOntvangstDatumField = value;
				}
			}

			/// <remarks/>
			public object BevestigingDatumOpleiding
			{
				get
				{
					return this.bevestigingDatumOpleidingField;
				}
				set
				{
					this.bevestigingDatumOpleidingField = value;
				}
			}

			/// <remarks/>
			public object FactuurDatum
			{
				get
				{
					return this.factuurDatumField;
				}
				set
				{
					this.factuurDatumField = value;
				}
			}

			/// <remarks/>
			public object VerzendDatumEindrapportage
			{
				get
				{
					return this.verzendDatumEindrapportageField;
				}
				set
				{
					this.verzendDatumEindrapportageField = value;
				}
			}

			/// <remarks/>
			public object CertificaatPSMI1
			{
				get
				{
					return this.certificaatPSMI1Field;
				}
				set
				{
					this.certificaatPSMI1Field = value;
				}
			}

			/// <remarks/>
			public object Baan
			{
				get
				{
					return this.baanField;
				}
				set
				{
					this.baanField = value;
				}
			}

			/// <remarks/>
			public object AanwezigOpCvApp
			{
				get
				{
					return this.aanwezigOpCvAppField;
				}
				set
				{
					this.aanwezigOpCvAppField = value;
				}
			}

			/// <remarks/>
			public object Opmerkingen
			{
				get
				{
					return this.opmerkingenField;
				}
				set
				{
					this.opmerkingenField = value;
				}
			}
		}




	}
}
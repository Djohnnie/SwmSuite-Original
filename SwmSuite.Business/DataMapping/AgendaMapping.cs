using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;
using System.Drawing;

namespace SwmSuite.Business.DataMapping {
	
	public class AgendaMapping : Mapping {

		public static Agenda FromDataObject( AgendaData agendaData ) {
			Mapping mapping = new AgendaMapping();
			return mapping.FromDataObject( agendaData ) as Agenda;
		}

		public static AgendaData FromBusinessObject( Agenda agenda ) {
			Mapping mapping = new AgendaMapping();
			return mapping.FromBusinessObject( agenda ) as AgendaData;
		}

		public static AgendaCollection FromDataObjectCollection( AgendaDataCollection agendaDataCollection ) {
			Mapping mapping = new AgendaMapping();
			AgendaCollection agendaCollectionToReturn = new AgendaCollection();
			foreach( AgendaData agendaData in agendaDataCollection ) {
				agendaCollectionToReturn.Add( FromDataObject( agendaData ) );
			}
			return agendaCollectionToReturn;
		}

		public static AgendaDataCollection FromBusinessObjectCollection( AgendaCollection agendaCollection ) {
			Mapping mapping = new AgendaMapping();
			AgendaDataCollection agendaDataCollectionToReturn = new AgendaDataCollection();
			foreach( Agenda agenda in agendaCollection ) {
				agendaDataCollectionToReturn.Add( FromBusinessObject( agenda ) );
			}
			return agendaDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			AgendaData agendaData = dataObject as AgendaData;
			Agenda agendaToReturn = new Agenda();
			agendaToReturn.SysId = agendaData.SysId;
			agendaToReturn.RowVersion = agendaData.RowVersion;
			agendaToReturn.Title = agendaData.Title;
			agendaToReturn.Description = agendaData.Description;
			agendaToReturn.Visibility = agendaData.Visibility;
			agendaToReturn.Color1 = Color.FromArgb( agendaData.Color1 );
			agendaToReturn.Color2 = Color.FromArgb( agendaData.Color2 );
			agendaToReturn.Color3 = Color.FromArgb( agendaData.Color3 );
			agendaToReturn.OwnerEmployee = new EmployeeBll().GetEmployeeDetail( agendaData.OwnerEmployeeSysId );
			return agendaToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			Agenda agenda = businessObject as Agenda;
			AgendaData agendaDataToReturn = new AgendaData();
			agendaDataToReturn.SysId = agenda.SysId;
			agendaDataToReturn.RowVersion = agenda.RowVersion;
			agendaDataToReturn.Title = agenda.Title;
			agendaDataToReturn.Description = agenda.Description;
			agendaDataToReturn.Visibility = agenda.Visibility;
			agendaDataToReturn.Color1 = agenda.Color1.ToArgb();
			agendaDataToReturn.Color2 = agenda.Color2.ToArgb();
			agendaDataToReturn.Color3 = agenda.Color3.ToArgb();
			agendaDataToReturn.OwnerEmployeeSysId = agenda.OwnerEmployee.SysId;
			return agendaDataToReturn;
		}

		#endregion

	}

}

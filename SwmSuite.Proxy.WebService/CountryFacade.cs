using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public sealed class CountryFacade :
		ServiceFacade<CountryService.CountryService , CountryService.SwmSuiteSoapHeader> ,
		ICountryFacade {

		/// <summary>
		/// Get all countries from the database.
		/// </summary>
		/// <returns></returns>
		CountryCollection ICountryFacade.GetCountries() {
			try {
				CountryCollection countries = new CountryCollection();
				foreach( CountryService.Country country in GetService().GetCountries() ) {
					countries.Add( (Country)XmlSerialization.ConvertObject( country , typeof( CountryService.Country ) , typeof( Country ) ) );
				}
				return countries;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get a specif country from the database.
		/// </summary>
		/// <returns></returns>
		Country ICountryFacade.GetCountry( int sysId ) {
			try {
				CountryService.Country country = GetService().GetCountry( sysId );
				return (Country)XmlSerialization.ConvertObject( country , typeof( CountryService.Country ) , typeof( Country ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Add a new country to the database.
		/// </summary>
		/// <param name="country">The country to add.</param>
		/// <returns>The country created.</returns>
		Country ICountryFacade.CreateCountry( Country country ) {
			try {
				CountryService.Country countryParameter =
				(CountryService.Country)XmlSerialization.ConvertObject( country , typeof( Country ) , typeof( CountryService.Country ) );
				CountryService.Country countryResult =
					GetService().CreateCountry( countryParameter );
				return (Country)XmlSerialization.ConvertObject( countryResult , typeof( CountryService.Country ) , typeof( Country ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing country in the database.
		/// </summary>
		/// <param name="country">The country to update.</param>
		/// <returns>The country updated.</returns>
		Country ICountryFacade.UpdateCountry( Country country ) {
			try {
				CountryService.Country countryParameter =
				(CountryService.Country)XmlSerialization.ConvertObject( country , typeof( Country ) , typeof( CountryService.Country ) );
				CountryService.Country countryResult =
					GetService().UpdateCountry( countryParameter );
				return (Country)XmlSerialization.ConvertObject( countryResult , typeof( CountryService.Country ) , typeof( Country ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more countries from the database.
		/// </summary>
		/// <param name="countries">The countries to remove.</param>
		void ICountryFacade.RemoveCountries( CountryCollection countries ) {
			try {
				CountryService.Country[] countriesParameter = new CountryService.Country[countries.Count];
				foreach( Country country in countries ) {
					countriesParameter[countries.IndexOf( country )] =
						(CountryService.Country)XmlSerialization.ConvertObject( country , typeof( Country ) , typeof( CountryService.Country ) );
				}
				GetService().RemoveCountries( countriesParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}
}

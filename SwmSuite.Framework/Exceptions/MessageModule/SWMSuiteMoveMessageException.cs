using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Framework.Exceptions.MessageModule {

	//public class SwmSuiteMoveMessageException : SwmSuiteException {

	//    #region -_ Private Members _-

	//    #endregion

	//    #region -_ Public Properties _-

	//    public new MessageData Message { get; set; }
	//    public MessageFolderData SourceMessageFolder { get; set; }
	//    public MessageFolderData DestinationMessageFolder { get; set; }
	//    public MoveMessageError Error { get; set; }

	//    #endregion

	//    #region -_ Construction _-

	//    /// <summary>
	//    /// Default constructor.
	//    /// </summary>
	//    public SwmSuiteMoveMessageException( MessageData message , MessageFolderData source , MessageFolderData destination , MoveMessageError error )
	//        : base() {
	//        this.Message = message;
	//        this.SourceMessageFolder = source;
	//        this.DestinationMessageFolder = destination;
	//        this.Error = error;
	//    }

	//    #endregion

	//    #region -_ Public Methods _-

	//    public override string ToString() {
	//        String stringToReturn = "Onbekende fout.";
	//        switch( this.Error ) {
	//            case MoveMessageError.DifferentOwnerEmployee: {
	//                stringToReturn = "De bronmap en doelmap behoren niet tot dezelfde gebruiker.";
	//                break;
	//            }
	//            case MoveMessageError.SourceAndDestinationAreSame: {
	//                stringToReturn = "De bronmap en doelmap zijn dezelfde.";
	//                break;
	//            }
	//        }
	//        return stringToReturn;
	//    }

	//    #endregion

	//}

}

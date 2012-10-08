using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;

namespace CustomLib
{
    public class ErrorHandlingOperationBehavior: Attribute, IOperationBehavior
    {
        #region IOperationBehavior Members

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            // Replace the default invoker with our custom ErrorHandlingInvoker
            ErrorHandlingInvoker errInvoker = new ErrorHandlingInvoker(dispatchOperation.Invoker);
            dispatchOperation.Invoker = errInvoker;
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {}

        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {} 

        public void Validate(OperationDescription operationDescription)
        {}

        #endregion
    }
}

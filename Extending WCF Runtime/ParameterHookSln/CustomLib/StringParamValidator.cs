using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace CustomLib
{
    public class StringParamValidator : IParameterInspector
    {
        #region IParameterInspector Members

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            // Do nothing
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            // Validate string parameters
            for(int i=0;i<inputs.Length;++i)
                if (inputs[i] is string)
                {
                    inputs[i] = "SafeWrapper[" + inputs[i].ToString() + "]";
                }

            return null;
        }

        #endregion
    }


    public class StringParamValidatorBehaviorAttribute : Attribute, IOperationBehavior
    {
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            StringParamValidator spv = new StringParamValidator();
            dispatchOperation.ParameterInspectors.Add(spv);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        { }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        { }

        public void Validate(OperationDescription operationDescription)
        { }
    }
}

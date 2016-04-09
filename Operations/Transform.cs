using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGCore.Operations
{
    public class Transform
    {
        public Dictionary<string, IOperation> Operations { get; set; }

        #region "Constructors"

        public Transform()
        {
            //Create 
            Operations = new Dictionary<string, IOperation>();
        }

        #endregion

        #region "Adding"

        public void AddTransform(IOperation operation)
        {
            //Ensure a valid operation has been supplied
            if (operation != null)
            {
                //Ensure there is valid storage
                if(Operations == null)
                {
                    Operations = new Dictionary<string, IOperation>();
                }

                //Remove any previous operation of the same type
                if (Operations.ContainsKey(operation.Name))
                {
                    Operations.Remove(operation.Name);
                }

                //Add the new Operation
                Operations.Add(operation.Name, operation);
            }
        }
        #endregion

        #region "Rendering"

        public bool HasOperations()
        {
            bool hasOperations = false;

            if(Operations != null)
            {
                if(Operations.Count > 0)
                {
                    hasOperations = true;
                }
            }

            return hasOperations;
        }

        public string AttributeString()
        {
            StringBuilder attribute = new StringBuilder();

            foreach (IOperation operation in Operations.Values)
            {
                attribute.Append(operation.AttributeString());
                attribute.Append(" ");
            }

            return attribute.ToString().Trim();
        }

        #endregion

    }
}

using DevExpress.Xpo;
using Xpand.Demo.Para.Model.Properties;

namespace Xpand.Demo.Para.Model.BusinessObjects
{
    [NonPersistent]
    public abstract class BaseObject : XPObject
    {
        protected BaseObject(Session session)
            : base(session)
        {
        }

        [NotifyPropertyChangedInvocator]
        protected new virtual bool SetPropertyValue<T>(string propertyName, ref T propertyValueHolder, T newValue)
        {
            return base.SetPropertyValue(propertyName, ref propertyValueHolder, newValue);
        }
    }
}
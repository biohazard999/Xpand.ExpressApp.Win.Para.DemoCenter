using DevExpress.Xpo;

namespace Xpand.Demo.Para.Model.BusinessObjects
{
    [NonPersistent]
    public class XPViewBusinessObjectProxy : BaseObject
    {
        private string _Name;
        private string _Property;

        public XPViewBusinessObjectProxy(Session session) : base(session)
        {
        }

        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Property
        {
            get { return _Property; }
            set { SetPropertyValue("Property", ref _Property, value); }
        }
    }
}

using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Xpand.Demo.Para.Model.Helpers;

namespace Xpand.Demo.Para.Model.BusinessObjects
{
    [DefaultClassOptions]
    public class XPViewCalculationProxy : BaseObject
    {
        public static readonly Fields<XPViewCalculationProxy> Field = new Fields<XPViewCalculationProxy>();

        private string _Name;
        private int _SumOfIntProperty;
        private SumMode _SumMode;
        private long _MillisecondsForCalculation;

        public XPViewCalculationProxy(Session session)
            : base(session)
        {
        }

        [ModelDefault("AllowEdit", "false")]
        public SumMode SumMode
        {
            get { return _SumMode; }
            set { SetPropertyValue("SumMode", ref _SumMode, value); }
        }

        [ModelDefault("AllowEdit", "false")]
        [NonPersistent]
        public int SumOfIntProperty
        {
            get { return _SumOfIntProperty; }
            set { SetPropertyValue("SumOfIntProperty", ref _SumOfIntProperty, value); }
        }

        [ModelDefault("AllowEdit", "false")]
        [NonPersistent]
        public long MillisecondsForCalculation
        {
            get { return _MillisecondsForCalculation; }
            set { SetPropertyValue("MillisecondsForCalculation", ref _MillisecondsForCalculation, value); }
        }
    }
}
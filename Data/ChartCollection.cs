namespace Data
{
    using System;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    //[Serializable, DoNotObfuscate]
    [DoNotObfuscate]
    public class ChartCollection
    {
        [DoNotObfuscate]
        public Collection<ChartTemplate> ChartTemplate_0 = new Collection<ChartTemplate>();

        public event templateChangedDelegate templateChangedDelegate_0;

        [DoNotObfuscate]
        public ChartCollection()
        {
            if (this.ChartTemplate_0.Count == 0)
            {
                this.addTemplate();
                this.getSelectedTemplate().setDefault();
            }
        }

        [DoNotObfuscate]
        public void addTemplate()
        {
            ChartTemplate ChartTemplate_1 = new ChartTemplate();
            ChartTemplate_1.setDefault();
            this.ChartTemplate_0.Add(ChartTemplate_1);
            this.throwEvent();
        }

        [DoNotObfuscate]
        public void addThisTemplate(ChartTemplate ChartTemplate_1)
        {
            this.ChartTemplate_0.Add(ChartTemplate_1);
            this.throwEvent();
        }

        [DoNotObfuscate]
        public ChartTemplate getSelectedTemplate()
        {
            return this.ChartTemplate_0[0];
        }

        [DoNotObfuscate]
        public string[] GetTemplateNames()
        {
            string[] strArray = new string[this.ChartTemplate_0.Count];
            for (int i = 0; i < this.ChartTemplate_0.Count; i++)
            {
                strArray[i] = this.ChartTemplate_0[i].templateName;
            }
            return strArray;
        }

        [DoNotObfuscate]
        public void removeTemplateAt(int index)
        {
            this.ChartTemplate_0.RemoveAt(index);
            this.throwEvent();
        }

        [DoNotObfuscate]
        public void throwEvent()
        {
            if (this.templateChangedDelegate_0 != null)
            {
                this.templateChangedDelegate_0();
            }
        }

        public delegate void templateChangedDelegate();
    }
}


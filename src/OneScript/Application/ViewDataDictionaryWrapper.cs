﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace OneScript.WebHost.Application
{
    [ContextClass("КоллекцияДанныхПредставления")]
    public class ViewDataDictionaryWrapper : ContextIValueImpl, IObjectWrapper
    {
        private readonly ViewDataDictionary _source;

        public ViewDataDictionaryWrapper(ViewDataDictionary source)
        {
            if(_source == null)
                _source = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());

            _source = source;
        }

        public IValue this[string index]
        {
            get { return (IValue)_source[index]; }
            set { _source[index] = value; }
        }

        public override bool IsIndexed => true;

        public override IValue GetIndexedValue(IValue index)
        {
            return (IValue)_source[index.AsString()];
        }

        public override void SetIndexedValue(IValue index, IValue val)
        {
            _source[index.AsString()] = val.GetRawValue();
        }

        [ContextProperty("Модель")]
        public object Model
        {
            get => _source.Model;
            set => _source.Model = value as IValue;
        }

        public object UnderlyingObject => _source;
    }
}
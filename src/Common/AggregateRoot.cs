using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _changes = new List<DomainEvent>();

        public IEnumerable<DomainEvent> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (DomainEvent domainEvent in history) {
                InvokeApplyMethod(domainEvent);
            }
        }

        protected void ApplyChange(DomainEvent domainEvent)
        {
            _changes.Add(domainEvent);
            InvokeApplyMethod(domainEvent);
        }

        private void InvokeApplyMethod(DomainEvent domainEvent)
        {
            MethodInfo applyMethod = GetType().GetMethod("Apply", new Type[] { domainEvent.GetType() });
            applyMethod?.Invoke(this, new object[] { domainEvent });
        }
    }
}

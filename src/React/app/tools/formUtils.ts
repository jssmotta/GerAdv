'use client';
import type React from 'react';

// Generic handler that normalizes many event/value shapes used across Kendo/HTML components.
// Call as: genericHandleChange(e, setData)
export function genericHandleChange(
  e: any,
  setData: React.Dispatch<React.SetStateAction<any>>
) {
  if (!e) return;

  let name: string | undefined;
  let value: any;
  let type: any;
  let checked: any;

  if (e.target) {
    // Typical DOM or synthetic event
    try {
      name =
        e.target.name ??
        (typeof e.target.getAttribute === 'function'
          ? e.target.getAttribute('name')
          : undefined);
    } catch (err) {
      name = undefined;
    }
    type = e.target.type;
    if (type === 'checkbox') {
      checked = e.target.checked;
      value = checked;
    } else {
      // e.target.value may be a Kendo wrapper ({ value }) or primitive
      value = e.target.value?.value ?? e.target.value ?? e.value ?? undefined;
    }
  } else {
    // No target: could be Kendo InputChangeEvent or a direct value
    name = e.name ?? e.field ?? undefined;
    if (e.value !== undefined) {
      value = e.value;
    } else if (e.targetValue !== undefined) {
      value = e.targetValue;
    } else if (typeof e === 'object' && 'value' in e) {
      value = (e as any).value;
    } else {
      // fallback: treat the whole object as value (for direct primitive calls)
      value = e;
    }
    type = e.type;
    if (type === 'checkbox' && e.checked !== undefined) {
      checked = e.checked;
      value = checked;
    }
  }

  // Try some extra fallbacks for name (some components may pass name at top-level)
  if (!name) name = e?.target?.props?.name ?? e?.props?.name ?? e?.name;

  if (!name) {
    // Nothing to update (no field name provided)
    return;
  }

  const finalValue = type === 'checkbox' ? checked : value;

  setData((prev: any) => ({
    ...prev,
    [name]: finalValue,
  }));
}

export default genericHandleChange;

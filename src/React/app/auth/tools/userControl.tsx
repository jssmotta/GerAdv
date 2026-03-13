'use client';
export function MustChangePasswordChecked(setValue?: boolean): boolean {
  if (typeof window === 'undefined') {
    return setValue ?? false;
  }
  const key = btoa('MustChangePasswordChecked');

  if (setValue !== undefined) {
    localStorage.setItem(key, setValue ? 'true' : 'false');
    return setValue;
  }

  const value = localStorage.getItem(key);
  
  if (value === 'true') {          
    return true;
  }  
  return false;
}

export function ClearMustChangePasswordChecked(): void {
  if (typeof window === 'undefined') {
    return;
  }
  const key = btoa('MustChangePasswordChecked');
  localStorage.removeItem(key);
}

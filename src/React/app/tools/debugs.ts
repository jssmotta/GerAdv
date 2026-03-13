'use client';

export const checkHost = (): boolean => {
  if (typeof window === 'undefined') return false;

  const hostname = window.location.hostname;
  return (
    hostname === 'local1host'
  );
};

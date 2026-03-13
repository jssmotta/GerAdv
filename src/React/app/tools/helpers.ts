'use client';
export function getParamFromUrl(param: string): number {
  const urlParams = new URLSearchParams(window.location.search);
  const paramValue = urlParams.get(param);
  if (paramValue !== null) {
    const intValue = parseInt(paramValue, 10);
    if (!isNaN(intValue)) {
      return intValue;
    }
  }
  return 0;
}

export const isOSMobile = () => {
  if (typeof window === 'undefined') return false;

  const userAgent = window.navigator.userAgent;

  // iOS detection
  const isIOS = /iPad|iPhone|iPod/.test(userAgent);

  // Android detection
  const isAndroid = /android/i.test(userAgent);

  return isIOS || isAndroid;
};

export function iniciaBarraAgendaSemanaData(isMobile: boolean): string {
  if (isMobile || isOSMobile()) {
    return new Date().toISOString();
  } else {
    return getFirstMondayOfCurrentWeek().toISOString();
  }
  return new Date().toISOString();
}

export const getFirstMondayOfCurrentWeek = (): Date => {
  const today = new Date();
  const dayOfWeek = today.getDay();
  const firstMonday = new Date(today);

  if (dayOfWeek === 0) {
    firstMonday.setDate(today.getDate() + 1);
  } else if (dayOfWeek !== 1) {
    const diff = dayOfWeek - 1;
    firstMonday.setDate(today.getDate() - diff);
  }

  return firstMonday;
};

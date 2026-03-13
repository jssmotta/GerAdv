'use client';

import { useState, useEffect } from "react";

export function isPWA() {
  // Verifica se está rodando como PWA instalado
  return window.matchMedia('(display-mode: standalone)').matches ||
         window.matchMedia('(display-mode: window-controls-overlay)').matches ||
         (window.navigator as any).standalone === true; // iOS
}

export function isEdgePWA() {
  const userAgent = navigator.userAgent.toLowerCase();
  const isEdge = userAgent.includes('edg/');
  
  return isEdge && isPWA();
}

// Hook para React
export function useIsEdgePWA() {
  const [isEdgeApp, setIsEdgeApp] = useState(false);

  useEffect(() => {
    const checkPWA = () => {
      setIsEdgeApp(isEdgePWA());
    };

    checkPWA();

    // Monitora mudanças no display-mode
    const mediaQuery = window.matchMedia('(display-mode: standalone)');
    mediaQuery.addEventListener('change', checkPWA);

    return () => mediaQuery.removeEventListener('change', checkPWA);
  }, []);

  return isEdgeApp;
}

 /*
 
 
   const isEdgeApp = useIsEdgePWA();

  useEffect(() => {
    if (isEdgeApp) {
      console.log('Rodando como PWA instalado no Edge!');
      // Aplicar estilos ou funcionalidades específicas
    }
  }, [isEdgeApp]);
  
  */
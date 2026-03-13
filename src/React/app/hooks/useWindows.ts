"use client";
import { useEffect, useState } from 'react';

export interface WindowDimensions {
  height: number;
  width: number;
}

export const useWindow = () => {
  // Inicializa com dimensões válidas se window estiver disponível
  const getInitialDimensions = (): WindowDimensions => {
    if (typeof window !== 'undefined') {
      return {
        height: window.innerHeight,
        width: window.innerWidth,
      };
    }
    // Fallback para dimensões padrão quando window não está disponível (SSR)
    return {
      height: 768, // altura padrão razoável
      width: 1024, // largura padrão razoável
    };
  };

  const [dimensions, setDimensions] = useState<WindowDimensions>(getInitialDimensions);

  useEffect(() => {
    if (typeof window === 'undefined') return;

    const updateDimensions = () => {
      setDimensions({
        height: window.innerHeight,
        width: window.innerWidth,
      });
    };

    // Atualiza as dimensões imediatamente
    updateDimensions();

    // Adiciona listener para mudanças de tamanho da janela
    window.addEventListener('resize', updateDimensions);

    // Cleanup do listener
    return () => {
      window.removeEventListener('resize', updateDimensions);
    };
  }, []);

  return dimensions;
};

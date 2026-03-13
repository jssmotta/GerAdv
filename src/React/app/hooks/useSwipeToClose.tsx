'use client';
import { useEffect, useRef, useCallback } from 'react';

interface SwipeToCloseOptions {
  onClose: () => void;
  threshold?: number; // distância mínima para trigger o close (default: 100px)
  velocityThreshold?: number; // velocidade mínima para trigger o close (default: 0.3)
  enabled?: boolean; // permite desabilitar o swipe (default: true)
  direction?: 'right' | 'left' | 'up' | 'down' | 'horizontal' | 'vertical'; // direção do swipe (default: 'right')
}

interface TouchData {
  startX: number;
  startY: number;
  startTime: number;
  currentX: number;
  currentY: number;
}

export const useSwipeToClose = (options: SwipeToCloseOptions) => {
  const {
    onClose,
    threshold = 100,
    velocityThreshold = 0.3,
    enabled = true,
    direction = 'right'
  } = options;

  const touchDataRef = useRef<TouchData | null>(null);
  const elementRef = useRef<HTMLElement | null>(null);

  const handleTouchStart = useCallback((e: TouchEvent) => {
    if (!enabled || !e.touches || e.touches.length !== 1) return;

    const touch = e.touches[0];
    touchDataRef.current = {
      startX: touch.clientX,
      startY: touch.clientY,
      startTime: Date.now(),
      currentX: touch.clientX,
      currentY: touch.clientY,
    };
  }, [enabled]);

  const handleTouchMove = useCallback((e: TouchEvent) => {
    if (!enabled || !touchDataRef.current || !e.touches || e.touches.length !== 1) return;

    const touch = e.touches[0];
    touchDataRef.current.currentX = touch.clientX;
    touchDataRef.current.currentY = touch.clientY;

    // Calcular distância e direção
    const deltaX = touch.clientX - touchDataRef.current.startX;
    const deltaY = touch.clientY - touchDataRef.current.startY;

    // Verificar se o movimento está na direção desejada
    let shouldPreventDefault = false;
    
    switch (direction) {
      case 'right':
        shouldPreventDefault = deltaX > 30 && Math.abs(deltaY) < Math.abs(deltaX);
        break;
      case 'left':
        shouldPreventDefault = deltaX < -30 && Math.abs(deltaY) < Math.abs(deltaX);
        break;
      case 'up':
        shouldPreventDefault = deltaY < -30 && Math.abs(deltaX) < Math.abs(deltaY);
        break;
      case 'down':
        shouldPreventDefault = deltaY > 30 && Math.abs(deltaX) < Math.abs(deltaY);
        break;
      case 'horizontal':
        shouldPreventDefault = Math.abs(deltaX) > 30 && Math.abs(deltaY) < Math.abs(deltaX);
        break;
      case 'vertical':
        shouldPreventDefault = Math.abs(deltaY) > 30 && Math.abs(deltaX) < Math.abs(deltaY);
        break;
    }

    // Prevenir scroll padrão se estivermos fazendo swipe na direção correta
    if (shouldPreventDefault) {
      e.preventDefault();
    }
    // Se o swipe começou na beirada esquerda da tela e for um swipe à direita
    // consideramos um gesto de "voltar" e acionamos o onClose imediatamente.
    try {
      const EDGE_START_MAX = 50; // px da borda esquerda que conta como gesto de voltar
      const immediateTrigger = 40; // distância para fechar imediatamente
      if (direction === 'right' && touchDataRef.current.startX <= EDGE_START_MAX && deltaX > immediateTrigger) {
        e.preventDefault();
        onClose();
        touchDataRef.current = null;
      }
    } catch (err) {
      // noop
    }
  }, [enabled, direction]);

  const handleTouchEnd = useCallback((e: TouchEvent) => {
    if (!enabled || !touchDataRef.current) return;

    const touchData = touchDataRef.current;
    const endTime = Date.now();
    const deltaTime = endTime - touchData.startTime;
    const deltaX = touchData.currentX - touchData.startX;
    const deltaY = touchData.currentY - touchData.startY;
    
    // Calcular velocidade (pixels por milissegundo)
    const velocityX = Math.abs(deltaX) / deltaTime;
    const velocityY = Math.abs(deltaY) / deltaTime;

    let shouldClose = false;

    // Verificar condições para fechar baseado na direção
    switch (direction) {
      case 'right':
        shouldClose = deltaX > threshold || (deltaX > threshold / 2 && velocityX > velocityThreshold);
        break;
      case 'left':
        shouldClose = deltaX < -threshold || (deltaX < -threshold / 2 && velocityX > velocityThreshold);
        break;
      case 'up':
        shouldClose = deltaY < -threshold || (deltaY < -threshold / 2 && velocityY > velocityThreshold);
        break;
      case 'down':
        shouldClose = deltaY > threshold || (deltaY > threshold / 2 && velocityY > velocityThreshold);
        break;
      case 'horizontal':
        shouldClose = Math.abs(deltaX) > threshold || (Math.abs(deltaX) > threshold / 2 && velocityX > velocityThreshold);
        break;
      case 'vertical':
        shouldClose = Math.abs(deltaY) > threshold || (Math.abs(deltaY) > threshold / 2 && velocityY > velocityThreshold);
        break;
    }

    if (shouldClose) {
      onClose();
    }

    touchDataRef.current = null;
  }, [enabled, threshold, velocityThreshold, direction, onClose]);

  const attachSwipeListeners = useCallback((element: HTMLElement) => {
    if (!element || !enabled) return;

    elementRef.current = element;

    // Usar passive: false para poder chamar preventDefault no touchmove
    element.addEventListener('touchstart', handleTouchStart, { passive: false });
    element.addEventListener('touchmove', handleTouchMove, { passive: false });
    element.addEventListener('touchend', handleTouchEnd, { passive: false });
  }, [enabled, handleTouchStart, handleTouchMove, handleTouchEnd]);

  const detachSwipeListeners = useCallback(() => {
    const element = elementRef.current;
    if (!element) return;

    element.removeEventListener('touchstart', handleTouchStart);
    element.removeEventListener('touchmove', handleTouchMove);
    element.removeEventListener('touchend', handleTouchEnd);
  }, [handleTouchStart, handleTouchMove, handleTouchEnd]);

  useEffect(() => {
    return () => {
      detachSwipeListeners();
    };
  }, [detachSwipeListeners]);

  return {
    attachSwipeListeners,
    detachSwipeListeners
  };
};
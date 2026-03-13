'use client';
import { useRef, useCallback } from 'react';

interface UseSwipeLeftOptions {
  threshold?: number;
  onSwipeLeft?: () => void;
  enabled?: boolean;
}

export const useSwipeLeft = ({ threshold = 80, onSwipeLeft, enabled = true }: UseSwipeLeftOptions) => {
  const startX = useRef<number | null>(null);
  const startY = useRef<number | null>(null);
  const startTime = useRef<number | null>(null);

  const onTouchStart = useCallback((e: React.TouchEvent) => {
    if (!enabled) return;
    if (!e.touches || e.touches.length !== 1) return;
    const t = e.touches[0];
    startX.current = t.clientX;
    startY.current = t.clientY;
    startTime.current = Date.now();
  }, [enabled]);

  const onTouchEnd = useCallback((e: React.TouchEvent) => {
    if (!enabled) return;
    if (startX.current === null || startY.current === null) return;
    if (!e.changedTouches || e.changedTouches.length === 0) {
      // nothing to process
      startX.current = null;
      startY.current = null;
      startTime.current = null;
      return;
    }
    const t = e.changedTouches[0];
    const deltaX = t.clientX - startX.current;
    const deltaY = t.clientY - startY.current;
    const deltaTime = Date.now() - (startTime.current || Date.now());

    // Swipe para a esquerda: deltaX negativo e suficientemente grande
    const isLeftSwipe = deltaX < -threshold && Math.abs(deltaY) < Math.abs(deltaX);

    // também aceitar swipe rápido menor que threshold
    const quickThreshold = Math.max(20, Math.floor(threshold / 2));
    const velocity = Math.abs(deltaX) / Math.max(deltaTime, 1);
    const isQuickLeft = deltaX < -quickThreshold && velocity > 0.3 && Math.abs(deltaY) < Math.abs(deltaX);

    if (isLeftSwipe || isQuickLeft) {
      onSwipeLeft && onSwipeLeft();
    }

    startX.current = null;
    startY.current = null;
    startTime.current = null;
  }, [enabled, threshold, onSwipeLeft]);

  return { onTouchStart, onTouchEnd };
};

export default useSwipeLeft;

// iOS Touch Scroll Fallback Utility
// Manual touch-scroll for iOS (enhanced for bottom controls)

export interface IOSScrollFallbackOptions {
  /** Seletor CSS ou elemento para aplicar o fallback de scroll */
  scrollSelector: string;
  /** Se deve aguardar o DOM estar pronto */
  waitForDOM?: boolean;
  /** Delay para tentar novamente se o elemento não for encontrado */
  retryDelay?: number;
  /** Se deve mostrar logs de debug */
  debug?: boolean;
  /** Permitir rolagem horizontal dentro do scroller (por padrão bloqueado para evitar conflitos) */
  allowHorizontal?: boolean;
}

export const setupIOSScrollFallback = (options: IOSScrollFallbackOptions): (() => void) | undefined => {
  try {
    if (typeof window === 'undefined') return;

    const {
      scrollSelector,
      waitForDOM = true,
      retryDelay = 100,
      debug = false
    } = options;

    const ua = navigator.userAgent || '';
    const isIOS = /iP(ad|hone|od)/.test(ua) || /iPad|iPhone|iPod/.test(navigator.platform || '');
    
    if (!isIOS) return;

    if (debug) {
      console.log('Setting up iOS scroll fallback for:', scrollSelector);
    }

    // Configurar o handler de scroll
    const setupScrollHandler = (): (() => void) | undefined => {
      const scroller = document.querySelector(scrollSelector) as HTMLElement | null;
      
      if (!scroller) {
        if (waitForDOM) {
          // Tentar novamente após um delay se o elemento não for encontrado
          setTimeout(setupScrollHandler, retryDelay);
          return;
        }
        console.warn(`iOS scroll fallback: elemento não encontrado - ${scrollSelector}`);
        return;
      }

      if (debug) {
        console.log('iOS scroll fallback: elemento encontrado, configurando handlers');
      }

      // Forçar propriedades de scroll
      scroller.style.overflowY = 'scroll';
      (scroller.style as any).webkitOverflowScrolling = 'touch';
      // Por padrão bloqueamos o pan-x para evitar conflitos com o scroll vertical
      // Se explicitamente permitido via opção, habilitamos pan-x também
      scroller.style.touchAction = options.allowHorizontal ? 'pan-y pan-x' : 'pan-y';

      let startY = 0;
      let startScroll = 0;
      let touching = false;
      let lastTouchTime = 0;

      const onTouchStart = (ev: TouchEvent) => {
        if (!ev.touches || ev.touches.length !== 1) return;

        // Garantir que estamos tocando na área de scroll, não nos controles inferiores
        const touch = ev.touches[0];
        const rect = scroller.getBoundingClientRect();
        const isWithinScroller = touch.clientY >= rect.top && touch.clientY <= rect.bottom;

        if (!isWithinScroller) return;

        // Verificar se o toque está em elementos da paginação/controles
        const target = ev.target as HTMLElement;
        const pagerElement = target.closest('.k-pager');
        const buttonElement = target.closest('.k-button, .k-dropdown, .k-pager-nav, .k-pager-numbers, .k-pager-sizes');
        
        // Se o toque está na área do pager ou em controles, não interceptar
        if (pagerElement || buttonElement) {
          return;
        }

        // Verificar se o toque está em uma célula interativa (botões, links, etc.)
        const interactiveElement = target.closest('button, a, .k-svg-icon, .k-link, [onclick], [role="button"]');
        if (interactiveElement) {
          return;
        }

        touching = true;
        startY = touch.clientY;
        startScroll = scroller.scrollTop;
        lastTouchTime = Date.now();

        // Parar qualquer scroll de momentum
        scroller.style.overflowY = 'hidden';
        setTimeout(() => {
          if (scroller) scroller.style.overflowY = 'scroll';
        }, 0);
      };

      const onTouchMove = (ev: TouchEvent) => {
        if (!touching || !ev.touches || ev.touches.length !== 1) return;

        const curY = ev.touches[0].clientY;
        const dy = startY - curY;
        const newScrollTop = startScroll + dy;

        // Limitar ao range válido de scroll
        const maxScroll = scroller.scrollHeight - scroller.clientHeight;
        scroller.scrollTop = Math.max(0, Math.min(newScrollTop, maxScroll));

        // Prevenir que a página role enquanto interagindo com o grid
        ev.preventDefault();
        ev.stopPropagation();
      };

      const onTouchEnd = (ev: TouchEvent) => {
        if (!touching) return;
        touching = false;

        // Re-habilitar scroll de momentum
        (scroller.style as any).webkitOverflowScrolling = 'touch';

        // Adicionar momentum se o toque foi rápido
        const touchDuration = Date.now() - lastTouchTime;
        if (touchDuration < 100 && ev.changedTouches) {
          const momentum = (startY - ev.changedTouches[0].clientY) * 2;
          const targetScroll = scroller.scrollTop + momentum;
          const maxScroll = scroller.scrollHeight - scroller.clientHeight;
          const clampedScroll = Math.max(0, Math.min(targetScroll, maxScroll));

          scroller.scrollTo({
            top: clampedScroll,
            behavior: 'smooth'
          });
        }
      };

      // Usar passive: false para touchmove para permitir preventDefault
      scroller.addEventListener('touchstart', onTouchStart, { passive: true });
      scroller.addEventListener('touchmove', onTouchMove, { passive: false });
      scroller.addEventListener('touchend', onTouchEnd, { passive: true });

      // Retornar função de limpeza
      return () => {
        scroller.removeEventListener('touchstart', onTouchStart as any);
        scroller.removeEventListener('touchmove', onTouchMove as any);
        scroller.removeEventListener('touchend', onTouchEnd as any);
      };
    };

    const cleanup = setupScrollHandler();
    return cleanup;
  } catch (err) {
    if (options.debug || process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
      console.error('iOS enhanced scroll fallback error', err);
    }
    return undefined;
  }
};

/**
 * Hook personalizado para usar o fallback de scroll iOS
 */
export const useIOSScrollFallback = (options: IOSScrollFallbackOptions) => {
  if (typeof window === 'undefined') return;

  const cleanup = setupIOSScrollFallback(options);
  
  // Retornar função de limpeza para ser usada em useEffect
  return cleanup;
};

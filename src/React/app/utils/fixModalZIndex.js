/**
 * Fix para janelas modais Kendo UI que ficam atrás de overlays
 * Monitora e corrige automaticamente o z-index de janelas modais
 */

let observer = null;
let interval = null;

export const fixModalZIndex = () => {
  const overlays = document.querySelectorAll('.k-overlay');
  const windows = document.querySelectorAll('.k-window, .k-dialog');
  
  if (overlays.length > 0 && windows.length > 0) {
    // Pega o maior z-index dos overlays
    let maxOverlayZIndex = 0;
    overlays.forEach(overlay => {
      const zIndex = parseInt(window.getComputedStyle(overlay).zIndex) || 0;
      maxOverlayZIndex = Math.max(maxOverlayZIndex, zIndex);
    });
    
    // Ajusta janelas para ficar acima do overlay
    windows.forEach((window, index) => {
      const currentZIndex = parseInt(window.style.zIndex) || 0;
      if (currentZIndex <= maxOverlayZIndex) {
        window.style.zIndex = maxOverlayZIndex + 10 + index;
        console.log(`Fixed window z-index from ${currentZIndex} to ${maxOverlayZIndex + 10 + index}`);
      }
    });
  }
};

export const startModalZIndexFix = () => {
  if (observer || interval) {
    stopModalZIndexFix();
  }
  
  // Observa mudanças no DOM
  observer = new MutationObserver(fixModalZIndex);
  observer.observe(document.body, { 
    childList: true, 
    subtree: true, 
    attributes: true, 
    attributeFilter: ['style', 'class'] 
  });
  
  // Executa imediatamente e a cada 100ms
  fixModalZIndex();
  interval = setInterval(fixModalZIndex, 100);
  
  console.log('Modal Z-Index fix started');
};

export const stopModalZIndexFix = () => {
  if (observer) {
    observer.disconnect();
    observer = null;
  }
  
  if (interval) {
    clearInterval(interval);
    interval = null;
  }
  
  console.log('Modal Z-Index fix stopped');
};

// Auto-start quando o DOM estiver pronto
if (typeof document !== 'undefined') {
  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', startModalZIndexFix);
  } else {
    startModalZIndexFix();
  }
}
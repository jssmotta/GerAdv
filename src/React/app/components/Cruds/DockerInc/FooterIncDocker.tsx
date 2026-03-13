'use client';
import React, { useEffect, useRef, useState } from 'react';
import { useIsMobile } from '@/app/context/MobileContext';
import WhatsAppButton from '@/app/components/Cruds/DockerInc/WhatsAppButton';
import '@/app/styles/FooterIncDocker.css';
import { SvgIcon } from '@progress/kendo-react-common';
import { clockIcon } from '@progress/kendo-svg-icons';

// Função que retorna data e hora no formato dd/MM/yyyy HH:mm:ss
const RelogioDataHoraSegundo = (): string => {
  const now = new Date();
  
  // Formata usando pt-BR ou o locale do navegador
  const locale = 'pt-BR';
  
  const day = now.getDate().toString().padStart(2, '0');
  const month = (now.getMonth() + 1).toString().padStart(2, '0');
  const year = now.getFullYear();
  
  const hours = now.getHours().toString().padStart(2, '0');
  const minutes = now.getMinutes().toString().padStart(2, '0');
  const seconds = now.getSeconds().toString().padStart(2, '0');
  
  return `${day}/${month}/${year} ${hours}:${minutes}:${seconds}`;
};

interface FooterIncDockerProps {
  children: React.ReactNode;
  tableTitle?: string;
}

const FooterIncDocker: React.FC<FooterIncDockerProps> = ({ children, tableTitle }) => {
  const isMobile = useIsMobile();
  const containerRef = useRef<HTMLDivElement>(null);
  const [visibleCount, setVisibleCount] = useState(0);
  const [currentTime, setCurrentTime] = useState(RelogioDataHoraSegundo());
  const startTimeRef = useRef<number>(Date.now());
  const [elapsedSeconds, setElapsedSeconds] = useState<number>(0);

  // Atualiza o relógio a cada segundo
  useEffect(() => {
    // Marca o início quando o componente monta
    startTimeRef.current = Date.now();

    const interval = setInterval(() => {
      setCurrentTime(RelogioDataHoraSegundo());
      const secs = Math.floor((Date.now() - startTimeRef.current) / 1000);
      setElapsedSeconds(secs);
    }, 1000);

    return () => clearInterval(interval);
  }, []);

  const formatElapsed = (totalSeconds: number) => {
    const hours = Math.floor(totalSeconds / 3600);
    const minutes = Math.floor((totalSeconds % 3600) / 60);
    const seconds = totalSeconds % 60;
    if (hours > 0) {
      return `${hours}h ${minutes}m ${seconds}s`;
    }
    if (minutes > 0) {
      return `${minutes}m ${seconds}s`;
    }
    return `${seconds}s`;
  };

  useEffect(() => {
    if (!isMobile || !containerRef.current) return;

    const observer = new MutationObserver(() => {
      if (containerRef.current) {
        const buttons = containerRef.current.querySelectorAll('button, a, [role="button"]');
        const visible = Array.from(buttons).filter(button => {
          const element = button as HTMLElement;
          const style = window.getComputedStyle(element);
          return style.display !== 'none' && 
                 style.visibility !== 'hidden' && 
                 style.opacity !== '0' &&
                 element.offsetParent !== null;
        });
        setVisibleCount(visible.length);
      }
    });

    observer.observe(containerRef.current, {
      childList: true,
      subtree: true,
      attributes: true,
      attributeFilter: ['style', 'class']
    });

    // Checagem inicial
    const buttons = containerRef.current.querySelectorAll('button, a, [role="button"]');
    const visible = Array.from(buttons).filter(button => {
      const element = button as HTMLElement;
      const style = window.getComputedStyle(element);
      return style.display !== 'none' && 
             style.visibility !== 'hidden' && 
             style.opacity !== '0' &&
             element.offsetParent !== null;
    });
    setVisibleCount(visible.length);

    return () => observer.disconnect();
  }, [isMobile]);

  if (!isMobile) {
    // No desktop, os ícones são renderizados em um container inline à direita
    return (
      <>
      <div style={{  borderTop: '1px solid var(--border-color)', position: 'absolute', bottom: 0, left: 0, right: 0, height: '33px' }}>
        <div style={{
        position: 'absolute',
        bottom: '10px',
        left: '10px',        
        alignItems: 'center',
        color: 'var(--text-menu-popup)',
        gap: '8px',
        zIndex: 999
      }} className="bottom-window-edit">
         <SvgIcon icon={clockIcon} /> {currentTime} — {formatElapsed(elapsedSeconds)} {elapsedSeconds > 60 && `(${elapsedSeconds}s)`}
        </div>
      <div style={{
        position: 'absolute',
        bottom: '10px',
        right: '10px',
        display: 'flex',
        alignItems: 'center',
        gap: '8px',
        zIndex: 999
      }}>        
        {children}
        <WhatsAppButton tableTitle={tableTitle} />
      </div>
      </div>
      </>
    ); 
  }

  // No mobile, renderiza os ícones em um container fixo com CSS mais agressivo
  return (
    <>
      <style jsx>{`
        .footer-inc-docker {
          position: fixed !important;
          top: 50% !important;
          right: 5px !important;
          transform: translateY(-50%) !important;
          display: flex !important;
          flex-direction: column !important;
          gap: 8px !important;
          z-index: 99999 !important;
          align-items: center !important;
          justify-content: center !important;
          pointer-events: auto !important;
          visibility: visible !important;
          opacity: 1 !important;
        }
        
        .footer-inc-docker > * {
          pointer-events: auto !important;
        }
        
        .footer-inc-docker > *:not([style*="display: none"]):not([style*="visibility: hidden"]):not([style*="opacity: 0"]) {
          visibility: visible !important;
          opacity: 1 !important;
          display: flex !important;
          align-items: center !important;
          justify-content: center !important;
        }
        
        .footer-inc-docker > *[style*="display: none"],
        .footer-inc-docker > *[style*="visibility: hidden"],
        .footer-inc-docker > *[style*="opacity: 0"] {
          display: none !important;
        }
      `}</style>
      
      <div ref={containerRef} className="footer-inc-docker" data-visible-count={visibleCount}>               
        {children} 
      </div>
    </>
  ); 
};

export default FooterIncDocker;
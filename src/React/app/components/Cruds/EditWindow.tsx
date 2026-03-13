'use client';
import { WindowDimensions } from '../../hooks/useWindows';
import { Window } from '@progress/kendo-react-dialogs';
import React, { useEffect, useState, useRef, useMemo } from 'react';
import { PHeightWindow, PWidthWindow } from '../../tools/defInc';
import { useSwipeToClose } from '@/app/hooks/useSwipeToClose';
import { SvgIcon } from '@progress/kendo-react-common';
import { chevronLeftIcon } from '@progress/kendo-svg-icons';

interface EditWindowProps {
  tableTitle: string;
  isOpen: boolean;
  onClose: () => void;
  dimensions: WindowDimensions;
  children: React.ReactNode;
  newHeight?: number;
  newWidth?: number;
  id?: string | null;
  mobile?: boolean;
  crud?: boolean;
  maxWidth?: number;
}

// Custom hook for window dimensions to avoid hydration mismatch
const useWindowDimensions = () => {
  const [windowSize, setWindowSize] = useState({
    width: 800,
    height: 600,
  });

  useEffect(() => {
    const handleResize = () => {
      setWindowSize({
        width: window.innerWidth,
        height: window.innerHeight,
      });
    };
    
    // Set initial size
    handleResize();
    
    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  return windowSize;
};

export const EditWindow: React.FC<EditWindowProps> = ({
  tableTitle,
  isOpen,
  onClose,
  dimensions,
  children,
  newHeight,
  newWidth,
  mobile,
  id,
  crud,
  maxWidth
}) => {
  const PFadeOutDuration = 666;
  const [visible, setVisible] = useState(false);
  const [shouldRender, setShouldRender] = useState(false);
  const [isClosing, setIsClosing] = useState(false);
  const onCloseRef = useRef(onClose); 
  const mobileWindowRef = useRef<HTMLDivElement>(null);
  const hasBeenPositioned = useRef(false);
  
  // Use hook for window dimensions to avoid hydration mismatch
  const windowSize = useWindowDimensions();

  // Atualiza a referência sempre que onClose mudar
  useEffect(() => {
    onCloseRef.current = onClose;
  }, [onClose]);

  const EmptyButton = (props: any) => {
    return <></>;
  };

  useEffect(() => {
    if (isOpen && !isClosing) {
      setShouldRender(true);
      setIsClosing(false);
      setTimeout(() => setVisible(true), 10);
    } else if (!isOpen && !isClosing) {
      // Reset states when externally closed
      setVisible(false);
      setShouldRender(false);
      setIsClosing(false);
    }
  }, [isOpen, isClosing]);

  // Função interceptadora que sempre aplica fadeout no desktop
  const interceptedOnClose = () => {
    if (mobile) {
      onCloseRef.current();
    } else {
      setIsClosing(true);
      setVisible(false);
      setTimeout(() => {
        setIsClosing(false);
        setShouldRender(false);
        onCloseRef.current();
      }, PFadeOutDuration);
    }
  };

  // Hook para swipe to close em mobile
  const { attachSwipeListeners, detachSwipeListeners } = useSwipeToClose({
    onClose: interceptedOnClose,
    threshold: 80,
    velocityThreshold: 0.4,
    enabled: mobile === true,
    direction: 'right'
  });

  // Intercepta todas as chamadas de onClose nos elementos filhos
  const interceptChildren = (children: React.ReactNode): React.ReactNode => {
    return React.Children.map(children, (child) => {
      if (React.isValidElement(child)) {
        // Se o elemento tem uma prop onClose, substitui pela nossa função
        const element = child as React.ReactElement<any>;
        if (element.props.onClose) {
          return React.cloneElement(element, {
            onClose: interceptedOnClose,
            children: element.props.children
              ? interceptChildren(element.props.children)
              : element.props.children,
          });
        }
        // Se tem children, processa recursivamente
        if (element.props.children) {
          return React.cloneElement(element, {
            children: interceptChildren(element.props.children),
          });
        }
      }
      return child;
    });
  };

    // Detecta se já existe outra <Window> aberta na página.
    // Observa o DOM por mudanças (outras janelas sendo abertas/fechadas)
    // Nota: usamos a classe CSS padrão do Kendo React Window ("k-window").
    // Assunção: o Kendo Window adiciona a classe "k-window" ao elemento principal.
    const [thereAreNoOthers, setThereAreNoOthers] = useState(false);

    useEffect(() => {
      if (typeof document === 'undefined') {
        setThereAreNoOthers(false);
        return;
      }

      const update = () => {
        // Conta todas as janelas com a classe padrão do Kendo
        const windows = document.getElementsByClassName('k-window');
        // Se esta janela já está aberta (isOpen), subtrai 1 para verificar "outras"
        const others = windows.length - (isOpen ? 1 : 0);
        // Conforme solicitado: quando já existir outra <Window> aberta retorna true,
        // se não existir outra retorna false.
        setThereAreNoOthers(others > 0);
      };

      update();
      const observer = new MutationObserver(update);
      observer.observe(document.body, { childList: true, subtree: true });
      return () => observer.disconnect();
    }, [isOpen]);

  // Força reposicionamento para garantir alinhamento à direita em qualquer resolução (para desktop)
  useEffect(() => {
    if (!mobile && visible && shouldRender) {
      let animationFrameId: number;
      
      const repositionWindow = () => {
        const windowElement = document.querySelector('.k-window:last-child') as HTMLElement;
        if (windowElement) {
          const viewportWidth = window.innerWidth;
          const viewportHeight = window.innerHeight;
          // Limita a largura da janela para caber no viewport com margem mínima de 20px de cada lado
          const maxAllowedWidth = viewportWidth - 40;
          const requestedWidth = crud && crud ? viewportWidth-200 : newWidth ? newWidth + 40 : PWidthWindow;
          const widthUsed = maxWidth ? maxWidth : requestedWidth > maxAllowedWidth ? Math.min(requestedWidth, maxAllowedWidth) : requestedWidth;

          //EditWindow.tsx:185 1366 2509 1366
          //console.log(requestedWidth, maxAllowedWidth, widthUsed);
          
          // Posiciona 50px abaixo do topo e alinhado à direita
          const rightPosition = maxWidth ? 100 : Math.max(20, viewportWidth - widthUsed - 20);
          // Compensa o zoom CSS de 88% em telas <= 1366px
          const zoomFactor = (crud && crud) ? 1 : viewportWidth <= 1366 ? 1 / 0.88 : 1;
          const adjustedHeight = (crud && crud) ? window.innerHeight + 20 : maxWidth ? viewportHeight - 50 : Math.round((viewportHeight - 50) * zoomFactor);          
          
          // Atualiza a posição e dimensões - FORÇA A ALTURA CORRETA
          windowElement.style.left = `${rightPosition}px`;
          windowElement.style.top = `50px`;
          windowElement.style.height = `${adjustedHeight}px`;
          windowElement.style.width = `${widthUsed}px`;
        }
        
        // Continua verificando em loop usando requestAnimationFrame
        animationFrameId = requestAnimationFrame(repositionWindow);
      };

      // Inicia o loop de reposicionamento
      animationFrameId = requestAnimationFrame(repositionWindow);
      
      return () => {
        if (animationFrameId) {
          cancelAnimationFrame(animationFrameId);
        }
      };
    }
}, [visible, shouldRender, mobile, dimensions?.height, dimensions?.width, newHeight, newWidth, maxWidth]);

  // Reset do posicionamento quando a janela é fechada
  useEffect(() => {
    if (!isOpen) {
      hasBeenPositioned.current = false;
    }
  }, [isOpen]);

  // Configurar swipe listeners para mobile
  useEffect(() => {
    if (mobile && isOpen && mobileWindowRef.current) {
      attachSwipeListeners(mobileWindowRef.current);
      return () => {
        detachSwipeListeners();
      };
    }
  }, [mobile, isOpen, attachSwipeListeners, detachSwipeListeners]);

  // Não renderiza se as dimensões são inválidas ou se não deve renderizar
  if (!shouldRender || dimensions.height === 0 || dimensions.width === 0)
    return null;

  const processedChildren = interceptChildren(children);

  // Compute centered position using actual numeric top/left instead of CSS transform.
  // Using transform: translate(...) prevents the Window from updating top/left when
  // the user drags or when the component tries to move itself. Use initialTop/Left
  // so the Kendo Window can control positioning and allow draggable/resizable to work.
  
  // Usa windowSize do hook ao invés de acessar window diretamente para evitar hydration mismatch
  const viewportHeight = windowSize.height || Math.max(dimensions.height, 600);
  const viewportWidth =maxWidth ? maxWidth :  windowSize.width || Math.max(dimensions.width, 800);
  
  // Limita a largura da janela para caber no viewport com margem mínima de 20px de cada lado
  const maxWidthX = viewportWidth - 40;
  const requestedWidth = newWidth ? newWidth : PWidthWindow;
  const widthUsed = maxWidth ? maxWidth : Math.min(requestedWidth, maxWidthX);
  
  // Posiciona a janela alinhada à direita e com altura total menos 50px do topo
  const rightPosition =  maxWidth ? 100 : Math.max(20, viewportWidth - widthUsed - 20);
  // IMPORTANTE: Compensa o zoom CSS de 88% em telas <= 1366px
  // Se a largura for <= 1366, o zoom CSS reduz tudo para 88%, então precisamos compensar
  const zoomFactor = maxWidth ? 1 : viewportWidth <= 1366 ? 1 / 0.88 : 1;
  const adjustedHeight = Math.round((viewportHeight - 50) * zoomFactor);
  
  return (
    <>    
      {mobile ? (
        <>
          <style dangerouslySetInnerHTML={{
            __html: `
              .mobile-window-fullscreen {
                position: fixed !important;
                top: 0 !important;
                left: 0 !important;
                right: 0 !important;
                bottom: var(--footer-bar-height) !important;
                width: 100% !important;
                max-width: 100% !important;
                height: calc(100% - var(--footer-bar-height)) !important;
                margin: 0 !important;
                border-radius: 0 !important;
              }
              .mobile-window-fullscreen .k-window-content {
                width: 100% !important;
                max-width: 100% !important;
                padding: 0 !important;
                height: 100% !important;
                overflow-y: auto !important;
              }
            `
          }} />
          <Window
            title={
             <span style={{ display: "flex", alignItems: "center", width: "100%", position: "relative" }}>
              <span
                   
                  style={{ fontSize: '32px', fontWeight: 'bold', color: 'var(--color-menphissi)', cursor: "pointer", position: "absolute", left: 0 }}
                  onClick={onClose}
              >
                <SvgIcon className='back-mobile' icon={chevronLeftIcon} size='large' />
                </span>
              <span style={{ paddingLeft: '16px', flex: 1, textAlign: "center" }}>{tableTitle.toUpperCase()}</span>
          </span>
            }
              // tableTitle.toUpperCase()}
            onClose={interceptedOnClose}
            initialTop={0}
            initialLeft={0}
            modal={false}
            minimizeButton={EmptyButton}
            maximizeButton={EmptyButton}
            restoreButton={EmptyButton}
            closeButton={EmptyButton}
            className="mobile-window-fullscreen"
            style={{
              width: '100%',
              height: 'calc(100vh - var(--footer-bar-height))',              
            }}
          >

            {crud && crud ?
                <div className='crud-mobile-title'
                  ref={mobileWindowRef}
                  style={{ height: '100%', overflowY: 'auto', width: '100%', padding: '1px', paddingLeft:'2px' }}
                >
                  {processedChildren}
                </div>
            :
                <div
                  ref={mobileWindowRef}
                  style={{ height: '100%', overflowY: 'auto', width: '100%', padding: '6px', paddingLeft:'24px' }}
                >
                  {processedChildren}
                </div>
            }


          </Window>
        </>
      ) : (
        <>
          <style dangerouslySetInnerHTML={{
            __html: `
              .edit-window-right-aligned {
                position: fixed !important;
                top: 50px !important;
                right: 0px !important;
                left: auto !important; 
                max-width: calc(100vw - 40px) !important;
              }
              .edit-window-right-aligned .k-window-content {
                height: 100% !important;
                max-height: none !important;
                overflow-y: auto !important;
              }
              .edit-window-right-aligned .k-content {
                height: 100% !important;
                max-height: none !important;
              }
            `
          }} />
          <Window

          title={
              <span style={{ display: "flex", alignItems: "left", width: "100%", position: "relative" }}>
                  <span                    
                      style={{ fontSize: '32px', fontWeight: 'bold', color: 'var(--color-menphissi)', cursor: "pointer", position: "absolute", left: 0, top: '-10px' }}
                      onClick={onClose}
                  >
                  <SvgIcon className='back-mobile' icon={chevronLeftIcon} size='large' />
                  </span>
                  <span style={{ paddingLeft: '32px', flex: 1, textAlign: "left", }} title={ id==null ? '' : id == '0' ? 'Inclusão ' + tableTitle : '[' + id +'] ' + tableTitle}> 
                    <>
                      {tableTitle.toUpperCase() + (id==null ? '' :  ' - ' + (id == '0' ? 'Inclusão' : 'Editando'))} 
                    </>
                  </span>            
              </span>            
            }
           
            onClose={interceptedOnClose}
            draggable={true}
            resizable={true}
            minimizeButton={EmptyButton}
            maximizeButton={EmptyButton}
            height={adjustedHeight}
            initialHeight={adjustedHeight}
            width={maxWidth ? maxWidth : widthUsed}
            initialTop={50}
            initialLeft={rightPosition}
            modal={thereAreNoOthers}
            style={{
              opacity: visible ? 1 : 0,
              transition: 'opacity 2.6s ease',
            }}
            className="msishad-shadow edit-window-right-aligned"
          > 
          {crud && crud ?
            <div  className='crud-desktop-title'
              style={{ zoom: 0.95, height: '98%', overflow: 'none', width: '100%', padding: '0px' }}>
           
              {processedChildren}         
            </div>
            :
              <div 
                style={{ height: '98%', overflow: 'none', width: '96%', padding: '5px', paddingLeft: '22px', paddingRight: '22px' }}>            
              {processedChildren}         
            </div>
          }
          </Window>
        </>
      )}
    </>
  );
};

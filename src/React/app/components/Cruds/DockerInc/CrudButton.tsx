'use client';
import React, { useState, useRef, useEffect } from 'react';
import { useIsMobile } from '@/app/context/MobileContext';
import { SvgIcon } from '@progress/kendo-react-common';
import { gridIcon } from '@progress/kendo-svg-icons';  
import { useWindow } from '@/app/hooks/useWindows';
import { EditWindow } from '../EditWindow';

// Singleton em memória: título -> instanceId de quem abriu
const openCrudRegistry = new Map<string, string>();

interface CrudButtonProps {  
  title: string;
  windowCrud: any;
}

const CrudButton: React.FC<CrudButtonProps> = ({    
  title,
  windowCrud
}) => {
  const isMobile = useIsMobile();
  const [isOpen, setIsOpen] = useState(false);
  const dimensionsEmpty = useWindow();
  const instanceId = useRef(Math.random().toString(36));

  // Limpa o registry automaticamente se o componente for desmontado sem chamar onClose
  useEffect(() => {
    return () => {
      if (openCrudRegistry.get(title) === instanceId.current) {
        openCrudRegistry.delete(title);
      }
    };
  }, [title]);

  // Oculta o botão se OUTRO componente já abriu este mesmo título (previne recursão)
  const registeredId = openCrudRegistry.get(title);
  if (registeredId !== undefined && registeredId !== instanceId.current) return null;

  const desktopStyle = {
    display: 'inline-block',
    width: 'auto',
    color: 'white',
    height: '20px',
    cursor: 'pointer',
    marginLeft: '8px'
  };

  const mobileStyle = {
    width: '40px !important' as any,
    height: '40px !important' as any,
    minWidth: '40px !important' as any,
    minHeight: '40px !important' as any,
    backgroundColor: '#fff !important' as any,
    borderRadius: '50% !important' as any,
    display: 'flex !important' as any,
    alignItems: 'center !important' as any,
    justifyContent: 'center !important' as any,
    cursor: 'pointer !important' as any,
    boxShadow: '0 2px 8px rgba(0,0,0,0.5) !important' as any,
    color: '#4CAF50 !important' as any,
    border: '2px solid #4CAF50 !important' as any,
    position: 'relative' as any,
    zIndex: '10000 !important' as any,
    pointerEvents: 'auto !important' as any,
    visibility: 'visible !important' as any,
    opacity: '1 !important' as any
  };
 
  const WindowCrud = windowCrud;

  const onClickCrud = () => {
    if (!isOpen) {
      openCrudRegistry.set(title, instanceId.current);
    } else {
      if (openCrudRegistry.get(title) === instanceId.current) {
        openCrudRegistry.delete(title);
      }
    }
    setIsOpen(!isOpen);
  };

  const onClose = () => {
    if (openCrudRegistry.get(title) === instanceId.current) {
      openCrudRegistry.delete(title);
    }
    setIsOpen(false);
  };

  return (
    <>
      {isMobile && (
        <style jsx>{`
          .crud-window-button-mobile {
            width: 40px !important;
            height: 40px !important;
            min-width: 40px !important;
            min-height: 40px !important;
            background-color: #fff !important;
            border-radius: 50% !important;
            display: flex !important;
            align-items: center !important;
            justify-content: center !important;
            cursor: pointer !important;
            box-shadow: 0 2px 8px rgba(0,0,0,0.5) !important;
            color: #4CAF50 !important;
            border: 2px solid #4CAF50 !important;
            position: relative !important;
            z-index: 10000 !important;
            pointer-events: auto !important;
            visibility: visible !important;
            opacity: 1 !important;
          }
          
          .crud-window-button-mobile:hover {
            transform: scale(1.1) !important;
            box-shadow: 0 4px 12px rgba(0,0,0,0.6) !important;
          }
        `}</style>
      )}
      <div 
        title={`Abrir cadastro de ${title}`} 
        onClick={onClickCrud} 
        style={isMobile ? mobileStyle : desktopStyle}
        className={isMobile ? 'crud-window-button-mobile' : ''}
        tabIndex={996}
      >
        <SvgIcon icon={gridIcon} />
      </div>

    <EditWindow
          tableTitle={title}
          isOpen={isOpen}
          onClose={onClose}
          dimensions={dimensionsEmpty}
          newHeight={560}
          newWidth={1360}
          mobile={isMobile}
          crud={true}
        >        
            <WindowCrud noLayout={true} />
      </EditWindow>      
    </>
  );
};

export default CrudButton;

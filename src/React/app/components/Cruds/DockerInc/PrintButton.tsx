'use client';
import React from 'react';
import { useIsMobile } from '@/app/context/MobileContext';
import { SvgIcon } from '@progress/kendo-react-common';
import { printIcon } from '@progress/kendo-svg-icons';
import { printCurrentWindow } from '@/app/utils/printCurrentWindow';

interface PrintButtonProps {  
  formId: string;
}

const PrintButton: React.FC<PrintButtonProps> = ({    
  formId
}) => {
  const isMobile = useIsMobile();  

  const onPrintClick = () => {
    if (typeof window !== 'undefined') {
      printCurrentWindow(formId);
    }
  };

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
    color: '#2196F3 !important' as any,
    border: '2px solid #2196F3 !important' as any,
    position: 'relative' as any,
    zIndex: '10000 !important' as any,
    pointerEvents: 'auto !important' as any,
    visibility: 'visible !important' as any,
    opacity: '1 !important' as any
  };
 
  return (
    <>
      {isMobile && (
        <style jsx>{`
          .print-button-mobile {
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
            color: #2196F3 !important;
            border: 2px solid #2196F3 !important;
            position: relative !important;
            z-index: 10000 !important;
            pointer-events: auto !important;
            visibility: visible !important;
            opacity: 1 !important;
          }
          
          .print-button-mobile:hover {
            transform: scale(1.1) !important;
            box-shadow: 0 4px 12px rgba(0,0,0,0.6) !important;
          }
        `}</style>
      )}
      <div 
        title='Imprimir este formulário' 
        onClick={onPrintClick} 
        style={isMobile ? mobileStyle : desktopStyle}
        className={isMobile ? 'print-button-mobile' : ''}
        tabIndex={997}
      >
        <SvgIcon icon={printIcon} />
      </div>
    </>
  );
};

export default PrintButton;

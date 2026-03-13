import React from 'react';
import { Button } from '@progress/kendo-react-buttons';
import { arrowRotateCwIcon } from '@progress/kendo-svg-icons';

const NavButtons: React.FC = () => {

  // Função para detectar se é iPad ou tablet Android
  const isTablet = () => {
    if (typeof window === 'undefined') return false;
    
    const userAgent = navigator.userAgent || navigator.vendor || (window as any).opera;
    
    // Detecta iPad
    const isIPad = /iPad/.test(userAgent) || 
                   (navigator.platform === 'MacIntel' && navigator.maxTouchPoints > 1);
    
    // Detecta tablets Android
    const isAndroidTablet = /Android/.test(userAgent) && !/Mobile/.test(userAgent);
    
    return isIPad || isAndroidTablet;
  };
  
  const goBack = () => {
    if (typeof window !== 'undefined') {
      window.history.back();
    }
  };

  const goForward = () => {
    if (typeof window !== 'undefined') {
      window.history.forward();
    }
  };

  const refresh = () => {
    if (typeof window !== 'undefined') {
      window.location.reload();
    }
  };

  // Exibe os botões se: for EdgeApp OU (não for mobile OU for tablet)
  const shouldShowButtons = isTablet();

  return shouldShowButtons ? (
    <div style={{ display: 'flex', gap: '2px' }}>
      <Button className='buttonNavTop' title="Voltar" onClick={goBack} aria-label="Voltar">
        &lt;
      </Button>
      <Button className='buttonNavTop' title="Avançar de volta" onClick={goForward} aria-label="Avançar">
        &gt;
      </Button>
      <Button className='buttonNavTop' title="Atualizar página" onClick={refresh} aria-label="Atualizar" svgIcon={arrowRotateCwIcon}>
      </Button>
    </div>
  ) : (
    <></>
  );
};

export default NavButtons;

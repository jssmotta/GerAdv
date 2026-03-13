'use client';

import '@/app/styles/ViewMobile.css';
import { Button } from '@progress/kendo-react-buttons';
import { SvgIcon } from '@progress/kendo-react-common';
import { fontGrowIcon, fontShrinkIcon, gridIcon } from '@progress/kendo-svg-icons';
import React, { useState } from 'react';

export type TypeView = 'grid' | 'large' | 'slim';

interface ViewMobileContainerProps {
  title: string;
  children: (typeView: TypeView) => React.ReactNode;
  toolbar: React.ReactNode;
  exportbar: React.ReactNode;
}

const ViewMobileContainer: React.FC<ViewMobileContainerProps> = ({ title, children, toolbar, exportbar }) => {
  const storageKey = btoa(`view-mobile-type-${title}`);

  const [typeView, setTypeView] = useState<TypeView>(() => {
    if (typeof window === 'undefined') return 'large';
    try {
      const saved = localStorage.getItem(storageKey);
      if (saved === 'grid' || saved === 'large' || saved === 'slim') return saved as TypeView;
    } catch { }
    return 'large';
  });

  const handleSetTypeView = (view: TypeView) => {
    setTypeView(view);
    try {
      localStorage.setItem(storageKey, view);
    } catch { }
  };

  return (
    <>
      <ViewMobileControl exportbar={exportbar} toolbar={toolbar} typeView={typeView} setTypeView={handleSetTypeView} />
      {children(typeView)}      
    </>
  );
};

interface ViewMobileControlProps {
  typeView: TypeView;
  setTypeView: (view: TypeView) => void;
  toolbar: React.ReactNode;
  exportbar: React.ReactNode;
}

export const ViewMobileControl: React.FC<ViewMobileControlProps> = ({ typeView, setTypeView, toolbar, exportbar }) => {
  return (
    <>
      <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', borderBottom: '1px solid var(--kendo-color-border)', backgroundColor: 'var(--kendo-color-surface)', width: '100%' }}>
        <div style={{ flex: 1 }}>{toolbar}</div>
        <div style={{ flex: 1 }}>{exportbar}</div>
        <div className="cards-control">          
          <Button
            className={`cards-control-btn`}
            onClick={() => setTypeView(typeView === 'slim' ? 'large' : typeView === 'large' ? 'grid' : 'slim')}
            title="Visualização em cartões compactos"
            style={{color: 'var(--accent-color)'}}
          >
            {typeView === 'slim' ?  
            <small><SvgIcon icon={fontShrinkIcon} /></small> :
            typeView === 'large' ?
            <small><SvgIcon icon={fontGrowIcon} /></small> :
            <small><SvgIcon icon={gridIcon} /></small>}         
          
          </Button>
        </div>
      </div>
    </>
  );
};

export default ViewMobileContainer;
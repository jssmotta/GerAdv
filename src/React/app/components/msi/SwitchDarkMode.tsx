'use client';
import React from 'react';
import { Button } from '@progress/kendo-react-buttons';
import { useAppDispatch, useAppSelector } from '../../store/hooks';
import { selectDarkMode, setDarkMode } from '../../store/slices/systemContextSlice';

export const SwitchDarkMode: React.FC = () => {
  const dispatch = useAppDispatch();
  const darkMode = useAppSelector(selectDarkMode);

  const handleToggle = () => {
    if (darkMode === 'light') {
      dispatch(setDarkMode('dark'));
    } else if (darkMode === 'dark') {
      dispatch(setDarkMode('auto'));
    } else {
      dispatch(setDarkMode('light'));
    }
  };

  const getIcon = () => {
    switch (darkMode) {
      case 'light':
        return '☀️'; // Sol
      case 'dark':
        return '🌙'; // Lua
      case 'auto':
      default:
        return '🔄'; // Auto/Sincronizar
    }
  };

  const getTitle = () => {
    switch (darkMode) {
      case 'light':
        return 'Modo Claro - Clique para Modo Escuro';
      case 'dark':
        return 'Modo Escuro - Clique para Modo Auto';
      case 'auto':
      default:
        return 'Modo Auto (Sistema) - Clique para Modo Claro';
    }
  };

  return (
    <Button
      onClick={handleToggle}
      title={getTitle()}
      aria-label={getTitle()}
    
      style={{
        background: 'transparent',
        border: 'none',
        fontSize: '1.5rem',
        cursor: 'pointer',
        width: '16px',
        marginLeft: '6px',  
        marginRight: '-6px',
        height: '16px',
        padding: '0px 0px',
        transition: 'transform 0.2s ease',
      }}
      onMouseEnter={(e) => {
        e.currentTarget.style.transform = 'scale(1.1)';
      }}
      onMouseLeave={(e) => {
        e.currentTarget.style.transform = 'scale(1)';
      }}
    >
      {getIcon()}
    </Button>
  );
};

SwitchDarkMode.displayName = 'SwitchDarkMode';

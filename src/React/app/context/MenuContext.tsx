'use client';
import React, { createContext, useContext, useRef, useCallback } from 'react';

interface MenuContextType {
  toggleMenu: () => void;
  setToggleMenu: (fn: () => void) => void;
}

const MenuContext = createContext<MenuContextType | undefined>(undefined);

export const MenuProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const toggleMenuRef = useRef<() => void>(() => {});

  const toggleMenu = useCallback(() => {
    toggleMenuRef.current();
  }, []);

  const setToggleMenu = useCallback((fn: () => void) => {
    toggleMenuRef.current = fn;
  }, []);

  const value = React.useMemo(() => ({ toggleMenu, setToggleMenu }), [toggleMenu, setToggleMenu]);

  return (
    <MenuContext.Provider value={value}>
      {children}
    </MenuContext.Provider>
  );
};

export const useMenu = () => {
  const context = useContext(MenuContext);
  if (!context) {
    throw new Error('useMenu must be used within a MenuProvider');
  }
  return context;
};

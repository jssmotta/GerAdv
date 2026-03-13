'use client';

import React, { createContext, useContext, useState, ReactNode } from 'react';

type HelpContextType = {
  shown: boolean;
  setShown: (v: boolean) => void;
};

const HelpContext = createContext<HelpContextType | undefined>(undefined);

export const HelpProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [shown, setShown] = useState(false);
  return <HelpContext.Provider value={{ shown, setShown }}>{children}</HelpContext.Provider>;
};

export const useHelp = (): HelpContextType => {
  const ctx = useContext(HelpContext);
  if (!ctx) {
    return { shown: false, setShown: () => {} };
  }
  return ctx;
};

export default HelpContext;

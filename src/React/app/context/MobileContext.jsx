"use client";
import React, { createContext, useContext, useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
const MobileContext = createContext(false);

export const MobileProvider = ({ children }) => {
  // Start with false on both server and client to avoid hydration mismatch
  const [isMobile, setIsMobile] = useState(false);
  const [hasMounted, setHasMounted] = useState(false);
  const router = useRouter();

 

  useEffect(() => {
    setHasMounted(true);
    
    const handleResize = () => {
      if (typeof window !== 'undefined') {        
        const userAgent = navigator.userAgent || navigator.vendor || window.opera;
        const isIOS = /iPhone|iPod/.test(userAgent) && !window.MSStream;
        const isAndroid = /android/i.test(userAgent);
        setIsMobile(isIOS || isAndroid || window.matchMedia('(max-width: 768px)').matches);
      }
    };

    handleResize(); // Check initial state
    if (typeof window !== 'undefined') {
      window.addEventListener('resize', handleResize); // Add listener for resize changes
    }

    return () => {
      if (typeof window !== 'undefined') {
        window.removeEventListener('resize', handleResize); // Remove listener on component unmount
      }
    };
  }, [router.pathname]);


  return (
    <MobileContext.Provider value={isMobile}>
      {children}
    </MobileContext.Provider>
  );
};

export const useIsMobile = () => useContext(MobileContext);
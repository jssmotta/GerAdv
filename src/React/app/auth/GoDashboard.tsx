'use client';
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import SplashLogin from '../auth/splash/SplashLogin';
import { useIsMobile } from '../context/MobileContext';
import { useAppSelector } from '../store/hooks';
import { selectSystemContext } from '../store/slices/systemContextSlice';
const GoDashboard: React.FC = () => {
  const router = useRouter();
  const systemContext = useAppSelector(selectSystemContext);
  const isMobile = useIsMobile();

  useEffect(() => {
    localStorage.setItem(
      btoa(
        `${process.env.NEXT_PUBLIC_APP_GLOBAL}${systemContext?.TenantApp ?? ''}drawerSelected`
      ),
      'Home'
    );
  }, [systemContext]);

  useEffect(() => {
    const timer = setTimeout(() => {      
        router.push('/dashboard');    
    }, 2000);
    return () => clearTimeout(timer);
  }, [isMobile]);

  return (
    <>
      <SplashLogin />
    </>
  );
};

export default GoDashboard;

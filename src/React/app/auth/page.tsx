'use client';
import { useAppDispatch } from '../store/hooks';
import { setDiaAgenda } from '../store/slices/systemContextSlice';
import React from 'react';
import HotjarComponent from '../tools/Hotjar';
import GAComponent from '../tools/GA';
import { useIsMobile } from '../context/MobileContext';
import { iniciaBarraAgendaSemanaData } from '../tools/helpers';
import LoginUI from './authUI'; 


export default function LoginPage() {
  const dispatch = useAppDispatch();
  const isMobile = useIsMobile();

  React.useEffect(() => {
    dispatch(setDiaAgenda(iniciaBarraAgendaSemanaData(isMobile)));
  }, [isMobile, dispatch]);

  React.useEffect(() => {
    const link = document.createElement('link');
    link.rel = 'dns-prefetch';
    link.href = process.env.NEXT_PUBLIC_URL_API_FETCH ?? '';
    document.head.appendChild(link);
  }, []);

  return (
    <>
      <GAComponent />
      <LoginUI />
      <HotjarComponent />
    </>
  );
}

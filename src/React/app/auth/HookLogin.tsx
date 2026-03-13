'use client';
import React, { useRef, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { useAppSelector } from '../store/hooks';
import { selectSystemContext } from '../store/slices/systemContextSlice';
import { MustChangePasswordChecked } from '@/app/auth/tools/userControl';

const useLoginLogic = () => {
  const [initialLoading, setInitialLoading] = React.useState(true);
  const systemContext = useAppSelector(selectSystemContext);
  const router = useRouter();
  const redirectAttemptedRef = useRef(false);
  const PSplashTime = 500; // 0.5 segundos

  useEffect(() => {
    if (systemContext) {
      if (initialLoading) {
        setTimeout(() => {
          setInitialLoading(false);
        }, PSplashTime);
      }
    } else {
      // Fallback: se systemContext não for definido em tempo razoável, redireciona para login
      const fallbackTimer = setTimeout(() => {
        router.push('/auth');
      }, 2000);
      return () => clearTimeout(fallbackTimer);
    }
  }, [systemContext]);

  return {
    initialLoading,
  };
};

export default useLoginLogic;

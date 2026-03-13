'use client';
import React, { useEffect, useRef, useState } from 'react';
import axios from 'axios';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';

export async function checkHealth(
  onStatusOk: (data: any) => void,
  onStatusOffline: (error: any) => void
) {
  try {
    const response = await axios.get(
      `${process.env.NEXT_PUBLIC_URL_API_HEALTH}/healthCheck`,
      {
        timeout: 5000,
      }
    );

    if (response.status === 200 && response.data?.status === 'Healthy') {
      onStatusOk(response.data);
    } else {
      onStatusOffline({
        message: 'API responded but not healthy',
        data: response.data,
        status: response.status,
      });
    }
  } catch (error) {
    if (axios.isAxiosError(error)) {
      if (error.code === 'ECONNABORTED' || !error.response) {
        onStatusOffline({
          message: 'Connectivity error',
          error: error.message,
          code: error.code,
        });
      } else {
        onStatusOffline({
          message: 'API error',
          status: error.response?.status,
          data: error.response?.data,
        });
      }
    } else {
      onStatusOffline({
        message: 'Unknown error',
        error,
      });
    }
  }
}

const HeadStatusConectivty: React.FC = () => {
  const [apiOffline, setApiOffline] = useState(false);
  const systemContext = useAppSelector(selectSystemContext);

  // Configurações de intervalo
  const PNormalInterval = 20000; // 20 segundos quando tudo está OK
  const PSecondsToStart = 30000; // 30 segundos para começar
  const PInitialCheckback = 2000; // 2 segundos inicial quando offline
  const PMaxInterval = 180000; // 3 minutos (180 segundos) máximo

  const [intervalTime, setIntervalTime] = useState(PNormalInterval);
  const [currentOfflineDelay, setCurrentOfflineDelay] =
    useState(PInitialCheckback);
  const intervalRef = useRef<NodeJS.Timeout | null>(null);

  // Função para calcular o próximo delay
  const getNextDelay = (currentDelay: number): number => {
    const nextDelay = currentDelay + 1000; // Adiciona 1 segundo (1000ms)
    return Math.min(nextDelay, PMaxInterval); // Não passa de 3 minutos
  };

  // Função para resetar o delay quando a API volta online
  const resetDelay = () => {
    setCurrentOfflineDelay(PInitialCheckback);
    setIntervalTime(PNormalInterval);
  };

  useEffect(() => {
    let isMounted = true;

    const checkGoogleAndHealth = () => {
      fetch('https://www.google.com', { mode: 'no-cors' })
        .then(() => {
          callCheckHealth();
        })
        .catch(() => {
          // Se não consegue acessar o Google, assume que não há internet
          // e não marca como offline (evita falso positivo)
          if (isMounted) {
            setApiOffline(false);
          }
        });
    };

    const callCheckHealth = () => {
      checkHealth(
        () => {
          if (isMounted) {
            setApiOffline(false);
            resetDelay();
          }
        },
        () => {
          if (isMounted) {
            setApiOffline(true);

            // Aumenta o delay para a próxima tentativa
            const nextDelay = getNextDelay(currentOfflineDelay);
            setCurrentOfflineDelay(nextDelay);
            setIntervalTime(nextDelay);
          }
        }
      );
    };

    const startInterval = () => {
      if (intervalRef.current) clearInterval(intervalRef.current);
      intervalRef.current = setInterval(checkGoogleAndHealth, intervalTime);
    };

    const stopInterval = () => {
      if (intervalRef.current) {
        clearInterval(intervalRef.current);
        intervalRef.current = null;
      }
      setApiOffline(false);
    };

    const handleVisibilityChange = () => {
      if (document.visibilityState === 'visible') {
        startInterval();
      } else {
        stopInterval();
      }
    };

    document.addEventListener('visibilitychange', handleVisibilityChange);

    if (document.visibilityState === 'visible') {
      startInterval();
    }

    return () => {
      isMounted = false;
      stopInterval();
      document.removeEventListener('visibilitychange', handleVisibilityChange);
    };
  }, [intervalTime, currentOfflineDelay]);

  const clickHelp = () => {
    if (typeof window !== 'undefined') {
      window.open(
        `https://api.whatsapp.com/send?phone=${process.env.NEXT_PUBLIC_WHATSAPP_NUMBER}&text=EMERGENCIA, ${process.env.NEXT_PUBLIC_NOME_PRODUTO} fora do ar. Usuário: ${systemContext?.FirstName}, domínio ${systemContext?.TenantApp}`,
        'jeffersonsmotta'
      );
    }
  };

  return (
    <>
      {apiOffline && (
        <>
          <style jsx>{`
            .api-offline-banner {
              z-index: 99999;
              position: fixed;
              top: 0;
              right: 0;
              border-radius: 5px 5px;
              width: 20vw;
              height: 40px;
              background: linear-gradient(
                90deg,
                var(--kendo-error-170) 0%,
                var(--kendo-error-100) 100%
              );
              color: var(--kendo-warning-100);
              text-align: center;
              font-weight: bold;
              font-size: 1.1rem;
              letter-spacing: 2px;
              display: flex;
              align-items: center;
              justify-content: center;
              box-shadow: 0 2px 8px rgba(0, 0, 0, 0.12);
              overflow: hidden;
            }
            .marquee {
              display: inline-block;
              white-space: nowrap;
              animation: marquee 4s linear infinite;
            }
            @keyframes marquee {
              0% {
                transform: translateX(100%);
              }
              100% {
                transform: translateX(-100%);
              }
            }
          `}</style>
          <div className="api-offline-banner" onClick={clickHelp}>
            <span className="marquee">
              &nbsp;&nbsp;&nbsp;&nbsp;S E R V I Ç O &nbsp;&nbsp;O F F
              &nbsp;&nbsp;L I N E &nbsp;&nbsp;&nbsp;&nbsp; - CLIQUE AQUI PARA
              CHAMAR O SUPORTE
            </span>
          </div>
        </>
      )}
    </>
  );
};

export default HeadStatusConectivty;
